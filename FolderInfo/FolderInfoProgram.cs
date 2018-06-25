using System;
using System.IO;
using System.Linq;

namespace FolderInfo
{
    /// <summary>
    /// Program displaying user specified folder information
    /// </summary>
    class FolderInfoProgram
    {
        // default folder, if user does not specify input folder
        private static readonly string appDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        // program argument switch to display info for subdirectories
        private static bool argAllDirs;
        // program argument switch to display folder info in a form with tree view
        private static bool argShowTree;
        // property position in console display
        private const int PropertyAlignment = -28;
        // value position in console display
        private const int ValueAlignment = 15;

        static void Main(string[] args)
        {
            // parse optional command line arguments
            if (args != null)
            {
                // show info for subdirectories
                argAllDirs = args.Contains("alldirs");
                // show info in a form with tree view
                argShowTree = args.Contains("showtree");
            }

            // read user folder input directory
            Console.WriteLine("Enter directory to scan:");
            var directoryToScan = Console.ReadLine();
            directoryToScan = Path.GetFullPath(String.IsNullOrEmpty(directoryToScan) ? appDir : directoryToScan);
            try
            {
                // nonexistent directory
                if (!Directory.Exists(directoryToScan))
                {
                    Console.WriteLine($"Directory: {directoryToScan} does not exist.");
                }
                // process the directory
                else
                {
                    Console.WriteLine($"Scanning directory: {directoryToScan}{Environment.NewLine}");
                    // create folder data
                    var folderData = new FolderData(directoryToScan);
                    // print results
                    PrintFolderInfo(folderData);
                    // optinally show tree view
                    if (argShowTree)
                    {
                        using (var folderDataView = new FolderDataView(folderData))
                        {
                            folderDataView.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Error occured:{Environment.NewLine}{exc.Message}");
            }

            // close program
            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// Prints computed folder info in a console
        /// </summary>
        /// <param name="folderData">Folder data</param>
        private static void PrintFolderInfo(FolderData folderData)
        {

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Folder: {folderData.Directory}");
            Console.ResetColor();
            Console.WriteLine($"{"Size:", PropertyAlignment}{folderData.Size, ValueAlignment}");
            Console.WriteLine($"{"Size Without SubFolders:", PropertyAlignment}{folderData.SizeWithoutSubFolders, ValueAlignment}");
            Console.WriteLine($"{"Folder Count:", PropertyAlignment}{folderData.FolderCount, ValueAlignment}");
            Console.WriteLine($"{"Min Folder Size:", PropertyAlignment}{folderData.MinFolderSize, ValueAlignment}");
            Console.WriteLine($"{"Max folder Size:", PropertyAlignment}{folderData.MaxFolderSize, ValueAlignment}");
            Console.WriteLine($"{"Average Folder size:", PropertyAlignment}{folderData.AverageFolderSize, ValueAlignment}");

            // print subdirectories if command switch is set
            if (argAllDirs)
            {
                foreach (var subFolderData in folderData.SubFolderData)
                {
                    PrintFolderInfo(subFolderData);
                }
            }
        }
    }
}
