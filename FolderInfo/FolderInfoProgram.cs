using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderInfo
{
    //Připravte program, jehož úkolem bude projít podadresáře daného vstupního adresáře všech úrovní a vypsat průměrnou velikost adresáře, minimální a maximální velikost.Velikostí adresáře v tomto případě rozumíme součet velikostí souborů v daném adresáři, bez podadresářů.Implementovat vstup a výstup programu je dobrovolné, adresář je možno mít zadaný přímo do proměnné v kódu a vstup na konzoli, kreativitě se ale meze nekladou.Implementovat v C# s .Net (ideálně dodat výsledek jako solution Visual Studia). 

    class FolderInfoProgram
    {
        private static readonly string appDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        static void Main(string[] args)
        {
            //TODO all dirs arg
            //TODO static class
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

                Console.WriteLine($"Scanning directory: {directoryToScan}");
                PrintFolderInfo(directoryToScan);
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Error occured:{Environment.NewLine}{exc.Message}");
            }

            Console.ReadKey();
        }

        private static void PrintFolderInfo(string directoryToScan)
        {
            // average, min, max, overall
            var folderData = new FolderData(directoryToScan);
            Console.WriteLine($"Folder: {folderData.Directory} data:");
            Console.WriteLine($"Size: {folderData.Size}");
            Console.WriteLine($"Folder count: {folderData.FolderCount}");
            Console.WriteLine($"Average folder size: {folderData.AverageFolderSize}");
            Console.WriteLine($"Min folder size: {folderData.MinFolderSize}");
            Console.WriteLine($"Max folder size: {folderData.MaxFolderSize}");
            // rekurzivní funkce, projde adresář, 

            // Pro každý adresář vypsat:
            // 1) průměrná velikost adresáře (soubory, bez podadresářů !)
            // 2) min velikost adresáře (soubory, bez podadresářů !)
            // 3) max velikost adresáře (soubory, bez podadresářů !)
        }
    }
}
