using System;
using System.Drawing;
using System.Windows.Forms;

namespace FolderInfo
{
    /// <summary>
    /// Form displaying folder data in a tree view
    /// </summary>
    public partial class FolderDataView : Form
    {
        /// <summary>
        /// FolderDataView form constructor
        /// </summary>
        /// <param name="folderData">Folder data to be displayed in tree view</param>
        public FolderDataView(FolderData folderData)
        {
            InitializeComponent();
            PopulateTreeView(folderDataTreeView.Nodes, folderData);
        }

        /// <summary>
        /// Populates tree view with folder data
        /// </summary>
        /// <param name="nodes">Nodes to be filled with folder data</param>
        /// <param name="folderData">Folder data</param>
        private void PopulateTreeView(TreeNodeCollection nodes, FolderData folderData)
        {
            try
            {
                var node = new TreeNode(folderData.Directory);
                nodes.Add(node);
                node.BackColor = SystemColors.GradientActiveCaption;
                nodes.Add($"Size: {folderData.Size}");
                nodes.Add($"SizeWithoutSubFolders: {folderData.SizeWithoutSubFolders}");
                nodes.Add($"FolderCount: {folderData.FolderCount}");
                nodes.Add($"MinFolderSize: {folderData.MinFolderSize}");
                nodes.Add($"MaxFolderSize: {folderData.MaxFolderSize}");
                nodes.Add($"AverageFolderSize: {folderData.AverageFolderSize}");
                foreach (var subFolderData in folderData.SubFolderData)
                {
                    PopulateTreeView(node.Nodes, subFolderData);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Unable to show folder data tree:{Environment.NewLine}{exc.Message}", "Folder Data Tree View", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
