using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Inputs
        string inputPath = GetInputPath();

        while (!File.Exists(inputPath))
        {
            Console.WriteLine("File not found.");
            inputPath = GetInputPath();
        }

        Console.Write("Enter the word/symbol that seperates your blocks of code (recommended example: @@@@@) : ");
        string seperator = Console.ReadLine();
        Console.WriteLine();

        // Building snippets
        List<string> snippets = BuildSnippets(inputPath, seperator);

        // Outputs

        GenerateOutputFile(ref snippets);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Generated snippets:\n");
        foreach (string snippet in snippets)
        {
            Console.WriteLine(snippet);
        }
        Console.ResetColor();

        WaitForExit();
    }

    static void WaitForExit()
    {
        Console.WriteLine("\nFinished, press Esc to quit.");
        ConsoleKeyInfo PressedKey = Console.ReadKey();

        while (PressedKey.Key != ConsoleKey.Escape)
        {
            PressedKey = Console.ReadKey();
        }
    }

    static string GetInputPath()
    {
        Console.Write("Enter the path of input text file: ");
        string filePath = Console.ReadLine();
        Console.WriteLine();

        return filePath;
    }

    static List<string> BuildSnippets(string inputPath, string seperator)
    {
        string[] blocks = File.ReadAllText(inputPath).Split(new string[] { seperator }, StringSplitOptions.RemoveEmptyEntries);

        List<string> snippets = new List<string>();

        int it = 0;
        foreach (string block in blocks)
        {
            it++;

            Console.Write("Enter the keyword for the following block:");
            if (it == 1) Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{block.TrimEnd()}: ");

            Console.ResetColor();
            string userString = Console.ReadLine();
            Console.WriteLine();

            List<string> formattedLines = new List<string>();
            foreach (string line in block.Split('\n'))
            {
                string formattedLine = $@"""{line.TrimEnd().Replace("\"", "\\\"")}""";
                formattedLines.Add(formattedLine);
            }

            string snippet = $@"""{userString}"": {{
    ""prefix"": ""{userString}"",
    ""body"": [
        {string.Join("\n", formattedLines)}
    ]
}}";

            snippets.Add(snippet);
        }

        return snippets;
    }

    static bool YesNoQuestion(string question)
    {
        Console.WriteLine(question);
        Console.Write("-Yes\t-No\n");
        var choice = Console.ReadLine().ToLower();
        Console.WriteLine();

        return choice == "yes";

    }

    static void GenerateOutputFile(ref List<string> snippets)
    {
        if (YesNoQuestion("Do you want your snippets in a text file ?"))
        {
            Console.Write("Enter the path of the snippets output file: ");
            string outputPath = Console.ReadLine();

            File.AppendAllLines(outputPath, snippets);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Done.\n");
            Console.ResetColor();
        }
    }
}
