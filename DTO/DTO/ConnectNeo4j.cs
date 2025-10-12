using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ConnectNeo4j : IDisposable
    {
        private readonly IDriver _driver;
        public ConnectNeo4j()
        {
            _driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "12345678"));
        }

        public async Task<string> GetCustomerDataAsync()
        {
            string resultString = "";
            var session = _driver.AsyncSession();

            try
            {
                var result = await session.RunAsync("MATCH (c:User) RETURN c.name AS Name LIMIT 10");

                while (await result.FetchAsync()) 
                {
                    resultString += result.Current["Name"].As<string>() + "\n";
                }
            }
            finally
            {
                await session.CloseAsync();
            }

            return resultString;
        }

        public void Dispose() => _driver?.Dispose();
        public IDriver GetDriver()
        {
            return _driver;
        }

    }
}
