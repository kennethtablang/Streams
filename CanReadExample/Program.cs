namespace CanReadExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "example.txt";

            // Create the file for demonstration purposes
            CreateSampleFile(filePath);

            FileStream? fileStream = null;

            try
            {
                fileStream = new FileStream(filePath, FileMode.Open); // Open the file

                // Check if the FileStream supports reading
                if (fileStream.CanRead)
                {
                    // FileStream supports reading, proceed to read the content
                    StreamReader reader = new StreamReader(fileStream);
                    string content = reader.ReadToEnd();
                    Console.WriteLine("File content:");
                    Console.WriteLine(content);
                    reader.Close(); // Close the StreamReader
                }
                else
                {
                    Console.WriteLine("FileStream does not support reading.");
                    //Kung hindi siya nababasa maeexecute to ^^^^^
                }
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close(); // Ensure FileStream is closed
            }
        }

        public static void CreateSampleFile(string filePath)
        {
            FileStream? fileStream = null;
            StreamWriter? writer = null;

            try
            {
                fileStream = new FileStream(filePath, FileMode.Create); // Create the file
                writer = new StreamWriter(fileStream); // Write to the file

                writer.WriteLine("This is a sample file for CanRead demonstration.");
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
