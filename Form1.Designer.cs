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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabDrivingAids = new System.Windows.Forms.TabPage();
            this.tabGraphicOptions = new System.Windows.Forms.TabPage();
            this.tabRaceConditions = new System.Windows.Forms.TabPage();
            this.tabSoundOptions = new System.Windows.Forms.TabPage();
            this.tabMiscellaneous = new System.Windows.Forms.TabPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabChat.SuspendLayout();
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
            this.tabControl1.Location = new System.Drawing.Point(4, -3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1130, 791);
            this.tabControl1.TabIndex = 0;
            // 
            // tabChat
            // 
            this.tabChat.Controls.Add(this.tableLayoutPanel1);
            this.tabChat.Location = new System.Drawing.Point(4, 33);
            this.tabChat.Name = "tabChat";
            this.tabChat.Padding = new System.Windows.Forms.Padding(3);
            this.tabChat.Size = new System.Drawing.Size(1122, 754);
            this.tabChat.TabIndex = 0;
            this.tabChat.Text = "Chat";
            this.tabChat.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.19355F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.80645F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1122, 742);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabDrivingAids
            // 
            this.tabDrivingAids.Location = new System.Drawing.Point(4, 33);
            this.tabDrivingAids.Name = "tabDrivingAids";
            this.tabDrivingAids.Padding = new System.Windows.Forms.Padding(3);
            this.tabDrivingAids.Size = new System.Drawing.Size(1122, 754);
            this.tabDrivingAids.TabIndex = 1;
            this.tabDrivingAids.Text = "Driving Aids";
            this.tabDrivingAids.UseVisualStyleBackColor = true;
            // 
            // tabGraphicOptions
            // 
            this.tabGraphicOptions.Location = new System.Drawing.Point(4, 33);
            this.tabGraphicOptions.Name = "tabGraphicOptions";
            this.tabGraphicOptions.Size = new System.Drawing.Size(1122, 754);
            this.tabGraphicOptions.TabIndex = 2;
            this.tabGraphicOptions.Text = "Graphic Options";
            this.tabGraphicOptions.UseVisualStyleBackColor = true;
            // 
            // tabRaceConditions
            // 
            this.tabRaceConditions.Location = new System.Drawing.Point(4, 33);
            this.tabRaceConditions.Name = "tabRaceConditions";
            this.tabRaceConditions.Size = new System.Drawing.Size(1122, 754);
            this.tabRaceConditions.TabIndex = 3;
            this.tabRaceConditions.Text = "Race Conditions";
            this.tabRaceConditions.UseVisualStyleBackColor = true;
            // 
            // tabSoundOptions
            // 
            this.tabSoundOptions.Location = new System.Drawing.Point(4, 33);
            this.tabSoundOptions.Name = "tabSoundOptions";
            this.tabSoundOptions.Size = new System.Drawing.Size(1122, 754);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 782);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "rFactor 2 Player editor";
            this.tabControl1.ResumeLayout(false);
            this.tabChat.ResumeLayout(false);
            this.tabChat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabChat;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tabDrivingAids;
        private System.Windows.Forms.TabPage tabGraphicOptions;
        private System.Windows.Forms.TabPage tabRaceConditions;
        private System.Windows.Forms.TabPage tabSoundOptions;
        private System.Windows.Forms.TabPage tabMiscellaneous;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

