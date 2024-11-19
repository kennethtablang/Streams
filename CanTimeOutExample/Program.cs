//For FileStream, CanTimeout will typically return false because 
//file streams usually don’t support read or write timeouts. 
//They work directly with disk I/O, where timeouts are generally unnecessary.

namespace CanTimeOutExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "example.txt";

            // Create the file for demonstration purposes
            CreateSampleFile(filePath);

            // Open the file and check if it supports timeouts
            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(filePath, FileMode.Open); // Open the file

                // Check if the FileStream supports timeouts
                if (fileStream.CanTimeout)
                {
                    Console.WriteLine("FileStream supports timeouts.");
                }
                else
                {
                    Console.WriteLine("FileStream does not support timeouts.");
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

                writer.WriteLine("This is a sample file for CanTimeout demonstration.");
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
