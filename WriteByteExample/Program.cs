namespace WriteByteExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "example.dat";

            // Write some bytes to the file using WriteByte()
            WriteBytesToFile(filePath);

            // Read the bytes from the file to verify
            ReadBytesFromFile(filePath);
        }

        static void WriteBytesToFile(string filePath)
        {
            // Create or overwrite the file and write bytes to it
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                // Write byte values 0 to 9 to the file
                for (byte i = 0; i < 10; i++)
                {
                    fileStream.WriteByte(i); // Write each byte
                }
            }

            Console.WriteLine("Bytes written to the file.");
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
