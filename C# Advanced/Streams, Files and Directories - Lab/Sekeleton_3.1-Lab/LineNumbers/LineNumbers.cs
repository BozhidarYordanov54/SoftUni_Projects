namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            StreamWriter writer = new StreamWriter(outputFilePath);

            using (reader)
            {
                string line = reader.ReadLine();
                int counter = 1;

                using (writer)
                {
                    while (line != null)
                    {
                        writer.WriteLine($"{counter}. {line}");

                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
