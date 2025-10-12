using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Neo4j.Driver;

namespace DAO
{
    public class User : IDisposable
    {
        private readonly IDriver _driver;

        public User(ConnectNeo4j neo4jConnection)
        {
            _driver = neo4jConnection.GetDriver();
        }

        public void Dispose()
        {
            // Không dispose _driver vì nó được quản lý bởi ConnectNeo4j
        }

        public async Task<string> GetCustomerDataAsync()
        {
            string resultString = "";
            var session = _driver.AsyncSession();

            try
            {
                var result = await session.RunAsync("MATCH (c:User) RETURN c.name AS Name LIMIT 10");

                while (await result.FetchAsync()) // Duyệt kết quả
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
    }

}
