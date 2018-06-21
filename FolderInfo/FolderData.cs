using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderInfo
{
    public class FolderData
    {
        public int AverageFolderSize { get; set; }
        public int MinFolderSize { get; set; }
        public int MaxFolderSize { get; set; }
        public int Size { get; set; }
        public string Directory { get; }

        public FolderData(string directory)
        {
            Directory = directory;
        }
    }
}
