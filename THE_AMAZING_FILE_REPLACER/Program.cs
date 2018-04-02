using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THE_AMAZING_FILE_REPLACER
{
    class Program
    {
        static void Main(string[] args)
        {
            var folderPath = Environment.CurrentDirectory;

            Console.WriteLine("Welcome to The Amazing File Replacer Program by Chen");

            Console.WriteLine("\nYou are going to replace '..\\' to 'W:\\");
            Console.WriteLine($"in path {folderPath}?");
            Console.WriteLine("\nPress 'yes' to continue!");

            Console.Write($"\nYou choice (yes or no ): ");
            var ans = Console.ReadLine();
            if (ans.StartsWith("yes"))
            {
                string[] filePath = Directory.GetFiles(folderPath);

                Console.WriteLine("\nWe are working to replace JSON file");
                Task worker = Task.Run(() => ReplaceWorker(filePath));

                worker.Wait();
                Console.WriteLine("\nReplace Done!");
            }
            Console.ReadLine();
        }

        static void ReplaceWorker(string[] filePath)
        {
            int totalJSON = 0;
            foreach (var path in filePath)
            {
                string[] fileSplit = path.Split('.');
                string extension = fileSplit[fileSplit.Length-1];

                if (extension.ToLower() == "json")
                {
                    Console.WriteLine("\nJSON File is " + path);
                    var text = File.ReadAllText(path);
                    var newText = text.Replace(@"..\\", @"W:\\");
                    File.WriteAllText(path, newText);
                    totalJSON++;
                }
                //Console.WriteLine($"File name is {path}");
            }
            Console.WriteLine($"\nTotal Replace: {totalJSON}");
        }
    }
}
