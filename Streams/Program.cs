namespace Streams
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // File path to read from and write to
            string filePath = "example.txt";

            // Writing to the file using StreamWriter
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Hello, this is my first line!");
                writer.WriteLine("Hello, this is my first line!");
                writer.WriteLine("Hello, this is my first line!");
                writer.WriteLine("Hello, this is my first line!");
                writer.WriteLine("Hello, this is my first line!");
                writer.WriteLine("Hello, this is my first line!");
                writer.WriteLine("Hello, this is my first line!");
                writer.WriteLine("And here’s another line.");
            }

            Console.WriteLine("Data written to file.");

            // Reading from the file using StreamReader
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd(); // Read all text from the file
                Console.WriteLine("File content:");
                Console.WriteLine(content); // Display the content in the console
            }

        }
    }
}
