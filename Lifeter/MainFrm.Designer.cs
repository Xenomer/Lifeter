namespace Lifeter
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("asd");
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddProjectBtn = new System.Windows.Forms.ToolStripButton();
            this.DeleteProject = new System.Windows.Forms.ToolStripButton();
            this.ExportBtn = new System.Windows.Forms.ToolStripButton();
            this.ImportBtn = new System.Windows.Forms.ToolStripButton();
            this.PresentateBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.openPresentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PresChangeOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.syncOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainList = new System.Windows.Forms.ListView();
            this.PriorityColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TextColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.MoveItemUpBtn = new System.Windows.Forms.Button();
            this.MoveItemDownBtn = new System.Windows.Forms.Button();
            this.AddItemButton = new System.Windows.Forms.Button();
            this.ProjectList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddProjectBtn,
            this.DeleteProject,
            this.ExportBtn,
            this.ImportBtn,
            this.PresentateBtn,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(821, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddProjectBtn
            // 
            this.AddProjectBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddProjectBtn.Image")));
            this.AddProjectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddProjectBtn.Name = "AddProjectBtn";
            this.AddProjectBtn.Size = new System.Drawing.Size(89, 22);
            this.AddProjectBtn.Text = "Add project";
            this.AddProjectBtn.Click += new System.EventHandler(this.AddProject);
            // 
            // DeleteProject
            // 
            this.DeleteProject.Image = ((System.Drawing.Image)(resources.GetObject("DeleteProject.Image")));
            this.DeleteProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteProject.Name = "DeleteProject";
            this.DeleteProject.Size = new System.Drawing.Size(100, 22);
            this.DeleteProject.Text = "Delete Project";
            this.DeleteProject.Click += new System.EventHandler(this.DeleteCurrentProject);
            // 
            // ExportBtn
            // 
            this.ExportBtn.Image = ((System.Drawing.Image)(resources.GetObject("ExportBtn.Image")));
            this.ExportBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(66, 22);
            this.ExportBtn.Text = "Export..";
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // ImportBtn
            // 
            this.ImportBtn.Image = ((System.Drawing.Image)(resources.GetObject("ImportBtn.Image")));
            this.ImportBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ImportBtn.Name = "ImportBtn";
            this.ImportBtn.Size = new System.Drawing.Size(69, 22);
            this.ImportBtn.Text = "Import..";
            this.ImportBtn.Click += new System.EventHandler(this.ImportBtn_Click);
            // 
            // PresentateBtn
            // 
            this.PresentateBtn.BackColor = System.Drawing.SystemColors.Control;
            this.PresentateBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPresentationToolStripMenuItem,
            this.PresChangeOnTop});
            this.PresentateBtn.Image = ((System.Drawing.Image)(resources.GetObject("PresentateBtn.Image")));
            this.PresentateBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PresentateBtn.Name = "PresentateBtn";
            this.PresentateBtn.Size = new System.Drawing.Size(102, 22);
            this.PresentateBtn.Text = "Presentation";
            // 
            // openPresentationToolStripMenuItem
            // 
            this.openPresentationToolStripMenuItem.Name = "openPresentationToolStripMenuItem";
            this.openPresentationToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.openPresentationToolStripMenuItem.Text = "Open presentation";
            this.openPresentationToolStripMenuItem.Click += new System.EventHandler(this.Presentate);
            // 
            // PresChangeOnTop
            // 
            this.PresChangeOnTop.Name = "PresChangeOnTop";
            this.PresChangeOnTop.Size = new System.Drawing.Size(172, 22);
            this.PresChangeOnTop.Text = "On top: Off";
            this.PresChangeOnTop.Click += new System.EventHandler(this.PresOnTopChange);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.syncOffToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(61, 22);
            this.toolStripDropDownButton1.Text = "Sync";
            // 
            // syncOffToolStripMenuItem
            // 
            this.syncOffToolStripMenuItem.Name = "syncOffToolStripMenuItem";
            this.syncOffToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.syncOffToolStripMenuItem.Text = "Enable sync";
            this.syncOffToolStripMenuItem.Click += new System.EventHandler(this.syncOffToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // MainList
            // 
            this.MainList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PriorityColumn,
            this.TextColumn});
            this.MainList.FullRowSelect = true;
            this.MainList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.MainList.Location = new System.Drawing.Point(216, 28);
            this.MainList.MultiSelect = false;
            this.MainList.Name = "MainList";
            this.MainList.Size = new System.Drawing.Size(565, 446);
            this.MainList.TabIndex = 1;
            this.MainList.UseCompatibleStateImageBehavior = false;
            this.MainList.View = System.Windows.Forms.View.Details;
            this.MainList.SelectedIndexChanged += new System.EventHandler(this.SelectedChanged);
            this.MainList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ItemDoubleClick);
            // 
            // PriorityColumn
            // 
            this.PriorityColumn.Text = "Priority";
            this.PriorityColumn.Width = 43;
            // 
            // TextColumn
            // 
            this.TextColumn.Text = "Text";
            this.TextColumn.Width = 400;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteBtn.BackgroundImage")));
            this.DeleteBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteBtn.Location = new System.Drawing.Point(787, 29);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(27, 28);
            this.DeleteBtn.TabIndex = 3;
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteSelected);
            // 
            // MoveItemUpBtn
            // 
            this.MoveItemUpBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MoveItemUpBtn.BackgroundImage")));
            this.MoveItemUpBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MoveItemUpBtn.Location = new System.Drawing.Point(787, 63);
            this.MoveItemUpBtn.Name = "MoveItemUpBtn";
            this.MoveItemUpBtn.Size = new System.Drawing.Size(27, 28);
            this.MoveItemUpBtn.TabIndex = 4;
            this.MoveItemUpBtn.UseVisualStyleBackColor = true;
            this.MoveItemUpBtn.Click += new System.EventHandler(this.MoveUp);
            // 
            // MoveItemDownBtn
            // 
            this.MoveItemDownBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MoveItemDownBtn.BackgroundImage")));
            this.MoveItemDownBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MoveItemDownBtn.Location = new System.Drawing.Point(787, 97);
            this.MoveItemDownBtn.Name = "MoveItemDownBtn";
            this.MoveItemDownBtn.Size = new System.Drawing.Size(27, 28);
            this.MoveItemDownBtn.TabIndex = 5;
            this.MoveItemDownBtn.UseVisualStyleBackColor = true;
            this.MoveItemDownBtn.Click += new System.EventHandler(this.MoveDown);
            // 
            // AddItemButton
            // 
            this.AddItemButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddItemButton.BackgroundImage")));
            this.AddItemButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddItemButton.Location = new System.Drawing.Point(787, 131);
            this.AddItemButton.Name = "AddItemButton";
            this.AddItemButton.Size = new System.Drawing.Size(27, 28);
            this.AddItemButton.TabIndex = 6;
            this.AddItemButton.UseVisualStyleBackColor = true;
            this.AddItemButton.Click += new System.EventHandler(this.AddItem);
            // 
            // ProjectList
            // 
            this.ProjectList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.ProjectList.FullRowSelect = true;
            this.ProjectList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ProjectList.HideSelection = false;
            this.ProjectList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.ProjectList.LabelEdit = true;
            this.ProjectList.LabelWrap = false;
            this.ProjectList.Location = new System.Drawing.Point(0, 28);
            this.ProjectList.MultiSelect = false;
            this.ProjectList.Name = "ProjectList";
            this.ProjectList.ShowGroups = false;
            this.ProjectList.ShowItemToolTips = true;
            this.ProjectList.Size = new System.Drawing.Size(210, 445);
            this.ProjectList.TabIndex = 7;
            this.ProjectList.UseCompatibleStateImageBehavior = false;
            this.ProjectList.View = System.Windows.Forms.View.Details;
            this.ProjectList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.ProjectRename);
            this.ProjectList.SelectedIndexChanged += new System.EventHandler(this.ProjectsListViewIndexChange);
            this.ProjectList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ProjectListMouseUp);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(821, 483);
            this.Controls.Add(this.ProjectList);
            this.Controls.Add(this.AddItemButton);
            this.Controls.Add(this.MoveItemDownBtn);
            this.Controls.Add(this.MoveItemUpBtn);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.MainList);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFrm";
            this.Text = "Lifeter";
            this.Load += new System.EventHandler(this.FormLoad);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ListView MainList;
        private System.Windows.Forms.ColumnHeader PriorityColumn;
        private System.Windows.Forms.ColumnHeader TextColumn;
        private System.Windows.Forms.ToolStripButton AddProjectBtn;
        private System.Windows.Forms.ToolStripButton DeleteProject;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button MoveItemUpBtn;
        private System.Windows.Forms.Button MoveItemDownBtn;
        private System.Windows.Forms.Button AddItemButton;
        private System.Windows.Forms.ToolStripButton ExportBtn;
        private System.Windows.Forms.ToolStripButton ImportBtn;
        private System.Windows.Forms.ToolStripDropDownButton PresentateBtn;
        private System.Windows.Forms.ToolStripMenuItem openPresentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PresChangeOnTop;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem syncOffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ListView ProjectList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

