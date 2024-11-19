using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ReadTimeOutExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Start a simple TCP server in a separate thread
            Thread serverThread = new Thread(StartServer);
            serverThread.Start();

            // Give the server a moment to start
            Thread.Sleep(1000);

            // Connect to the server as a client
            StartClient();
        }

        //call back method
        static void StartServer()
        {
            TcpListener server = new TcpListener(IPAddress.Any, 12345);
            server.Start();
            Console.WriteLine("Server started. Waiting for a connection...");

            using (TcpClient client = server.AcceptTcpClient())
            {
                Console.WriteLine("Client connected.");
                NetworkStream stream = client.GetStream();

                // Simulate long processing by waiting before sending data
                Thread.Sleep(5000);
                byte[] response = Encoding.UTF8.GetBytes("Hello from server!");
                stream.Write(response, 0, response.Length);
            }

            server.Stop();
        }

        static void StartClient()
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 12345);
            NetworkStream stream = client.GetStream();

            // Set the ReadTimeout to 2000 milliseconds (2 seconds)
            stream.ReadTimeout = 2000;

            byte[] buffer = new byte[256];
            try
            {
                Console.WriteLine("Reading data from the server...");
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Received: {response}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Read operation timed out: {ex.Message}");
            }
            finally
            {
                client.Close();
            }
        }
    }
}
