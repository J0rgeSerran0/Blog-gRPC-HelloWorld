﻿using Grpc.Net.Client;
using GrpcHelloWorld;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GrpcHelloWorldClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();

            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var httpClient = new HttpClient();
            // The port number(50051) must match the port of the gRPC server.
            httpClient.BaseAddress = new Uri("http://localhost:50051");
            var client = GrpcClient.Create<Greeter.GreeterClient>(httpClient);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}