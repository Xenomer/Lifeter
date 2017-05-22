using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lifeter
{
    public partial class MainFrm : Form
    {
        public static string currProject;
        public static ListView.ListViewItemCollection items;
        public static PresentationForm pf = new PresentationForm();
        public static string syncPath = "";
        public static bool syncEnable = false;

        public MainFrm()
        {
            InitializeComponent();
            MainList.Columns[1].Width = MainList.Width - MainList.Columns[0].Width - 4;
            ProjectList.Columns[0].Width = ProjectList.Width - 4;
        }

        private void FormLoad(object sender, EventArgs e)
        {
            if (FileSaver.InitializeFileSystem())
            {
                ItemDB.Coll.Add("Main", new LfProject("Main"));
                ItemDB.Coll["Main"].Items.Add(new LfItem { Name = "Example", BackColor = Color.White.ToArgb() });

                currProject = "Main";

                FileSaver.SaveFile();
                FileSaver.SaveCurrent();
            }

            else
            {
                FileSaver.LoadCurrent();
                FileSaver.LoadFile();
            }

            if (syncEnable)
            {
                syncOffToolStripMenuItem.Text = "Disable sync";
                FileSaver.SaveCurrent();
            }
            else
            {
                syncOffToolStripMenuItem.Text = "Enable sync";
                FileSaver.SaveCurrent();
            }

            UpdateList();
            UpdateProjectList();
            SelectedChanged(null, null);
        }

        void UpdateList()
        {
            if (ItemDB.Coll.Count == 0)
            {
                MainList.Items.Clear();
                return;
            }

            if (!ItemDB.Coll.ContainsKey(currProject)) return;
            MainList.Items.Clear();

            int index = 1;
            foreach (LfItem projItem in ItemDB.Coll[currProject].Items)
            {
                ListViewItem sublvi = new ListViewItem(index.ToString());
                sublvi.SubItems.Add(projItem.Name);
                MainList.Items.Add(sublvi);
                sublvi.BackColor = projItem.BackColor.ToColor();

                Color c = projItem.BackColor.ToColor();
                if (c.GetBrightness() > 0.5 || c.IsEmpty)
                    sublvi.ForeColor = Color.Black;
                else sublvi.ForeColor = Color.White;

                index++;
            }

            items = MainList.Items;
            pf.UpdateList();
        }
        void UpdateProjectList()
        {
            ProjectList.Select();
            ProjectList.Items.Clear();
            foreach(string projName in ItemDB.Coll.Keys)
            {
                ListViewItem lvi = new ListViewItem(projName);
                ProjectList.Items.Add(lvi);
                if (projName == currProject)
                {
                    lvi.Selected = true;
                }
            }
        }

        private void ProjectsListViewIndexChange(object sender, EventArgs e)
        {
            //if (ProjectList.SelectedIndices.Count == 0)
            //{
            //    if (_previousIndex >= 0)
            //    {
            //        ProjectList.SelectedIndices.Add(_previousIndex);
            //    }
            //}

            if (ProjectList.SelectedItems.Count == 0) return;
            currProject = ProjectList.SelectedItems[0].Text;
            FileSaver.SaveCurrent();
            UpdateList();
        }

        void AddProject(string name)
        {
            ItemDB.Coll.Add(name, new LfProject(name));
            currProject = name;
            FileSaver.SaveCurrent();
            FileSaver.SaveFile();
            UpdateProjectList();
        }

        private void AddProject(object sender, EventArgs e)
        {
            string nameGot = "";

            AddProjectFrm apf = new AddProjectFrm();

            if(apf.ShowDialog() == DialogResult.OK)
            {
                nameGot = apf.ProjName;

                ItemDB.Coll.Add(nameGot, new LfProject(nameGot));
                currProject = nameGot;
                FileSaver.SaveCurrent();
                FileSaver.SaveFile();
                UpdateProjectList();
            }
        }

        private void AddItem(object sender, EventArgs e)
        {
            string nameGot = "";

            AddItemFrm apf = new AddItemFrm();

            if (apf.ShowDialog() == DialogResult.OK)
            {
                nameGot = apf.itemName;
                ItemDB.Coll[currProject].Items.Add(new LfItem { Name = nameGot, BackColor = apf.color.ToArgb() });
                FileSaver.SaveFile();
                UpdateList();
            }
        }

        private void MoveUp()
        {
            int i = 0;
            foreach(int index in MainList.SelectedIndices)
            {
                i = index - 1;
                ItemDB.Coll[currProject].Items.Move(index, index - 1);
            }
            UpdateList();

            MainList.Items[i].Focused = true;
            MainList.Items[i].Selected = true;
            FileSaver.SaveFile();
        }

        private void MoveDown()
        {
            int i = 0;
            foreach (int index in MainList.SelectedIndices)
            {
                i = index + 1;
                ItemDB.Coll[currProject].Items.Move(index, index + 1);
            }
            UpdateList();

            MainList.Items[i].Focused = true;
            MainList.Items[i].Selected = true;
            FileSaver.SaveFile();
        }

        private void MoveUp(object sender, EventArgs e)
        {
            MoveUp();
        }

        private void MoveDown(object sender, EventArgs e)
        {
            MoveDown();
        }

        private void SelectedChanged(object sender, EventArgs e)
        {
            if (MainList.SelectedIndices.Count == 0)
            {
                MoveItemUpBtn.Enabled = false;
                MoveItemDownBtn.Enabled = false;
                DeleteBtn.Enabled = false;
                return;
            }

            if (MainList.SelectedIndices[0] == 0)
            {
                MoveItemUpBtn.Enabled = false;
            }
            else MoveItemUpBtn.Enabled = true;

            if(MainList.SelectedIndices[0] == MainList.Items.Count - 1)
            {
                MoveItemDownBtn.Enabled = false;
            }
            else MoveItemDownBtn.Enabled = true;

            DeleteBtn.Enabled = true;
        }

        private void DeleteSelected(object sender, EventArgs e)
        {
            if (MainList.SelectedIndices.Count == 0)
                return;

            ItemDB.Coll[currProject].Items.RemoveAt(MainList.SelectedIndices[0]);
            DeleteBtn.Enabled = false;
            UpdateList();
            FileSaver.SaveFile();
        }

        private void DeleteCurrentProject(object sender, EventArgs e)
        {
            ItemDB.Coll.Remove(currProject);

            if (ItemDB.Coll.Count == 0)
            {
                ItemDB.Coll.Add("Main", new LfProject("Main"));
            }

            currProject = ItemDB.Coll.Last().Key;
            FileSaver.SaveCurrent();
            FileSaver.SaveFile();
            UpdateProjectList();
            UpdateList();
        }

        private void Presentate(object sender, EventArgs e)
        {
            if (!pf.Visible)
            {
                openPresentationToolStripMenuItem.Text = "Close presentation";
                pf.Show();
            }
            else
            {
                openPresentationToolStripMenuItem.Text = "Open presentation";
                pf.Hide();
            }
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Export..";
            sfd.Filter = "Lifeter Export File|*.lef";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                FileSaver.ExportProject(sfd.FileName);
                MessageBox.Show("Done.", "Lifeter Export");
            }
        }

        private void ImportBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Lifeter Export File|*.lef";
            ofd.Title = "Import..";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                FileSaver.ImportProject(ofd.FileName);
                MessageBox.Show("Done.", "Lifeter Import");
                UpdateList();
                UpdateProjectList();
                FileSaver.SaveFile();
            }
        }

        private void PresOnTopChange(object sender, EventArgs e)
        {
            bool _state = !pf.TopMost;
            pf.TopMost = _state;

            if (_state)
            {
                PresChangeOnTop.Text = "On top: On";
            }
            else
            {
                PresChangeOnTop.Text = "On top: Off";
            }
        }

        private void syncOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (syncEnable)
            {
                syncEnable = false;
                syncOffToolStripMenuItem.Text = "Enable sync";
                FileSaver.SaveCurrent();
            }
            else
            {
                syncEnable = true;
                syncOffToolStripMenuItem.Text = "Disable sync";
                FileSaver.SaveCurrent();
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SyncOpt().ShowDialog();
        }

        private void ProjectListMouseUp(object sender, MouseEventArgs e)
        {
            if (ProjectList.FocusedItem != null)
            {
                if (ProjectList.SelectedItems.Count == 0)
                    ProjectList.FocusedItem.Selected = true;
            }
        }

        private void ItemDoubleClick(object sender, MouseEventArgs e)
        {
            if (ProjectList.SelectedItems.Count == 0) return;

            int index = MainList.SelectedIndices[0];
            AddItemFrm apf = new AddItemFrm {
                color = ItemDB.Coll[currProject].Items[index].BackColor.ToColor(),
                itemName = ItemDB.Coll[currProject].Items[index].Name};

            if (apf.ShowDialog() == DialogResult.OK)
            {
                ItemDB.Coll[currProject].Items[index].Name = apf.itemName;
                ItemDB.Coll[currProject].Items[index].BackColor = apf.color.ToArgb();
                FileSaver.SaveFile();
                UpdateList();
            }
        }

        private void ProjectRename(object sender, LabelEditEventArgs e)
        {
            if (ProjectList.Items[e.Item].Text == e.Label || e.Label == null) return;
            if (ItemDB.Coll.ContainsKey(e.Label)) e.CancelEdit = true;
            LfProject p = ItemDB.Coll[ProjectList.Items[e.Item].Text];

            currProject = e.Label;
            ItemDB.Coll.Add(e.Label, p);
            ItemDB.Coll.Remove(p.Name);
            ItemDB.Coll[e.Label].Name = e.Label;
            FileSaver.SaveFile();
            UpdateProjectList();
        }
    }
}
