namespace ScoobyNET
{
    partial class MainWindow
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
            this.hook_button = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hooked_lbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Health_chkbx = new System.Windows.Forms.CheckBox();
            this.FoodDisplay_chkbx = new System.Windows.Forms.CheckBox();
            this.Stats_grp = new System.Windows.Forms.GroupBox();
            this.InputDisplay_chkbx = new System.Windows.Forms.CheckBox();
            this.Collectibles_grp = new System.Windows.Forms.GroupBox();
            this.FoodMubber_chkbx = new System.Windows.Forms.CheckBox();
            this.CostumeDisplay_chkbx = new System.Windows.Forms.CheckBox();
            this.WriteFile_chkbx = new System.Windows.Forms.CheckBox();
            this.TrapDisplay_chkbx = new System.Windows.Forms.CheckBox();
            this.ClueDisplay_chkbx = new System.Windows.Forms.CheckBox();
            this.LevelDisplay_chkbx = new System.Windows.Forms.CheckBox();
            this.POSDisplay_chkbx = new System.Windows.Forms.CheckBox();
            this.Misc_grp = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.Stats_grp.SuspendLayout();
            this.Collectibles_grp.SuspendLayout();
            this.Misc_grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // hook_button
            // 
            this.hook_button.Location = new System.Drawing.Point(16, 74);
            this.hook_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hook_button.Name = "hook_button";
            this.hook_button.Size = new System.Drawing.Size(603, 23);
            this.hook_button.TabIndex = 0;
            this.hook_button.Text = "Hook";
            this.hook_button.UseVisualStyleBackColor = true;
            this.hook_button.Click += new System.EventHandler(this.hook_button_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(632, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // hooked_lbl
            // 
            this.hooked_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hooked_lbl.Location = new System.Drawing.Point(9, 41);
            this.hooked_lbl.Name = "hooked_lbl";
            this.hooked_lbl.Size = new System.Drawing.Size(610, 20);
            this.hooked_lbl.TabIndex = 4;
            this.hooked_lbl.Text = "Cannot hook to Dolphin, the process is not running.";
            this.hooked_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 233);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Health_chkbx
            // 
            this.Health_chkbx.AutoSize = true;
            this.Health_chkbx.Location = new System.Drawing.Point(7, 20);
            this.Health_chkbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Health_chkbx.Name = "Health_chkbx";
            this.Health_chkbx.Size = new System.Drawing.Size(128, 20);
            this.Health_chkbx.TabIndex = 6;
            this.Health_chkbx.Text = "Scooby\'s Health";
            this.Health_chkbx.UseVisualStyleBackColor = true;
            // 
            // FoodDisplay_chkbx
            // 
            this.FoodDisplay_chkbx.AutoSize = true;
            this.FoodDisplay_chkbx.Location = new System.Drawing.Point(7, 20);
            this.FoodDisplay_chkbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FoodDisplay_chkbx.Name = "FoodDisplay_chkbx";
            this.FoodDisplay_chkbx.Size = new System.Drawing.Size(110, 20);
            this.FoodDisplay_chkbx.TabIndex = 7;
            this.FoodDisplay_chkbx.Text = "Food Display";
            this.FoodDisplay_chkbx.UseVisualStyleBackColor = true;
            // 
            // Stats_grp
            // 
            this.Stats_grp.Controls.Add(this.InputDisplay_chkbx);
            this.Stats_grp.Controls.Add(this.Collectibles_grp);
            this.Stats_grp.Controls.Add(this.LevelDisplay_chkbx);
            this.Stats_grp.Controls.Add(this.POSDisplay_chkbx);
            this.Stats_grp.Controls.Add(this.Health_chkbx);
            this.Stats_grp.Location = new System.Drawing.Point(16, 103);
            this.Stats_grp.Margin = new System.Windows.Forms.Padding(4);
            this.Stats_grp.Name = "Stats_grp";
            this.Stats_grp.Padding = new System.Windows.Forms.Padding(4);
            this.Stats_grp.Size = new System.Drawing.Size(603, 262);
            this.Stats_grp.TabIndex = 8;
            this.Stats_grp.TabStop = false;
            this.Stats_grp.Text = "Stats";
            // 
            // InputDisplay_chkbx
            // 
            this.InputDisplay_chkbx.AutoSize = true;
            this.InputDisplay_chkbx.Location = new System.Drawing.Point(7, 95);
            this.InputDisplay_chkbx.Name = "InputDisplay_chkbx";
            this.InputDisplay_chkbx.Size = new System.Drawing.Size(106, 20);
            this.InputDisplay_chkbx.TabIndex = 14;
            this.InputDisplay_chkbx.Text = "Input Display";
            this.InputDisplay_chkbx.UseVisualStyleBackColor = true;
            // 
            // Collectibles_grp
            // 
            this.Collectibles_grp.Controls.Add(this.Misc_grp);
            this.Collectibles_grp.Controls.Add(this.FoodMubber_chkbx);
            this.Collectibles_grp.Controls.Add(this.CostumeDisplay_chkbx);
            this.Collectibles_grp.Controls.Add(this.TrapDisplay_chkbx);
            this.Collectibles_grp.Controls.Add(this.ClueDisplay_chkbx);
            this.Collectibles_grp.Controls.Add(this.FoodDisplay_chkbx);
            this.Collectibles_grp.Location = new System.Drawing.Point(138, 0);
            this.Collectibles_grp.Name = "Collectibles_grp";
            this.Collectibles_grp.Size = new System.Drawing.Size(465, 262);
            this.Collectibles_grp.TabIndex = 13;
            this.Collectibles_grp.TabStop = false;
            this.Collectibles_grp.Text = "Collectibles";
            // 
            // FoodMubber_chkbx
            // 
            this.FoodMubber_chkbx.AutoSize = true;
            this.FoodMubber_chkbx.Location = new System.Drawing.Point(17, 45);
            this.FoodMubber_chkbx.Name = "FoodMubber_chkbx";
            this.FoodMubber_chkbx.Size = new System.Drawing.Size(151, 20);
            this.FoodMubber_chkbx.TabIndex = 14;
            this.FoodMubber_chkbx.Text = "Food Mubber Totals";
            this.FoodMubber_chkbx.UseVisualStyleBackColor = true;
            // 
            // CostumeDisplay_chkbx
            // 
            this.CostumeDisplay_chkbx.AutoSize = true;
            this.CostumeDisplay_chkbx.Location = new System.Drawing.Point(7, 120);
            this.CostumeDisplay_chkbx.Name = "CostumeDisplay_chkbx";
            this.CostumeDisplay_chkbx.Size = new System.Drawing.Size(161, 20);
            this.CostumeDisplay_chkbx.TabIndex = 13;
            this.CostumeDisplay_chkbx.Text = "Costume Coin Display";
            this.CostumeDisplay_chkbx.UseVisualStyleBackColor = true;
            // 
            // WriteFile_chkbx
            // 
            this.WriteFile_chkbx.AutoSize = true;
            this.WriteFile_chkbx.Location = new System.Drawing.Point(6, 20);
            this.WriteFile_chkbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WriteFile_chkbx.Name = "WriteFile_chkbx";
            this.WriteFile_chkbx.Size = new System.Drawing.Size(117, 20);
            this.WriteFile_chkbx.TabIndex = 10;
            this.WriteFile_chkbx.Text = "Write to text file";
            this.WriteFile_chkbx.UseVisualStyleBackColor = true;
            // 
            // TrapDisplay_chkbx
            // 
            this.TrapDisplay_chkbx.AutoSize = true;
            this.TrapDisplay_chkbx.Location = new System.Drawing.Point(7, 95);
            this.TrapDisplay_chkbx.Name = "TrapDisplay_chkbx";
            this.TrapDisplay_chkbx.Size = new System.Drawing.Size(107, 20);
            this.TrapDisplay_chkbx.TabIndex = 12;
            this.TrapDisplay_chkbx.Text = "Trap Display";
            this.TrapDisplay_chkbx.UseVisualStyleBackColor = true;
            // 
            // ClueDisplay_chkbx
            // 
            this.ClueDisplay_chkbx.AutoSize = true;
            this.ClueDisplay_chkbx.Location = new System.Drawing.Point(7, 70);
            this.ClueDisplay_chkbx.Name = "ClueDisplay_chkbx";
            this.ClueDisplay_chkbx.Size = new System.Drawing.Size(105, 20);
            this.ClueDisplay_chkbx.TabIndex = 11;
            this.ClueDisplay_chkbx.Text = "Clue Display";
            this.ClueDisplay_chkbx.UseVisualStyleBackColor = true;
            // 
            // LevelDisplay_chkbx
            // 
            this.LevelDisplay_chkbx.AutoSize = true;
            this.LevelDisplay_chkbx.Location = new System.Drawing.Point(7, 45);
            this.LevelDisplay_chkbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LevelDisplay_chkbx.Name = "LevelDisplay_chkbx";
            this.LevelDisplay_chkbx.Size = new System.Drawing.Size(111, 20);
            this.LevelDisplay_chkbx.TabIndex = 9;
            this.LevelDisplay_chkbx.Text = "Level Display";
            this.LevelDisplay_chkbx.UseVisualStyleBackColor = true;
            // 
            // POSDisplay_chkbx
            // 
            this.POSDisplay_chkbx.AutoSize = true;
            this.POSDisplay_chkbx.Location = new System.Drawing.Point(7, 70);
            this.POSDisplay_chkbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.POSDisplay_chkbx.Name = "POSDisplay_chkbx";
            this.POSDisplay_chkbx.Size = new System.Drawing.Size(126, 20);
            this.POSDisplay_chkbx.TabIndex = 8;
            this.POSDisplay_chkbx.Text = "Position Display";
            this.POSDisplay_chkbx.UseVisualStyleBackColor = true;
            // 
            // Misc_grp
            // 
            this.Misc_grp.Controls.Add(this.WriteFile_chkbx);
            this.Misc_grp.Controls.Add(this.button1);
            this.Misc_grp.Location = new System.Drawing.Point(175, 0);
            this.Misc_grp.Name = "Misc_grp";
            this.Misc_grp.Size = new System.Drawing.Size(290, 262);
            this.Misc_grp.TabIndex = 15;
            this.Misc_grp.TabStop = false;
            this.Misc_grp.Text = "Misc.";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 378);
            this.Controls.Add(this.Stats_grp);
            this.Controls.Add(this.hooked_lbl);
            this.Controls.Add(this.hook_button);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindow";
            this.Text = "Unmasked Tool";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Stats_grp.ResumeLayout(false);
            this.Stats_grp.PerformLayout();
            this.Collectibles_grp.ResumeLayout(false);
            this.Collectibles_grp.PerformLayout();
            this.Misc_grp.ResumeLayout(false);
            this.Misc_grp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button hook_button;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label hooked_lbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.CheckBox Health_chkbx;
        private System.Windows.Forms.CheckBox FoodDisplay_chkbx;
        private System.Windows.Forms.GroupBox Stats_grp;
        private System.Windows.Forms.CheckBox WriteFile_chkbx;
        private System.Windows.Forms.CheckBox LevelDisplay_chkbx;
        private System.Windows.Forms.CheckBox POSDisplay_chkbx;
        private System.Windows.Forms.CheckBox TrapDisplay_chkbx;
        private System.Windows.Forms.CheckBox ClueDisplay_chkbx;
        private System.Windows.Forms.GroupBox Collectibles_grp;
        private System.Windows.Forms.CheckBox CostumeDisplay_chkbx;
        private System.Windows.Forms.CheckBox InputDisplay_chkbx;
        private System.Windows.Forms.CheckBox FoodMubber_chkbx;
        private System.Windows.Forms.GroupBox Misc_grp;
    }
}

