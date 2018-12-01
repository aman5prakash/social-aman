using System;
using Microsoft.Extensions.Options;
using Neo4jClient;

namespace quizartsocial_backend.Services
{
    public class GraphDb : IDisposable
    {
        public IGraphClient graph { get; }
        public GraphDbConnection()
        {
            try
            {
                graph = new GraphClient(
                        new Uri("172.23.238.164:17474"),
                        "neo4j",
                        "qwertyuiop"
                    );
                graph.Connect();
            }
            catch (Exception e)
            {
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("-------------------------------------------------------------------------");
            }
        }

        public void Dispose()
        {
            graph.Dispose();
        }
    }
}