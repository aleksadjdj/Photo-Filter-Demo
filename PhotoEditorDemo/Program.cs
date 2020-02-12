using System;
using System.Diagnostics;

namespace PhotoEditorDemo
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Working...");

            Stopwatch stopwatch = Stopwatch.StartNew();
            new ImageEditor("D:\\demo.jpg", "D:\\demo2.png");
            Console.WriteLine($"{stopwatch.Elapsed}");
        }
    }
}
