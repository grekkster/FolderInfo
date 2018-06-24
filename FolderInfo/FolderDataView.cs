using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderInfo
{
    public partial class FolderDataView : Form
    {
        public FolderDataView(FolderData folderData)
        {
            InitializeComponent();
            //folderDataTreeView;
            //TreeView tv = new TreeView();

            //---
            //folderDataTreeView.BeginUpdate();

            //// Clear the TreeView each time the method is called.
            //folderDataTreeView.Nodes.Clear();

            //folderDataTreeView.Nodes.Add(folderData.Directory);

            //// Add a root TreeNode for each Customer object in the ArrayList.
            //foreach (FolderData subFolderDAta in folderData.SubFolderData)
            //{
            //    folderDataTreeView.Nodes.Add(new TreeNode(subFolderDAta.Directory));

            //    //// Add a child treenode for each Order object in the current Customer object.
            //    //foreach (Order order1 in customer2.CustomerOrders)
            //    //{
            //    //    folderDataTreeView.Nodes[customerArray.IndexOf(customer2)].Nodes.Add(
            //    //      new TreeNode(customer2.CustomerName + "." + order1.OrderID));
            //    //}
            //}

            //// Reset the cursor to the default for all controls.
            //Cursor.Current = Cursors.Default;

            //// Begin repainting the TreeView.
            //folderDataTreeView.EndUpdate();

            PopulateTreeView(folderDataTreeView.Nodes, folderData);
        }

        private void PopulateTreeView(TreeNodeCollection nodes, FolderData folderData)
        {
            try
            {
                var node = new TreeNode(folderData.Directory);
                nodes.Add(node);
                // TODO ERR - windows bug - pokud je root node bold, nezobrazí se celý text
                // https://stackoverflow.com/questions/2272493/c-sharp-winforms-bold-treeview-node-doesnt-show-whole-text
                // node.NodeFont = new Font(node.TreeView.Font, FontStyle.Bold);
                node.BackColor = Color.DarkOrange;
                systémová barva? aby to nesplývalo, pokud má uživatel nastaven nějakéký theme
                nodes.Add($"Size: {folderData.Size}");
                nodes.Add($"SizeWithoutSubFolders: {folderData.SizeWithoutSubFolders}");
                nodes.Add($"FolderCount: {folderData.FolderCount}");
                nodes.Add($"MinFolderSize: {folderData.MinFolderSize}");
                nodes.Add($"MaxFolderSize: {folderData.MaxFolderSize}");
                nodes.Add($"AverageFolderSize: {folderData.AverageFolderSize}");
                foreach (var subFolderData in folderData.SubFolderData)
                {
                    PopulateTreeView(node.Nodes, subFolderData);
                    //nodes.Add(TreeNode - muj tree node i s objektem dat!FolderData);
                }
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }
            catch
            {
                return;
            }
        }
    }
}
