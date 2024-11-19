namespace FlushExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "example.txt";

            // Write data to the file
            WriteDataToFile(filePath);

            // Read the data back from the file
            ReadDataFromFile(filePath);
        }

        static void WriteDataToFile(string filePath)
        {
            // Create or overwrite the file and write text to it
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.WriteLine("This is the first line.");
                writer.WriteLine("This is the second line.");

                // Flush the buffer to ensure all data is written to the file
                writer.Flush();
                Console.WriteLine("Data written and flushed to the file.");
            }
        }

        static void ReadDataFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string content = reader.ReadToEnd();
                    Console.WriteLine("File content:");
                    Console.WriteLine(content);
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}
