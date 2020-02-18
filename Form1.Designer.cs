namespace WindowsFormsApp1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabChat = new System.Windows.Forms.TabPage();
            this.tabDrivingAids = new System.Windows.Forms.TabPage();
            this.tabGraphicOptions = new System.Windows.Forms.TabPage();
            this.tabRaceConditions = new System.Windows.Forms.TabPage();
            this.tabSoundOptions = new System.Windows.Forms.TabPage();
            this.tabMiscellaneous = new System.Windows.Forms.TabPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanelChat = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelDrivingAids = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelGraphicOptions = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelRaceConditions = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelSoundOptions = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.tabChat.SuspendLayout();
            this.tabDrivingAids.SuspendLayout();
            this.tabGraphicOptions.SuspendLayout();
            this.tabRaceConditions.SuspendLayout();
            this.tabSoundOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabChat);
            this.tabControl1.Controls.Add(this.tabDrivingAids);
            this.tabControl1.Controls.Add(this.tabGraphicOptions);
            this.tabControl1.Controls.Add(this.tabRaceConditions);
            this.tabControl1.Controls.Add(this.tabSoundOptions);
            this.tabControl1.Controls.Add(this.tabMiscellaneous);
            this.tabControl1.Location = new System.Drawing.Point(48, 58);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1645, 1253);
            this.tabControl1.TabIndex = 0;
            // 
            // tabChat
            // 
            this.tabChat.Controls.Add(this.tableLayoutPanelChat);
            this.tabChat.Location = new System.Drawing.Point(4, 33);
            this.tabChat.Name = "tabChat";
            this.tabChat.Padding = new System.Windows.Forms.Padding(3);
            this.tabChat.Size = new System.Drawing.Size(1618, 1111);
            this.tabChat.TabIndex = 0;
            this.tabChat.Text = "Chat";
            this.tabChat.UseVisualStyleBackColor = true;
            // 
            // tabDrivingAids
            // 
            this.tabDrivingAids.Controls.Add(this.tableLayoutPanelDrivingAids);
            this.tabDrivingAids.Location = new System.Drawing.Point(4, 33);
            this.tabDrivingAids.Name = "tabDrivingAids";
            this.tabDrivingAids.Padding = new System.Windows.Forms.Padding(3);
            this.tabDrivingAids.Size = new System.Drawing.Size(1618, 1111);
            this.tabDrivingAids.TabIndex = 1;
            this.tabDrivingAids.Text = "Driving Aids";
            this.tabDrivingAids.UseVisualStyleBackColor = true;
            // 
            // tabGraphicOptions
            // 
            this.tabGraphicOptions.Controls.Add(this.tableLayoutPanelGraphicOptions);
            this.tabGraphicOptions.Location = new System.Drawing.Point(4, 33);
            this.tabGraphicOptions.Name = "tabGraphicOptions";
            this.tabGraphicOptions.Size = new System.Drawing.Size(1637, 1216);
            this.tabGraphicOptions.TabIndex = 2;
            this.tabGraphicOptions.Text = "Graphic Options";
            this.tabGraphicOptions.UseVisualStyleBackColor = true;
            // 
            // tabRaceConditions
            // 
            this.tabRaceConditions.Controls.Add(this.tableLayoutPanelRaceConditions);
            this.tabRaceConditions.Location = new System.Drawing.Point(4, 33);
            this.tabRaceConditions.Name = "tabRaceConditions";
            this.tabRaceConditions.Size = new System.Drawing.Size(1637, 1216);
            this.tabRaceConditions.TabIndex = 3;
            this.tabRaceConditions.Text = "Race Conditions";
            this.tabRaceConditions.UseVisualStyleBackColor = true;
            // 
            // tabSoundOptions
            // 
            this.tabSoundOptions.Controls.Add(this.tableLayoutPanelSoundOptions);
            this.tabSoundOptions.Location = new System.Drawing.Point(4, 33);
            this.tabSoundOptions.Name = "tabSoundOptions";
            this.tabSoundOptions.Size = new System.Drawing.Size(1618, 1111);
            this.tabSoundOptions.TabIndex = 4;
            this.tabSoundOptions.Text = "Sound Options";
            this.tabSoundOptions.UseVisualStyleBackColor = true;
            // 
            // tabMiscellaneous
            // 
            this.tabMiscellaneous.Location = new System.Drawing.Point(4, 33);
            this.tabMiscellaneous.Name = "tabMiscellaneous";
            this.tabMiscellaneous.Size = new System.Drawing.Size(1122, 754);
            this.tabMiscellaneous.TabIndex = 5;
            this.tabMiscellaneous.Text = "Miscellaneous";
            this.tabMiscellaneous.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelChat
            // 
            this.tableLayoutPanelChat.ColumnCount = 2;
            this.tableLayoutPanelChat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelChat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelChat.Location = new System.Drawing.Point(25, 29);
            this.tableLayoutPanelChat.Name = "tableLayoutPanelChat";
            this.tableLayoutPanelChat.RowCount = 12;
            this.tableLayoutPanelChat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelChat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelChat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelChat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelChat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelChat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelChat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelChat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelChat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelChat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelChat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelChat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelChat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelChat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelChat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelChat.Size = new System.Drawing.Size(669, 548);
            this.tableLayoutPanelChat.TabIndex = 0;
            // 
            // tableLayoutPanelDrivingAids
            // 
            this.tableLayoutPanelDrivingAids.ColumnCount = 4;
            this.tableLayoutPanelDrivingAids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelDrivingAids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelDrivingAids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelDrivingAids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelDrivingAids.Location = new System.Drawing.Point(27, 31);
            this.tableLayoutPanelDrivingAids.Name = "tableLayoutPanelDrivingAids";
            this.tableLayoutPanelDrivingAids.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tableLayoutPanelDrivingAids.RowCount = 17;
            this.tableLayoutPanelDrivingAids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanelDrivingAids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanelDrivingAids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanelDrivingAids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanelDrivingAids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanelDrivingAids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanelDrivingAids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanelDrivingAids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanelDrivingAids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanelDrivingAids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanelDrivingAids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanelDrivingAids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanelDrivingAids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanelDrivingAids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanelDrivingAids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanelDrivingAids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanelDrivingAids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352F));
            this.tableLayoutPanelDrivingAids.Size = new System.Drawing.Size(1052, 796);
            this.tableLayoutPanelDrivingAids.TabIndex = 0;
            // 
            // tableLayoutPanelGraphicOptions
            // 
            this.tableLayoutPanelGraphicOptions.ColumnCount = 12;
            this.tableLayoutPanelGraphicOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelGraphicOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelGraphicOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelGraphicOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelGraphicOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelGraphicOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelGraphicOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelGraphicOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelGraphicOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelGraphicOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelGraphicOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelGraphicOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelGraphicOptions.Location = new System.Drawing.Point(24, 37);
            this.tableLayoutPanelGraphicOptions.Name = "tableLayoutPanelGraphicOptions";
            this.tableLayoutPanelGraphicOptions.RowCount = 21;
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelGraphicOptions.Size = new System.Drawing.Size(1576, 1127);
            this.tableLayoutPanelGraphicOptions.TabIndex = 0;
            // 
            // tableLayoutPanelRaceConditions
            // 
            this.tableLayoutPanelRaceConditions.ColumnCount = 12;
            this.tableLayoutPanelRaceConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelRaceConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelRaceConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelRaceConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelRaceConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelRaceConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelRaceConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelRaceConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelRaceConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelRaceConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelRaceConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelRaceConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanelRaceConditions.Location = new System.Drawing.Point(29, 36);
            this.tableLayoutPanelRaceConditions.Name = "tableLayoutPanelRaceConditions";
            this.tableLayoutPanelRaceConditions.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.tableLayoutPanelRaceConditions.RowCount = 21;
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761906F));
            this.tableLayoutPanelRaceConditions.Size = new System.Drawing.Size(1573, 1163);
            this.tableLayoutPanelRaceConditions.TabIndex = 1;
            // 
            // tableLayoutPanelSoundOptions
            // 
            this.tableLayoutPanelSoundOptions.ColumnCount = 4;
            this.tableLayoutPanelSoundOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSoundOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSoundOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSoundOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSoundOptions.Location = new System.Drawing.Point(22, 22);
            this.tableLayoutPanelSoundOptions.Name = "tableLayoutPanelSoundOptions";
            this.tableLayoutPanelSoundOptions.RowCount = 19;
            this.tableLayoutPanelSoundOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanelSoundOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanelSoundOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanelSoundOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanelSoundOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanelSoundOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanelSoundOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanelSoundOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanelSoundOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanelSoundOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanelSoundOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanelSoundOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanelSoundOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanelSoundOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanelSoundOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanelSoundOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanelSoundOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanelSoundOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanelSoundOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanelSoundOptions.Size = new System.Drawing.Size(1539, 908);
            this.tableLayoutPanelSoundOptions.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1724, 1323);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "rFactor 2 Player editor";
            this.tabControl1.ResumeLayout(false);
            this.tabChat.ResumeLayout(false);
            this.tabDrivingAids.ResumeLayout(false);
            this.tabGraphicOptions.ResumeLayout(false);
            this.tabRaceConditions.ResumeLayout(false);
            this.tabSoundOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabChat;
        private System.Windows.Forms.TabPage tabDrivingAids;
        private System.Windows.Forms.TabPage tabGraphicOptions;
        private System.Windows.Forms.TabPage tabRaceConditions;
        private System.Windows.Forms.TabPage tabSoundOptions;
        private System.Windows.Forms.TabPage tabMiscellaneous;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelChat;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDrivingAids;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGraphicOptions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRaceConditions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSoundOptions;
    }
}

