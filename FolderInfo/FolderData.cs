using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderInfo
{
    //TODO neni treba objekt, staci staticka trida
    pridat list s infem kazdeho prochazeneho adresare, vypisovat pomoci listu venku ne v teto tride.
    pridat prepinac pro form - zobrazeni vysledku zde ulozeneho rekurz. listu -> zobrazit strom s infem na formu
    public class FolderData
    {
        private long averageFolderSize = 0;
        private long minFolderSize = 0;
        private long size = 0;
        private long maxFolderSize = 0;
        private int folderCount = 0;

        public long Size => size;
        public int FolderCount => folderCount;
        public long AverageFolderSize => Size / FolderCount;
        public long MinFolderSize => minFolderSize;
        public long MaxFolderSize => maxFolderSize;
        public string Directory { get; }

        public FolderData(string directory)
        {
            Directory = directory;

            // TODO test directory exist?
            ComputeData(directory);
        }

        private void ComputeData(string directory)
        {
            long folderSize = 0;
            // rekurzivní funkce, projde adresář, 
            // výsledek: average, min, max, overall

            // Pro každý adresář vypsat:
            // 1) průměrná velikost adresáře (soubory, bez podadresářů !)
            // 2) min velikost adresáře (soubory, bez podadresářů !)
            // 3) max velikost adresáře (soubory, bez podadresářů !)

            folderSize = GetDirectorySize(directory);
            size += folderSize;
            folderCount++;
            minFolderSize = folderSize < minFolderSize ? folderSize : minFolderSize;
            maxFolderSize = folderSize > maxFolderSize ? folderSize : maxFolderSize;

            Console.WriteLine("Dir: " + directory);
            Console.WriteLine("Size: " + folderSize);
            Console.WriteLine("Count: " + folderCount);
            Console.WriteLine("Min: " + minFolderSize);
            Console.WriteLine("Max: " + maxFolderSize);

            var directories = System.IO.Directory.GetDirectories(directory);
            foreach (var directoryItem in directories)
            {
                ComputeData(directoryItem);
            }
        }

        static long GetDirectorySize(string directory)
        {
            // Get array of all file names
            var fileNames = System.IO.Directory.GetFiles(directory);

            // Calculate total bytes of all files in a loop.
            long directorySize = 0;
            foreach (string file in fileNames)
            {
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(file);
                directorySize += info.Length;
            }
            // Return total size
            return directorySize;
        }
    }
}
