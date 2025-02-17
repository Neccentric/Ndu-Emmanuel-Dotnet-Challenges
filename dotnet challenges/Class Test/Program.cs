using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Get user details
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();
        Console.Write("Enter your ID: ");
        string userId = Console.ReadLine();

        // Define directories
        string mainFolder = "DocumentClassification";
        string excelFolder = Path.Combine(mainFolder, "ExcelFiles");
        string wordFolder = Path.Combine(mainFolder, "WordFiles");
        string pptFolder = Path.Combine(mainFolder, "PowerPointFiles");

        // Ensure directories exist
        Directory.CreateDirectory(mainFolder);
        Directory.CreateDirectory(excelFolder);
        Directory.CreateDirectory(wordFolder);
        Directory.CreateDirectory(pptFolder);

        // Get files from main folder
        DirectoryInfo directoryInfo = new DirectoryInfo(mainFolder);
        FileInfo[] files = directoryInfo.GetFiles();

        // Initialize counters and sizes
        int excelCount = 0, wordCount = 0, pptCount = 0;
        long excelSize = 0, wordSize = 0, pptSize = 0;

        foreach (var file in files)
        {
            string extension = file.Extension.ToLower();
            string newFilePath = string.Empty;

            if (extension == ".xlsx")
            {
                newFilePath = Path.Combine(excelFolder, file.Name);
                excelCount++;
                excelSize += file.Length;
            }
            else if (extension == ".docx")
            {
                newFilePath = Path.Combine(wordFolder, file.Name);
                wordCount++;
                wordSize += file.Length;
            }
            else if (extension == ".pptx")
            {
                newFilePath = Path.Combine(pptFolder, file.Name);
                pptCount++;
                pptSize += file.Length;
            }

            if (!string.IsNullOrEmpty(newFilePath))
            {
                File.Move(file.FullName, newFilePath, true);
            }
        }

        // Display Summary
        Console.WriteLine("\nDocument Classification Summary:");
        Console.WriteLine($"User Name: {userName}");
        Console.WriteLine($"User ID: {userId}");
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"Excel Files: {excelCount} ({excelSize} bytes)");
        Console.WriteLine($"Word Files: {wordCount} ({wordSize} bytes)");
        Console.WriteLine($"PowerPoint Files: {pptCount} ({pptSize} bytes)");
        Console.WriteLine($"Total Files Moved: {excelCount + wordCount + pptCount}");
        Console.WriteLine($"Date Processed: {DateTime.Now}");
    }
}

