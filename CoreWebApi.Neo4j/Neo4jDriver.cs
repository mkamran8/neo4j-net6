using Neo4j.Driver;

namespace CoreWebApi.Neo4j
{
    public class Neo4jDriver: IDisposable
    {
        private bool _disposed = false;
        private readonly IDriver _driver;

        ~Neo4jDriver() => Dispose(false);

        public Neo4jDriver(string uri, string user, string password)
        {
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
        }

        public async Task<List<IRecord>> FindPersonAsRecord(string personName)
        {
            var query = @"
        MATCH (p:Person)
        WHERE p.name = $name
        RETURN p.name";

            var session = _driver.AsyncSession();
            try
            {
                var readResults = await session.ReadTransactionAsync(async tx =>
                {
                    var result = await tx.RunAsync(query, new { name = personName });
                    return (await result.ToListAsync());
                });

                return readResults;
            }
            // Capture any errors along with the query and data for traceability
            catch (Neo4jException)
            {                
                throw;
            }
            finally
            {
                await session.CloseAsync();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _driver?.Dispose();
            }

            _disposed = true;
        }        
    }
}
