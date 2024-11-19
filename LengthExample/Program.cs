namespace LengthExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "example.txt";

            // Create the file for demonstration purposes
            CreateSampleFile(filePath);

            // Open the file and check its length
            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(filePath, FileMode.Open);

                // Get the total length of the file in bytes
                long fileLength = fileStream.Length;
                Console.WriteLine($"The size of the file is {fileLength} bytes.");
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

                writer.WriteLine("This is a sample file to demonstrate the Length property.");
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
