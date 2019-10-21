using System;
using System.Threading.Channels;
using GrpcGreeter;
using Grpc.Net.Client;
using System.Threading.Tasks;
using Grpc.Core;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //for mac
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            
            var channel = GrpcChannel.ForAddress("http://localhost:5000");
//            var channel = GrpcChannel.ForAddress("http://localhost:5000",new GrpcChannelOptions
//            {
//                Credentials = ChannelCredentials.Insecure
//            });
            
            var client = new Greeter.GreeterClient(channel);
                
            var reply = await client.SayHelloAsync(
                   new HelloRequest { Name = "GreeterClient" });

            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
