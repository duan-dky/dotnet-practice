using System.IO;
namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TreeNode myComputerNode = new TreeNode("´ËµçÄÔ");
            treeView1.Nodes.Add(myComputerNode);
            listViewShow(myComputerNode);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void listViewShow(TreeNode dirNode)
        {
            listView1.Clear();
            try
            {
                if (dirNode.Parent == null)
                {
                    foreach (string DrvName in Directory.GetLogicalDrives())
                    {
                        ListViewItem aItem = new ListViewItem(DrvName);
                        listView1.Items.Add(aItem);
                    }
                }
                else
                {

                    foreach (string DirName in
                   Directory.GetDirectories((string)dirNode.Tag))
                    {
                        ListViewItem aItem = new ListViewItem(DirName);
                        listView1.Items.Add(aItem);
                    }
                    foreach (string fileName in Directory.GetFiles((string)
                   dirNode.Tag))
                    {
                        ListViewItem aItem = new ListViewItem(fileName);
                        listView1.Items.Add(aItem);
                    }
                }
            }
            catch(UnauthorizedAccessException e)
            {
                MessageBox.Show("¾Ü¾ø·ÃÎÊ£¡", "´íÎó", MessageBoxButtons.OK,
            MessageBoxIcon.Error);
            }
        }
        private void listViewShow(string dirName)
        {
            listView1.Clear();
            try
            {
                foreach (string DirName in Directory.GetDirectories(dirName))
                {
                    ListViewItem aItem = new ListViewItem(DirName);
                    listView1.Items.Add(aItem);
                }
                foreach (string fileName in Directory.GetFiles(dirName))
                {
                    ListViewItem aItem = new ListViewItem(fileName);
                    listView1.Items.Add(aItem);
                }
            }
            catch { 
            }
        }
        private void DirTreeShow(TreeNode dirNode)
        {
            try
            {
                if (dirNode.Nodes.Count == 0)
                {
                    if (dirNode.Parent == null)
                    {
                        foreach (string DrvName in Directory.GetLogicalDrives())
                        {
                            TreeNode aNode = new TreeNode(DrvName);
                            aNode.Tag = DrvName;
                            dirNode.Nodes.Add(aNode);
                        }
                    }
                    else
                    {
                        foreach (string DirName in
                       Directory.GetDirectories((string)dirNode.Tag))
                        {
                            TreeNode aNode = new TreeNode(DirName);
                            aNode.Tag = DirName;
                            dirNode.Nodes.Add(aNode);
                        }
                    }
                }
            }
            catch {
            }
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            foreach (int listIndex in listView1.SelectedIndices)
            {
                listViewShow(listView1.Items[listIndex].Text);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listViewShow(e.Node);
            DirTreeShow(e.Node);
        }
    }
}