using System;
using System.IO;
using System.Linq;

class Program
{
    
        string response;
        Console.WriteLine("Enter your name: ");
        response = Console.ReadLine();

        string responseID;
        Console.WriteLine("Enter your ID:");
        responseID = Console.WriteLine();

        string folderPath = "MicrosoftFileCollection";
        string resultFilePath = Path.Combine(folderPath, "results.txt");

        string folderPath1 = "ExcelFiles";
        string excelFilePath = Path.Combine(folderPath1, "excel");

        Directory.CreateDirectory(folderPath1);

        // Ensure the directory exists
        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine("Directory does not exist. Creating it now...");
            Directory.CreateDirectory(folderPath);
        }

        // Define valid Office file extensions
        string[] officeExtensions = { ".xlsx", ".docx", ".pptx" };

        // Initialize counters
        int excelCount = 0, wordCount = 0, pptCount = 0, totalCount = 0;
        long excelSize = 0, wordSize = 0, pptSize = 0, totalSize = 0;

        DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
        FileInfo[] files = directoryInfo.GetFiles();

        foreach (FileInfo file in directoryInfo.GetFiles());
        {
            string extension = file.Extension.ToLower();
            if (officeExtensions.Contains(extension))
            {
                totalCount++;
                totalSize += file.Length;

                switch (extension) 
                {
                    case ".xlsx":
                        excelCount++;
                        excelSize += file.Length;
                        break;
                    case ".docx":
                        wordCount++;
                        wordSize += file.Length;
                        break;
                    case ".pptx":
                        pptCount++;
                        pptSize += file.Length;
                        break;
                }
            }
        }

        // Write results to file
        using (StreamWriter writer = new StreamWriter(resultFilePath))
        {
            writer.WriteLine("Microsoft Office File Summary:");
            writer.WriteLine("--------------------------------");
            writer.WriteLine($"Excel Files: {excelCount} ({excelSize} bytes)");
            writer.WriteLine($"Word Files: {wordCount} ({wordSize} bytes)");
            writer.WriteLine($"PowerPoint Files: {pptCount} ({pptSize} bytes)");
            writer.WriteLine($"Total Office Files: {totalCount} ({totalSize} bytes)");
        }

    Console.WriteLine($"Your details:");
    Console.WriteLine($"Your Name: {response}");
    Console.WriteLine($"Your ID: {responseID}");
    Console.WriteLine("Summary has been written to results.txt");

       using (StreamWriter writer = new StreamWriter(excelFilePath)) {

            writer.WriteLine($"Excel Files: {excelCount} ({excelSize} bytes)");
        }
    }



