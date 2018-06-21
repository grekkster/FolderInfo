using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderInfo
{
    // TODO neni treba objekt, staci staticka trida
    // TODO pridat list s infem kazdeho prochazeneho adresare, vypisovat pomoci listu venku ne v teto tride.
    // TODO pridat prepinac pro form - zobrazeni vysledku zde ulozeneho rekurz. listu -> zobrazit strom s infem na formu
    public class FolderData
    {
        private long averageFolderSize = 0;
        private long minFolderSize = 0;
        private long size = 0;
        private long maxFolderSize = 0;
        private int folderCount = 0;
        private List<FolderData> subFolderData = new List<FolderData>();

        public long Size => size;
        public int FolderCount => folderCount;
        public long AverageFolderSize => Size / FolderCount;
        public long MinFolderSize => minFolderSize;
        public long MaxFolderSize => maxFolderSize;
        public string Directory { get; }

        public List<FolderData> SubFolderData => subFolderData;

        public FolderData(string directory)
        {
            Directory = directory;

            // TODO test directory exist?
            ComputeData(directory);
        }

        private void ComputeData(string directory)
        {
            long folderSize = 0;
            folderCount++;
            folderSize = GetDirectorySize(directory);
            size += folderSize;
            minFolderSize = folderSize;
            maxFolderSize = folderSize;

            // recursively process all subdirectories
            var directories = System.IO.Directory.GetDirectories(directory);
            foreach (var directoryItem in directories)
            {
                var subFolderDataItem = new FolderData(directoryItem);
                folderCount += subFolderDataItem.FolderCount;
                size += subFolderDataItem.Size;
                minFolderSize = minFolderSize < subFolderDataItem.minFolderSize ? minFolderSize : subFolderDataItem.minFolderSize;
                maxFolderSize = maxFolderSize > subFolderDataItem.maxFolderSize ? maxFolderSize : subFolderDataItem.maxFolderSize;
                subFolderData.Add(subFolderDataItem);
            }

            Console.WriteLine("Dir: " + directory);
            Console.WriteLine("Size: " + size);
            Console.WriteLine("Count: " + folderCount);
            Console.WriteLine("Min: " + minFolderSize);
            Console.WriteLine("Max: " + maxFolderSize);
        }

        public static long GetDirectorySize(string directory)
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
