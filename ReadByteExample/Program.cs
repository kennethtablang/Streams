namespace ReadByteExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "example.dat";

            // Create a sample binary file for demonstration
            CreateSampleBinaryFile(filePath);

            // Now, let's read the bytes from the file using Read()
            ReadBytesFromFile(filePath);
        }

        static void CreateSampleBinaryFile(string filePath)
        {
            // Create a sample binary file with some byte data
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                // Write some bytes to the file
                for (byte i = 0; i < 10; i++)
                {
                    fileStream.WriteByte(i); // Write byte values 0 to 9
                }
            }
        }

        public static void ReadBytesFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    byte[] buffer = new byte[5]; // Buffer to hold bytes read
                    int bytesRead;

                    // Read bytes from the file
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        Console.WriteLine($"Bytes read: {bytesRead}");
                        Console.WriteLine("Read bytes: " + BitConverter.ToString(buffer, 0, bytesRead));
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}
