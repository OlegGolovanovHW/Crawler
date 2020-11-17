namespace FileManager
{
    partial class Form1
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
            this.ListOfItemsLeft = new System.Windows.Forms.ListBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ListOfItemsRight = new System.Windows.Forms.ListBox();
            this.EscapeRight = new System.Windows.Forms.Button();
            this.EscapeLeft = new System.Windows.Forms.Button();
            this.StartSearchingRight = new System.Windows.Forms.Button();
            this.StartSearchingLeft = new System.Windows.Forms.Button();
            this.Copy = new System.Windows.Forms.Button();
            this.Move = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Archive = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuFileFirst = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuFileSecond = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuConfigurationFirst = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuInfoFirst = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuInfoFirst = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackGroundForRename = new System.Windows.Forms.Panel();
            this.Cancel = new System.Windows.Forms.Button();
            this.TextOnPanel = new System.Windows.Forms.Label();
            this.EnteringNewName = new System.Windows.Forms.TextBox();
            this.Enter = new System.Windows.Forms.Button();
            this.CurrentPathLeft = new System.Windows.Forms.RichTextBox();
            this.CurrentPathRight = new System.Windows.Forms.RichTextBox();
            this.SearchLeft = new System.Windows.Forms.RichTextBox();
            this.SearchRight = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.AmountToDrawLeft = new System.Windows.Forms.RichTextBox();
            this.AmountToDrawRight = new System.Windows.Forms.RichTextBox();
            this.menuStrip.SuspendLayout();
            this.BackGroundForRename.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListOfItemsLeft
            // 
            this.ListOfItemsLeft.BackColor = System.Drawing.Color.White;
            this.ListOfItemsLeft.ForeColor = System.Drawing.Color.Black;
            this.ListOfItemsLeft.FormattingEnabled = true;
            this.ListOfItemsLeft.HorizontalScrollbar = true;
            this.ListOfItemsLeft.Location = new System.Drawing.Point(4, 76);
            this.ListOfItemsLeft.Margin = new System.Windows.Forms.Padding(2);
            this.ListOfItemsLeft.Name = "ListOfItemsLeft";
            this.ListOfItemsLeft.ScrollAlwaysVisible = true;
            this.ListOfItemsLeft.Size = new System.Drawing.Size(535, 498);
            this.ListOfItemsLeft.TabIndex = 0;
            this.ListOfItemsLeft.SelectedIndexChanged += new System.EventHandler(this.ListOfItemsLeft_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 24);
            this.splitter1.Margin = new System.Windows.Forms.Padding(2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 615);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // ListOfItemsRight
            // 
            this.ListOfItemsRight.BackColor = System.Drawing.Color.White;
            this.ListOfItemsRight.ForeColor = System.Drawing.Color.Black;
            this.ListOfItemsRight.FormattingEnabled = true;
            this.ListOfItemsRight.HorizontalScrollbar = true;
            this.ListOfItemsRight.Location = new System.Drawing.Point(543, 76);
            this.ListOfItemsRight.Margin = new System.Windows.Forms.Padding(2);
            this.ListOfItemsRight.Name = "ListOfItemsRight";
            this.ListOfItemsRight.ScrollAlwaysVisible = true;
            this.ListOfItemsRight.Size = new System.Drawing.Size(519, 498);
            this.ListOfItemsRight.TabIndex = 4;
            // 
            // EscapeRight
            // 
            this.EscapeRight.Location = new System.Drawing.Point(1042, 53);
            this.EscapeRight.Margin = new System.Windows.Forms.Padding(2);
            this.EscapeRight.Name = "EscapeRight";
            this.EscapeRight.Size = new System.Drawing.Size(20, 20);
            this.EscapeRight.TabIndex = 8;
            this.EscapeRight.Text = "↑";
            this.EscapeRight.UseVisualStyleBackColor = true;
            this.EscapeRight.Click += new System.EventHandler(this.EscapeRight_Click);
            // 
            // EscapeLeft
            // 
            this.EscapeLeft.Location = new System.Drawing.Point(521, 54);
            this.EscapeLeft.Margin = new System.Windows.Forms.Padding(2);
            this.EscapeLeft.Name = "EscapeLeft";
            this.EscapeLeft.Size = new System.Drawing.Size(20, 20);
            this.EscapeLeft.TabIndex = 7;
            this.EscapeLeft.Text = "↑";
            this.EscapeLeft.UseVisualStyleBackColor = true;
            this.EscapeLeft.Click += new System.EventHandler(this.EscapeLeft_Click);
            // 
            // StartSearchingRight
            // 
            this.StartSearchingRight.BackColor = System.Drawing.Color.White;
            this.StartSearchingRight.ForeColor = System.Drawing.Color.Black;
            this.StartSearchingRight.Location = new System.Drawing.Point(1042, 578);
            this.StartSearchingRight.Margin = new System.Windows.Forms.Padding(2);
            this.StartSearchingRight.Name = "StartSearchingRight";
            this.StartSearchingRight.Size = new System.Drawing.Size(21, 20);
            this.StartSearchingRight.TabIndex = 10;
            this.StartSearchingRight.Text = "🔍";
            this.StartSearchingRight.UseVisualStyleBackColor = false;
            this.StartSearchingRight.Click += new System.EventHandler(this.StartSearchingRight_Click);
            // 
            // StartSearchingLeft
            // 
            this.StartSearchingLeft.Location = new System.Drawing.Point(520, 578);
            this.StartSearchingLeft.Margin = new System.Windows.Forms.Padding(2);
            this.StartSearchingLeft.Name = "StartSearchingLeft";
            this.StartSearchingLeft.Size = new System.Drawing.Size(21, 20);
            this.StartSearchingLeft.TabIndex = 12;
            this.StartSearchingLeft.Text = "🔍";
            this.StartSearchingLeft.UseVisualStyleBackColor = true;
            this.StartSearchingLeft.Click += new System.EventHandler(this.StartSearchingLeft_Click);
            // 
            // Copy
            // 
            this.Copy.BackColor = System.Drawing.Color.White;
            this.Copy.ForeColor = System.Drawing.Color.Black;
            this.Copy.Location = new System.Drawing.Point(4, 600);
            this.Copy.Margin = new System.Windows.Forms.Padding(2);
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(208, 34);
            this.Copy.TabIndex = 13;
            this.Copy.Text = "Copy";
            this.Copy.UseVisualStyleBackColor = false;
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // Move
            // 
            this.Move.BackColor = System.Drawing.Color.White;
            this.Move.Location = new System.Drawing.Point(218, 600);
            this.Move.Margin = new System.Windows.Forms.Padding(2);
            this.Move.Name = "Move";
            this.Move.Size = new System.Drawing.Size(208, 34);
            this.Move.TabIndex = 14;
            this.Move.Text = "Move";
            this.Move.UseVisualStyleBackColor = false;
            this.Move.Click += new System.EventHandler(this.Move_Click);
            // 
            // Edit
            // 
            this.Edit.BackColor = System.Drawing.Color.White;
            this.Edit.Location = new System.Drawing.Point(430, 600);
            this.Edit.Margin = new System.Windows.Forms.Padding(2);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(208, 34);
            this.Edit.TabIndex = 15;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = false;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.White;
            this.Delete.Location = new System.Drawing.Point(644, 600);
            this.Delete.Margin = new System.Windows.Forms.Padding(2);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(208, 34);
            this.Delete.TabIndex = 16;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Archive
            // 
            this.Archive.BackColor = System.Drawing.Color.White;
            this.Archive.Location = new System.Drawing.Point(856, 600);
            this.Archive.Margin = new System.Windows.Forms.Padding(2);
            this.Archive.Name = "Archive";
            this.Archive.Size = new System.Drawing.Size(208, 34);
            this.Archive.TabIndex = 17;
            this.Archive.Text = "Archive";
            this.Archive.UseVisualStyleBackColor = false;
            this.Archive.Click += new System.EventHandler(this.Archive_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.AllowMerge = false;
            this.menuStrip.BackColor = System.Drawing.Color.White;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.infoToolStripMenuInfoFirst,
            this.settingsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1073, 24);
            this.menuStrip.TabIndex = 18;
            this.menuStrip.Text = "menuStrip";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuFileFirst,
            this.toolStripMenuFileSecond});
            this.filesToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.filesToolStripMenuItem.Text = "Files";
            // 
            // toolStripMenuFileFirst
            // 
            this.toolStripMenuFileFirst.BackColor = System.Drawing.Color.White;
            this.toolStripMenuFileFirst.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuFileFirst.Name = "toolStripMenuFileFirst";
            this.toolStripMenuFileFirst.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuFileFirst.Text = "1";
            // 
            // toolStripMenuFileSecond
            // 
            this.toolStripMenuFileSecond.Name = "toolStripMenuFileSecond";
            this.toolStripMenuFileSecond.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuFileSecond.Text = "2";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuConfigurationFirst});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // toolStripMenuConfigurationFirst
            // 
            this.toolStripMenuConfigurationFirst.Name = "toolStripMenuConfigurationFirst";
            this.toolStripMenuConfigurationFirst.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuConfigurationFirst.Text = "1";
            // 
            // infoToolStripMenuInfoFirst
            // 
            this.infoToolStripMenuInfoFirst.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuInfoFirst});
            this.infoToolStripMenuInfoFirst.Name = "infoToolStripMenuInfoFirst";
            this.infoToolStripMenuInfoFirst.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuInfoFirst.Text = "Info";
            // 
            // toolStripMenuInfoFirst
            // 
            this.toolStripMenuInfoFirst.Name = "toolStripMenuInfoFirst";
            this.toolStripMenuInfoFirst.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuInfoFirst.Text = "1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // BackGroundForRename
            // 
            this.BackGroundForRename.BackColor = System.Drawing.SystemColors.Window;
            this.BackGroundForRename.Controls.Add(this.Cancel);
            this.BackGroundForRename.Controls.Add(this.TextOnPanel);
            this.BackGroundForRename.Controls.Add(this.EnteringNewName);
            this.BackGroundForRename.Controls.Add(this.Enter);
            this.BackGroundForRename.Location = new System.Drawing.Point(599, 332);
            this.BackGroundForRename.Margin = new System.Windows.Forms.Padding(2);
            this.BackGroundForRename.Name = "BackGroundForRename";
            this.BackGroundForRename.Size = new System.Drawing.Size(287, 80);
            this.BackGroundForRename.TabIndex = 19;
            this.BackGroundForRename.Visible = false;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(220, 43);
            this.Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(56, 28);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Visible = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // TextOnPanel
            // 
            this.TextOnPanel.AutoSize = true;
            this.TextOnPanel.Location = new System.Drawing.Point(8, 17);
            this.TextOnPanel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TextOnPanel.Name = "TextOnPanel";
            this.TextOnPanel.Size = new System.Drawing.Size(183, 13);
            this.TextOnPanel.TabIndex = 2;
            this.TextOnPanel.Text = "Enter a new name of selected object:";
            this.TextOnPanel.Visible = false;
            // 
            // EnteringNewName
            // 
            this.EnteringNewName.Location = new System.Drawing.Point(10, 52);
            this.EnteringNewName.Margin = new System.Windows.Forms.Padding(2);
            this.EnteringNewName.Name = "EnteringNewName";
            this.EnteringNewName.Size = new System.Drawing.Size(206, 20);
            this.EnteringNewName.TabIndex = 1;
            this.EnteringNewName.Visible = false;
            // 
            // Enter
            // 
            this.Enter.Location = new System.Drawing.Point(220, 10);
            this.Enter.Margin = new System.Windows.Forms.Padding(2);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(56, 28);
            this.Enter.TabIndex = 0;
            this.Enter.Text = "Enter";
            this.Enter.UseVisualStyleBackColor = true;
            this.Enter.Visible = false;
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // CurrentPathLeft
            // 
            this.CurrentPathLeft.BackColor = System.Drawing.Color.White;
            this.CurrentPathLeft.Enabled = false;
            this.CurrentPathLeft.ForeColor = System.Drawing.Color.Black;
            this.CurrentPathLeft.Location = new System.Drawing.Point(4, 55);
            this.CurrentPathLeft.Name = "CurrentPathLeft";
            this.CurrentPathLeft.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.CurrentPathLeft.Size = new System.Drawing.Size(518, 20);
            this.CurrentPathLeft.TabIndex = 20;
            this.CurrentPathLeft.Text = "";
            // 
            // CurrentPathRight
            // 
            this.CurrentPathRight.BackColor = System.Drawing.Color.White;
            this.CurrentPathRight.Enabled = false;
            this.CurrentPathRight.ForeColor = System.Drawing.Color.Black;
            this.CurrentPathRight.Location = new System.Drawing.Point(543, 55);
            this.CurrentPathRight.Name = "CurrentPathRight";
            this.CurrentPathRight.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.CurrentPathRight.Size = new System.Drawing.Size(498, 20);
            this.CurrentPathRight.TabIndex = 21;
            this.CurrentPathRight.Text = "";
            // 
            // SearchLeft
            // 
            this.SearchLeft.BackColor = System.Drawing.Color.White;
            this.SearchLeft.Location = new System.Drawing.Point(4, 578);
            this.SearchLeft.Name = "SearchLeft";
            this.SearchLeft.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.SearchLeft.Size = new System.Drawing.Size(422, 20);
            this.SearchLeft.TabIndex = 22;
            this.SearchLeft.Text = "";
            // 
            // SearchRight
            // 
            this.SearchRight.BackColor = System.Drawing.Color.White;
            this.SearchRight.Location = new System.Drawing.Point(543, 578);
            this.SearchRight.Name = "SearchRight";
            this.SearchRight.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.SearchRight.Size = new System.Drawing.Size(403, 20);
            this.SearchRight.TabIndex = 23;
            this.SearchRight.Text = "";
            // 
            // AmountToDrawLeft
            // 
            this.AmountToDrawLeft.BackColor = System.Drawing.Color.White;
            this.AmountToDrawLeft.Location = new System.Drawing.Point(430, 578);
            this.AmountToDrawLeft.Name = "AmountToDrawLeft";
            this.AmountToDrawLeft.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.AmountToDrawLeft.Size = new System.Drawing.Size(92, 20);
            this.AmountToDrawLeft.TabIndex = 24;
            this.AmountToDrawLeft.Text = "100";
            // 
            // AmountToDrawRight
            // 
            this.AmountToDrawRight.BackColor = System.Drawing.Color.White;
            this.AmountToDrawRight.Location = new System.Drawing.Point(949, 578);
            this.AmountToDrawRight.Name = "AmountToDrawRight";
            this.AmountToDrawRight.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.AmountToDrawRight.Size = new System.Drawing.Size(92, 20);
            this.AmountToDrawRight.TabIndex = 25;
            this.AmountToDrawRight.Text = "100";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1073, 639);
            this.Controls.Add(this.AmountToDrawRight);
            this.Controls.Add(this.AmountToDrawLeft);
            this.Controls.Add(this.SearchRight);
            this.Controls.Add(this.SearchLeft);
            this.Controls.Add(this.CurrentPathRight);
            this.Controls.Add(this.CurrentPathLeft);
            this.Controls.Add(this.BackGroundForRename);
            this.Controls.Add(this.Archive);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.Move);
            this.Controls.Add(this.Copy);
            this.Controls.Add(this.StartSearchingLeft);
            this.Controls.Add(this.StartSearchingRight);
            this.Controls.Add(this.EscapeRight);
            this.Controls.Add(this.EscapeLeft);
            this.Controls.Add(this.ListOfItemsRight);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.ListOfItemsLeft);
            this.Controls.Add(this.menuStrip);
            this.ForeColor = System.Drawing.Color.Black;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "File Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.BackGroundForRename.ResumeLayout(false);
            this.BackGroundForRename.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button EscapeLeft;
        private System.Windows.Forms.Button EscapeRight;
        private System.Windows.Forms.Panel BackGroundForRename;
        private System.Windows.Forms.Label TextOnPanel;
        private System.Windows.Forms.TextBox EnteringNewName;
        private System.Windows.Forms.Button Enter;
        private System.Windows.Forms.Button Cancel;
        public System.Windows.Forms.ListBox ListOfItemsLeft;
        public System.Windows.Forms.ListBox ListOfItemsRight;
        public System.Windows.Forms.Button Copy;
        public System.Windows.Forms.Button Move;
        public System.Windows.Forms.Button Edit;
        public System.Windows.Forms.Button Delete;
        public System.Windows.Forms.Button Archive;
        public System.Windows.Forms.MenuStrip menuStrip;
        public System.Windows.Forms.RichTextBox CurrentPathLeft;
        public System.Windows.Forms.RichTextBox CurrentPathRight;
        public System.Windows.Forms.RichTextBox SearchLeft;
        public System.Windows.Forms.RichTextBox SearchRight;
        public System.Windows.Forms.Button StartSearchingRight;
        public System.Windows.Forms.Button StartSearchingLeft;
        public System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem infoToolStripMenuInfoFirst;
        public System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuFileFirst;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuFileSecond;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuConfigurationFirst;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuInfoFirst;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RichTextBox AmountToDrawLeft;
        private System.Windows.Forms.RichTextBox AmountToDrawRight;
    }
}

