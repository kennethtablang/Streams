namespace CanWriteExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "example.txt";

            // Create the file for demonstration purposes
            CreateSampleFile(filePath);

            // Now open the file in read-only mode and check if we can write to it
            FileStream fileStream = null;
            StreamWriter writer = null;

            try
            {
                // Open the file in read-only mode (FileAccess.Read). Try changing the Read mode to Write mode
                fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                // Check if the FileStream supports writing
                if (fileStream.CanWrite)
                {
                    writer = new StreamWriter(fileStream); // StreamWriter to write to the file
                    writer.WriteLine("Adding some text to the file.");
                    Console.WriteLine("Writing to the file...");
                }
                else
                {
                    Console.WriteLine("FileStream does not support writing.");
                }
            }
            finally
            {
                // Close the StreamWriter and FileStream manually
                if (writer != null)
                    writer.Close();
                if (fileStream != null)
                    fileStream.Close();
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

                writer.WriteLine("This is a sample file for CanWrite demonstration.");
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
