namespace CanSeekExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "example.txt";

            // Create the file for demonstration purposes
            CreateSampleFile(filePath);

            // Open the file and check if we can seek within it
            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(filePath, FileMode.Open); // Open the file

                // Check if the FileStream supports seeking
                if (fileStream.CanSeek)
                {
                    Console.WriteLine("FileStream supports seeking.");

                    // Seek 10 bytes from the beginning of the file
                    fileStream.Seek(10, SeekOrigin.Begin);

                    // Read and display the content from the new position
                    StreamReader reader = new StreamReader(fileStream);
                    string contentFromPosition = reader.ReadToEnd();
                    Console.WriteLine("Content from the 10th byte onward:");
                    Console.WriteLine(contentFromPosition);
                    reader.Close(); // Close the StreamReader
                }
                else
                {
                    Console.WriteLine("FileStream does not support seeking.");
                }
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close(); // Ensure FileStream is closed
            }
        }

        static void CreateSampleFile(string filePath)
        {
            FileStream fileStream = null;
            StreamWriter writer = null;

            try
            {
                fileStream = new FileStream(filePath, FileMode.Create); // Create the file
                writer = new StreamWriter(fileStream); // Write to the file

                writer.WriteLine("This is a sample file for CanSeek demonstration.");
            }
            finally
            {
                if (writer != null)
                    writer.Close();
                if (fileStream != null)
                    fileStream.Close();
            }
        }
    }
}
