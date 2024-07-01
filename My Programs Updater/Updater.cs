namespace My_Programs_Updater;

abstract class Updater
{
    private static readonly string Source = @"Y:\My Programs";
    private static readonly string Destination = @"F:\My Programs";
    
    static void Main()
    {
        // Get all files and subdirectories in the source directory
        string[] files = Directory.GetFiles(Source, "*", SearchOption.AllDirectories);
        
        // Copy each file and subdirectory to the target directory
        foreach (var file in files)
        {
            string targetFile = file.Replace(Source, Destination);
            string targetDirectory = Path.GetDirectoryName(targetFile) ?? string.Empty;
            
            // Check if the target directory exists, and create it if it doesn't
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }
            
            FileInfo fileInfo = new FileInfo(file);
            try
            {
                File.Copy(file, targetFile, true);
                Console.WriteLine(fileInfo.Directory?.Parent?.Name + ", " + fileInfo.Name);
            }
            catch
            {
                Console.WriteLine(fileInfo.Directory?.Parent?.Name + ", " + fileInfo.Name + " : Error copying file");
            }
        }
        
        Console.WriteLine("Updated Everything!");
        Thread.Sleep(100000000);
    }
}