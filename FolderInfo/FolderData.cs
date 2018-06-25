using System.Collections.Generic;
using System.IO;

namespace FolderInfo
{
    /// <summary>
    /// Information about folder and it's subfolders
    /// </summary>
    public class FolderData
    {
        private long minFolderSize = 0;
        private long size = 0;
        private long maxFolderSize = 0;
        private long sizeWithoutSubFolders = 0;
        private int folderCount = 0;
        private List<FolderData> subFolderData = new List<FolderData>();

        /// <summary>
        /// Folder size including subdirectories
        /// </summary>
        public long Size => size;
        /// <summary>
        /// Folder count including parent and subdirectories
        /// </summary>
        public int FolderCount => folderCount;
        /// <summary>
        /// Average folder size in a folder tree
        /// </summary>
        public long AverageFolderSize => Size / FolderCount;
        /// <summary>
        /// Minimal folder size in a folder tree
        /// </summary>
        public long MinFolderSize => minFolderSize;
        /// <summary>
        /// Maximal folder size in a folder tree
        /// </summary>
        public long MaxFolderSize => maxFolderSize;
        /// <summary>
        /// Folder size without subfolders (only files in folder)
        /// </summary>
        public long SizeWithoutSubFolders => sizeWithoutSubFolders;
        /// <summary>
        /// Folder directory
        /// </summary>
        public string Directory { get; }
        /// <summary>
        /// List of subfolders in this folder
        /// </summary>
        public List<FolderData> SubFolderData => subFolderData;

        /// <summary>
        /// Folder data constructor
        /// </summary>
        /// <param name="directory">Folder directory</param>
        public FolderData(string directory)
        {
            Directory = directory;

            // existing directory
            if (System.IO.Directory.Exists(directory))
                ComputeData(directory);
        }

        /// <summary>
        /// Computes folder data, including subdirectories using recursion
        /// </summary>
        /// <param name="directory">Folder directory to be computed</param>
        private void ComputeData(string directory)
        {
            long folderSize = 0;
            folderCount++;
            folderSize = GetDirectorySize(directory);
            sizeWithoutSubFolders = folderSize;
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
        }

        /// <summary>
        /// Get directory size, without subfolders, only files in actual directory
        /// </summary>
        /// <param name="directory">Directory</param>
        /// <returns>Directory size</returns>
        public static long GetDirectorySize(string directory)
        {
            // Get array of all file names
            var fileNames = System.IO.Directory.GetFiles(directory);

            // Calculate total bytes of all files in a loop
            long directorySize = 0;
            foreach (string file in fileNames)
            {
                // Use FileInfo to get length of each file
                FileInfo info = new FileInfo(file);
                directorySize += info.Length;
            }
            // Return total size
            return directorySize;
        }
    }
}
