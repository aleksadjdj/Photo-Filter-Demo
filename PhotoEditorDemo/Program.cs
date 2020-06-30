using System;
using System.IO;

namespace PhotoEditorDemo
{
    /// <summary>
    /// Wordpress preview and thumbnail images
    /// Problem: unwanted gray pixels on white background on an image caused by compression 
    /// this program helped me to fix ~12k images on wordpress site
    /// by removing gray pixels on white background
    /// </summary>
    /// 
    public class Program
    {
        static void Main()
        {
            var currentDirectory = new DirectoryInfo(@"C:\NewFolder\uploads\2020\03");
            FileInfo[] files = currentDirectory.GetFiles("*.jpg"); 
            
            int processedImages = 0;
            Console.WriteLine("Working...");

            foreach (FileInfo file in files)
            {
                string inputFile = file.FullName;
                string outputFile = file.FullName;
                try
                {
                    new ImageEditor(inputFile, outputFile);
                    Console.WriteLine($"{++processedImages}. {inputFile}");
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
