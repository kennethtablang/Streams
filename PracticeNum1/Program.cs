namespace PracticeNum1
{
    public  class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "example.txt";

            StreamWriter writer = new StreamWriter(filePath);
            writer.WriteLine("Hello this is a line in a stream generated file.");
            writer.WriteLine("and here is another line.");
            writer.Close();


            Console.WriteLine("Data is written to the file.");



            StreamReader reader = new StreamReader(filePath);
            string content = reader.ReadToEnd();
            Console.WriteLine(content);
            reader.Close();


            Console.WriteLine($"File content: {new StreamReader(filePath).ReadToEnd()} ");
            
        }
    }
}
