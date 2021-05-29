namespace PS2Configr
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearUnusedFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.launchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.configureInPCSX2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenFoldertoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyStartupCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchGamebyUniqueIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchGamebyNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.launchConfigbyUniqueIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchConfigbyNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gList = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.rMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(470, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGameToolStripMenuItem,
            this.toolStripSeparator1,
            this.clearUnusedFilesToolStripMenuItem,
            this.toolStripSeparator5,
            this.reloadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addGameToolStripMenuItem
            // 
            this.addGameToolStripMenuItem.Name = "addGameToolStripMenuItem";
            this.addGameToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.addGameToolStripMenuItem.Text = "Add Game";
            this.addGameToolStripMenuItem.Click += new System.EventHandler(this.addGameToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(205, 6);
            // 
            // clearUnusedFilesToolStripMenuItem
            // 
            this.clearUnusedFilesToolStripMenuItem.Name = "clearUnusedFilesToolStripMenuItem";
            this.clearUnusedFilesToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.clearUnusedFilesToolStripMenuItem.Text = "Clear unused files/folders";
            this.clearUnusedFilesToolStripMenuItem.Click += new System.EventHandler(this.clearUnusedFilesToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(205, 6);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // rMenu
            // 
            this.rMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchToolStripMenuItem,
            this.toolStripSeparator2,
            this.optionsToolStripMenuItem1,
            this.configureInPCSX2ToolStripMenuItem,
            this.toolStripSeparator3,
            this.OpenFoldertoolStripMenuItem,
            this.copyStartupCommandToolStripMenuItem,
            this.toolStripSeparator4,
            this.removeToolStripMenuItem});
            this.rMenu.Name = "rMenu";
            this.rMenu.Size = new System.Drawing.Size(201, 154);
            // 
            // launchToolStripMenuItem
            // 
            this.launchToolStripMenuItem.Name = "launchToolStripMenuItem";
            this.launchToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.launchToolStripMenuItem.Text = "Launch";
            this.launchToolStripMenuItem.Click += new System.EventHandler(this.launchToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(197, 6);
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
            this.optionsToolStripMenuItem1.Text = "Options";
            this.optionsToolStripMenuItem1.Click += new System.EventHandler(this.optionsToolStripMenuItem1_Click);
            // 
            // configureInPCSX2ToolStripMenuItem
            // 
            this.configureInPCSX2ToolStripMenuItem.Name = "configureInPCSX2ToolStripMenuItem";
            this.configureInPCSX2ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.configureInPCSX2ToolStripMenuItem.Text = "Configure in PCSX2";
            this.configureInPCSX2ToolStripMenuItem.Click += new System.EventHandler(this.configureInPCSX2ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(197, 6);
            // 
            // OpenFoldertoolStripMenuItem
            // 
            this.OpenFoldertoolStripMenuItem.Name = "OpenFoldertoolStripMenuItem";
            this.OpenFoldertoolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.OpenFoldertoolStripMenuItem.Text = "Open config folder";
            this.OpenFoldertoolStripMenuItem.Click += new System.EventHandler(this.OpenFoldertoolStripMenuItem_Click);
            // 
            // copyStartupCommandToolStripMenuItem
            // 
            this.copyStartupCommandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchGamebyUniqueIdToolStripMenuItem,
            this.launchGamebyNameToolStripMenuItem,
            this.toolStripSeparator6,
            this.launchConfigbyUniqueIdToolStripMenuItem,
            this.launchConfigbyNameToolStripMenuItem});
            this.copyStartupCommandToolStripMenuItem.Name = "copyStartupCommandToolStripMenuItem";
            this.copyStartupCommandToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.copyStartupCommandToolStripMenuItem.Text = "Copy startup command";
            // 
            // launchGamebyUniqueIdToolStripMenuItem
            // 
            this.launchGamebyUniqueIdToolStripMenuItem.Name = "launchGamebyUniqueIdToolStripMenuItem";
            this.launchGamebyUniqueIdToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.launchGamebyUniqueIdToolStripMenuItem.Text = "Launch game (by UniqueId)";
            this.launchGamebyUniqueIdToolStripMenuItem.Click += new System.EventHandler(this.launchGamebyUniqueIdToolStripMenuItem_Click);
            // 
            // launchGamebyNameToolStripMenuItem
            // 
            this.launchGamebyNameToolStripMenuItem.Name = "launchGamebyNameToolStripMenuItem";
            this.launchGamebyNameToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.launchGamebyNameToolStripMenuItem.Text = "Launch game (by Name)";
            this.launchGamebyNameToolStripMenuItem.Click += new System.EventHandler(this.launchGamebyNameToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(222, 6);
            // 
            // launchConfigbyUniqueIdToolStripMenuItem
            // 
            this.launchConfigbyUniqueIdToolStripMenuItem.Name = "launchConfigbyUniqueIdToolStripMenuItem";
            this.launchConfigbyUniqueIdToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.launchConfigbyUniqueIdToolStripMenuItem.Text = "Launch config (by UniqueId)";
            this.launchConfigbyUniqueIdToolStripMenuItem.Click += new System.EventHandler(this.launchConfigbyUniqueIdToolStripMenuItem_Click);
            // 
            // launchConfigbyNameToolStripMenuItem
            // 
            this.launchConfigbyNameToolStripMenuItem.Name = "launchConfigbyNameToolStripMenuItem";
            this.launchConfigbyNameToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.launchConfigbyNameToolStripMenuItem.Text = "Launch config (by Name)";
            this.launchConfigbyNameToolStripMenuItem.Click += new System.EventHandler(this.launchConfigbyNameToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(197, 6);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // gList
            // 
            this.gList.AllowDrop = true;
            this.gList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gList.FullRowSelect = true;
            this.gList.HideSelection = false;
            this.gList.Location = new System.Drawing.Point(14, 31);
            this.gList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gList.MultiSelect = false;
            this.gList.Name = "gList";
            this.gList.Size = new System.Drawing.Size(442, 452);
            this.gList.TabIndex = 2;
            this.gList.UseCompatibleStateImageBehavior = false;
            this.gList.View = System.Windows.Forms.View.List;
            this.gList.SelectedIndexChanged += new System.EventHandler(this.gList_SelectedIndexChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 497);
            this.Controls.Add(this.gList);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PS2Configr by Barroca";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.rMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip rMenu;
        private System.Windows.Forms.ListView gList;
        private System.Windows.Forms.ToolStripMenuItem launchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem configureInPCSX2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearUnusedFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem copyStartupCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchGamebyUniqueIdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchGamebyNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem launchConfigbyUniqueIdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchConfigbyNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem OpenFoldertoolStripMenuItem;
    }
}

