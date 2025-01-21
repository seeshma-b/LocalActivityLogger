# LocalActivityLogger

The Local Activity Logger is a simple console application built in C# that monitors a specified folder for file system changes such as file creation, modification, deletion, and renaming. All detected events are logged in real-time to the console and saved to a text file (activity_log.txt).

# Requirements
.NET SDK 9.0 or higher

Any C# compatible IDE

Any OS that supports .NET


# Setup

    git clone <project URL>
    
    cd LocaLActivityLogger
    
    dotnet build
    
    dotnet run

1. Edit the path within the Program.cs file:
  
  Change the folder path in the StartMonitoring method to your desired folder:
  
    logger.StartMonitoring(@"<C:\Path\To\Monitor>");
  
  Save the file and rebuild it again.
  

  2. Perform File operations:
     
     -Add, modify, delete, rename files with that folder
     
     -Program will monitor changes within console in real-time.

# Example Outputs:

  -Console Output

    Started monitoring: C:\Users\JohnDoe\Documents\TestFolder
    [2025-01-21 15:00:00] File Created: C:\Users\JohnDoe\Documents\TestFolder\example.txt
    [2025-01-21 15:02:30] File Deleted: C:\Users\JohnDoe\Documents\TestFolder\example.txt
    [2025-01-21 15:05:15] File Renamed from example.txt to sample.txt

  -Log File Output

    [2025-01-21 15:00:00] File Created: C:\Users\JohnDoe\Documents\TestFolder\example.txt
    [2025-01-21 15:02:30] File Deleted: C:\Users\JohnDoe\Documents\TestFolder\example.txt
    [2025-01-21 15:05:15] File Renamed from example.txt to sample.txt
