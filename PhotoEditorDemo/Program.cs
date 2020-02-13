using System;
using System.Diagnostics;

namespace PhotoEditorDemo
{
    public class Program
    {
        static void Main()
        {

            string inputFile = "D:\\asd.jpg";
            string outputFile = "D:\\demo2.png";

            Console.WriteLine("Working...");

            var stopwatch = Stopwatch.StartNew();
            new ImageEditor(inputFile, outputFile);
            Console.WriteLine($"{stopwatch.Elapsed}");
        }
    }
}
