namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text.RegularExpressions;

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);

        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> occurences = new Dictionary<string, int>();
            int counter = 1;

            using (StreamReader textReader = new StreamReader(textFilePath))
            {
                string[] text = textReader.ReadToEnd().Split(new string[] { ".", "?", "!", " ", ";", ":", ",", "-", "..."}, StringSplitOptions.RemoveEmptyEntries);

                using (StreamReader wordsToMatch = new StreamReader(wordsFilePath))
                {
                    string[] words = wordsToMatch.ReadToEnd().Split(" ");

                    for (int i = 0; i < words.Length; i++)
                    {
                        counter = 1;
                        string currentWord = words[i].ToLower();
                        for (int j = 0; j < text.Length; j++)
                        {
                            string currentWordText = text[j].ToLower();

                            if (currentWord == currentWordText)
                            {
                                if (!occurences.ContainsKey(currentWord))
                                {
                                    occurences.Add(currentWord, counter);
                                }
                                occurences[currentWord] = counter++;
                            }
                        }
                    }
                }
            }


            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var item in occurences.OrderByDescending(key => key.Value))
                {
                    writer.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }
    }
}
