namespace S397ConfigEditor
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
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.setUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rFactorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leMansUltimateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Location = new System.Drawing.Point(20, 46);
            this.TabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(1365, 1046);
            this.TabControl1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setUpToolStripMenuItem,
            this.toolStripMenuItemFile,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1411, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuFileOpen,
            this.toolStripMenuFileSave,
            this.toolStripMenuFileExit});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(54, 29);
            this.toolStripMenuItemFile.Text = "File";
            // 
            // toolStripMenuFileOpen
            // 
            this.toolStripMenuFileOpen.Name = "toolStripMenuFileOpen";
            this.toolStripMenuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuFileOpen.Size = new System.Drawing.Size(362, 34);
            this.toolStripMenuFileOpen.Text = "Open Player format file";
            this.toolStripMenuFileOpen.ToolTipText = "Open a file that lays out Player.JSON";
            this.toolStripMenuFileOpen.Click += new System.EventHandler(this.FileMenuItemOpenClick);
            // 
            // toolStripMenuFileSave
            // 
            this.toolStripMenuFileSave.Name = "toolStripMenuFileSave";
            this.toolStripMenuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuFileSave.Size = new System.Drawing.Size(362, 34);
            this.toolStripMenuFileSave.Text = "Save as";
            this.toolStripMenuFileSave.ToolTipText = "Save Player.JSON";
            this.toolStripMenuFileSave.Click += new System.EventHandler(this.FileMenuItemSaveClick);
            // 
            // toolStripMenuFileExit
            // 
            this.toolStripMenuFileExit.Name = "toolStripMenuFileExit";
            this.toolStripMenuFileExit.Size = new System.Drawing.Size(362, 34);
            this.toolStripMenuFileExit.Text = "Exit";
            this.toolStripMenuFileExit.Click += new System.EventHandler(this.FileMenuItemExitClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.HelpMenuItemAboutClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "JSON";
            this.openFileDialog.Filter = "JSON files (*.JSON)|*.JSON|All files (*.*)|*.*";
            this.openFileDialog.InitialDirectory = ".";
            this.openFileDialog.ReadOnlyChecked = true;
            this.openFileDialog.Title = "Open JSON file that lays out Player.JSON";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "JSON";
            // 
            // setUpToolStripMenuItem
            // 
            this.setUpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rFactorToolStripMenuItem,
            this.leMansUltimateToolStripMenuItem});
            this.setUpToolStripMenuItem.Name = "setUpToolStripMenuItem";
            this.setUpToolStripMenuItem.Size = new System.Drawing.Size(79, 29);
            this.setUpToolStripMenuItem.Text = "Set up";
            // 
            // rFactorToolStripMenuItem
            // 
            this.rFactorToolStripMenuItem.Name = "rFactorToolStripMenuItem";
            this.rFactorToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.rFactorToolStripMenuItem.Text = "rFactor";
            this.rFactorToolStripMenuItem.Click += new System.EventHandler(this.rFactorToolStripMenuItem_Click);
            // 
            // leMansUltimateToolStripMenuItem
            // 
            this.leMansUltimateToolStripMenuItem.Name = "leMansUltimateToolStripMenuItem";
            this.leMansUltimateToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.leMansUltimateToolStripMenuItem.Text = "Le Mans Ultimate";
            this.leMansUltimateToolStripMenuItem.Click += new System.EventHandler(this.leMansUltimateToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1411, 1102);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "rFactor 2 Player editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl TabControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFileSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFileExit;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem setUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rFactorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leMansUltimateToolStripMenuItem;
    }
}

