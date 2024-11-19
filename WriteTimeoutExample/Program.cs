using System.Net.Sockets;
using System.Net;
using System.Text;

namespace WriteTimeoutExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Start a simple TCP server in a separate thread
            Thread serverThread = new Thread(StartServer);
            serverThread.Start();

            // Give the server a moment to start
            Thread.Sleep(1000);

            // Connect to the server as a client
            StartClient();
        }

        static void StartServer()
        {
            TcpListener server = new TcpListener(IPAddress.Any, 12345);
            server.Start();
            Console.WriteLine("Server started. Waiting for a connection...");

            using (TcpClient client = server.AcceptTcpClient())
            {
                Console.WriteLine("Client connected.");
                NetworkStream stream = client.GetStream();

                // Simulate long processing by waiting before receiving data
                Thread.Sleep(5000); // Simulate delay before processing
                byte[] response = Encoding.UTF8.GetBytes("Hello from server!");
                stream.Write(response, 0, response.Length); // Send response
            }

            server.Stop();
        }

        static void StartClient()
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 12345);
            NetworkStream stream = client.GetStream();

            // Set the WriteTimeout to 2000 milliseconds (2 seconds)
            stream.WriteTimeout = 2000;

            byte[] message = Encoding.UTF8.GetBytes("Hello from client!");
            try
            {
                Console.WriteLine("Writing data to the server...");
                stream.Write(message, 0, message.Length); // Attempt to send data
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Write operation timed out: {ex.Message}");
            }
            finally
            {
                client.Close();
            }
        }

    }
}
