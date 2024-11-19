namespace ReadByteExample1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "example.dat";

            // Create a sample binary file for demonstration
            CreateSampleBinaryFile(filePath);

            // Now, let's read the bytes from the file using ReadByte()
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

        static void ReadBytesFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    int byteValue;

                    // Read bytes until the end of the stream
                    while ((byteValue = fileStream.ReadByte()) != -1)
                    {
                        Console.WriteLine($"Read byte: {byteValue}"); // Print the byte value
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
