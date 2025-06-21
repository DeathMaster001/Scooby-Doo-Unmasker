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
            this.clicktoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writevalue_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hooked_lbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.HealthDisplay_chkbx = new System.Windows.Forms.CheckBox();
            this.FoodDisplay_chkbx = new System.Windows.Forms.CheckBox();
            this.Stats_grp = new System.Windows.Forms.GroupBox();
            this.PercentageDisplay_chkbx = new System.Windows.Forms.CheckBox();
            this.Collectibles_grp = new System.Windows.Forms.GroupBox();
            this.Misc_grp = new System.Windows.Forms.GroupBox();
            this.levelselect_lbl2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.WriteFile_chkbx = new System.Windows.Forms.CheckBox();
            this.FoodMubber_chkbx = new System.Windows.Forms.CheckBox();
            this.CostumeDisplay_chkbx = new System.Windows.Forms.CheckBox();
            this.TrapDisplay_chkbx = new System.Windows.Forms.CheckBox();
            this.ClueDisplay_chkbx = new System.Windows.Forms.CheckBox();
            this.MubberDisplay_chkbx = new System.Windows.Forms.CheckBox();
            this.InputDisplay_chkbx = new System.Windows.Forms.CheckBox();
            this.LevelDisplay_chkbx = new System.Windows.Forms.CheckBox();
            this.POSDisplay_chkbx = new System.Windows.Forms.CheckBox();
            this.SelectCollectibles_chkbx = new System.Windows.Forms.CheckBox();
            this.SelectStats_chkbx = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.Stats_grp.SuspendLayout();
            this.Collectibles_grp.SuspendLayout();
            this.Misc_grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // hook_button
            // 
            this.hook_button.Location = new System.Drawing.Point(12, 60);
            this.hook_button.Margin = new System.Windows.Forms.Padding(2);
            this.hook_button.Name = "hook_button";
            this.hook_button.Size = new System.Drawing.Size(500, 19);
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
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(519, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clicktoolStripMenuItem1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // clicktoolStripMenuItem1
            // 
            this.clicktoolStripMenuItem1.Name = "clicktoolStripMenuItem1";
            this.clicktoolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.clicktoolStripMenuItem1.Text = "Click";
            this.clicktoolStripMenuItem1.Click += new System.EventHandler(this.clicktoolStripMenuItem1_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.writevalue_ToolStripMenuItem,
            this.advancedModeToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // writevalue_ToolStripMenuItem
            // 
            this.writevalue_ToolStripMenuItem.Name = "writevalue_ToolStripMenuItem";
            this.writevalue_ToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.writevalue_ToolStripMenuItem.Text = "Simple Mode";
            this.writevalue_ToolStripMenuItem.Click += new System.EventHandler(this.simplemode_ToolStripMenuItem_Click);
            // 
            // advancedModeToolStripMenuItem
            // 
            this.advancedModeToolStripMenuItem.Name = "advancedModeToolStripMenuItem";
            this.advancedModeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.advancedModeToolStripMenuItem.Text = "Advanced Mode";
            this.advancedModeToolStripMenuItem.Click += new System.EventHandler(this.advancedModeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // hooked_lbl
            // 
            this.hooked_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hooked_lbl.Location = new System.Drawing.Point(7, 33);
            this.hooked_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hooked_lbl.Name = "hooked_lbl";
            this.hooked_lbl.Size = new System.Drawing.Size(505, 16);
            this.hooked_lbl.TabIndex = 4;
            this.hooked_lbl.Text = "Cannot hook to Dolphin, the process is not running.";
            this.hooked_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 237);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 19);
            this.button1.TabIndex = 5;
            this.button1.Text = "Dev Stuff";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HealthDisplay_chkbx
            // 
            this.HealthDisplay_chkbx.AutoSize = true;
            this.HealthDisplay_chkbx.Location = new System.Drawing.Point(8, 17);
            this.HealthDisplay_chkbx.Margin = new System.Windows.Forms.Padding(2);
            this.HealthDisplay_chkbx.Name = "HealthDisplay_chkbx";
            this.HealthDisplay_chkbx.Size = new System.Drawing.Size(103, 17);
            this.HealthDisplay_chkbx.TabIndex = 6;
            this.HealthDisplay_chkbx.Text = "Scooby\'s Health";
            this.HealthDisplay_chkbx.UseVisualStyleBackColor = true;
            // 
            // FoodDisplay_chkbx
            // 
            this.FoodDisplay_chkbx.AutoSize = true;
            this.FoodDisplay_chkbx.Location = new System.Drawing.Point(8, 17);
            this.FoodDisplay_chkbx.Margin = new System.Windows.Forms.Padding(2);
            this.FoodDisplay_chkbx.Name = "FoodDisplay_chkbx";
            this.FoodDisplay_chkbx.Size = new System.Drawing.Size(61, 17);
            this.FoodDisplay_chkbx.TabIndex = 7;
            this.FoodDisplay_chkbx.Text = "Food(s)";
            this.FoodDisplay_chkbx.UseVisualStyleBackColor = true;
            // 
            // Stats_grp
            // 
            this.Stats_grp.Controls.Add(this.SelectStats_chkbx);
            this.Stats_grp.Controls.Add(this.PercentageDisplay_chkbx);
            this.Stats_grp.Controls.Add(this.Collectibles_grp);
            this.Stats_grp.Controls.Add(this.MubberDisplay_chkbx);
            this.Stats_grp.Controls.Add(this.InputDisplay_chkbx);
            this.Stats_grp.Controls.Add(this.LevelDisplay_chkbx);
            this.Stats_grp.Controls.Add(this.POSDisplay_chkbx);
            this.Stats_grp.Controls.Add(this.HealthDisplay_chkbx);
            this.Stats_grp.Location = new System.Drawing.Point(12, 84);
            this.Stats_grp.Name = "Stats_grp";
            this.Stats_grp.Size = new System.Drawing.Size(500, 261);
            this.Stats_grp.TabIndex = 8;
            this.Stats_grp.TabStop = false;
            this.Stats_grp.Text = "Stats";
            // 
            // PercentageDisplay_chkbx
            // 
            this.PercentageDisplay_chkbx.AutoSize = true;
            this.PercentageDisplay_chkbx.Location = new System.Drawing.Point(8, 77);
            this.PercentageDisplay_chkbx.Name = "PercentageDisplay_chkbx";
            this.PercentageDisplay_chkbx.Size = new System.Drawing.Size(112, 17);
            this.PercentageDisplay_chkbx.TabIndex = 16;
            this.PercentageDisplay_chkbx.Text = "Game Progression";
            this.PercentageDisplay_chkbx.UseVisualStyleBackColor = true;
            // 
            // Collectibles_grp
            // 
            this.Collectibles_grp.Controls.Add(this.SelectCollectibles_chkbx);
            this.Collectibles_grp.Controls.Add(this.Misc_grp);
            this.Collectibles_grp.Controls.Add(this.FoodMubber_chkbx);
            this.Collectibles_grp.Controls.Add(this.CostumeDisplay_chkbx);
            this.Collectibles_grp.Controls.Add(this.TrapDisplay_chkbx);
            this.Collectibles_grp.Controls.Add(this.ClueDisplay_chkbx);
            this.Collectibles_grp.Controls.Add(this.FoodDisplay_chkbx);
            this.Collectibles_grp.Location = new System.Drawing.Point(131, 0);
            this.Collectibles_grp.Margin = new System.Windows.Forms.Padding(2);
            this.Collectibles_grp.Name = "Collectibles_grp";
            this.Collectibles_grp.Padding = new System.Windows.Forms.Padding(2);
            this.Collectibles_grp.Size = new System.Drawing.Size(368, 261);
            this.Collectibles_grp.TabIndex = 13;
            this.Collectibles_grp.TabStop = false;
            this.Collectibles_grp.Text = "Collectibles";
            // 
            // Misc_grp
            // 
            this.Misc_grp.Controls.Add(this.levelselect_lbl2);
            this.Misc_grp.Controls.Add(this.comboBox1);
            this.Misc_grp.Controls.Add(this.WriteFile_chkbx);
            this.Misc_grp.Controls.Add(this.button1);
            this.Misc_grp.Location = new System.Drawing.Point(135, 0);
            this.Misc_grp.Margin = new System.Windows.Forms.Padding(2);
            this.Misc_grp.Name = "Misc_grp";
            this.Misc_grp.Padding = new System.Windows.Forms.Padding(2);
            this.Misc_grp.Size = new System.Drawing.Size(234, 261);
            this.Misc_grp.TabIndex = 15;
            this.Misc_grp.TabStop = false;
            this.Misc_grp.Text = "Misc.";
            // 
            // levelselect_lbl2
            // 
            this.levelselect_lbl2.AutoSize = true;
            this.levelselect_lbl2.Location = new System.Drawing.Point(5, 205);
            this.levelselect_lbl2.Name = "levelselect_lbl2";
            this.levelselect_lbl2.Size = new System.Drawing.Size(128, 26);
            this.levelselect_lbl2.TabIndex = 19;
            this.levelselect_lbl2.Text = "Level Select\r\n(Enter/Exit Level to Load)";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "",
            "MFM 1",
            "Chinatown Hub",
            "Cookie Factory",
            "Sewers",
            "Temple",
            "Warehouse - Dragon",
            "Theme Park Hub",
            "Haunted House",
            "Water Park",
            "Circus",
            "House of Mirrors - Guitar Ghoul",
            "Museum Hub",
            "Dino",
            "Medieval",
            "Undersea",
            "Planetarium - Caveman",
            "MFM2",
            "MFM3 - Pterodactyl"});
            this.comboBox1.Location = new System.Drawing.Point(5, 234);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(159, 21);
            this.comboBox1.TabIndex = 16;
            // 
            // WriteFile_chkbx
            // 
            this.WriteFile_chkbx.AutoSize = true;
            this.WriteFile_chkbx.Location = new System.Drawing.Point(8, 17);
            this.WriteFile_chkbx.Margin = new System.Windows.Forms.Padding(2);
            this.WriteFile_chkbx.Name = "WriteFile_chkbx";
            this.WriteFile_chkbx.Size = new System.Drawing.Size(99, 17);
            this.WriteFile_chkbx.TabIndex = 10;
            this.WriteFile_chkbx.Text = "Write to text file";
            this.WriteFile_chkbx.UseVisualStyleBackColor = true;
            // 
            // FoodMubber_chkbx
            // 
            this.FoodMubber_chkbx.AutoSize = true;
            this.FoodMubber_chkbx.Location = new System.Drawing.Point(16, 37);
            this.FoodMubber_chkbx.Margin = new System.Windows.Forms.Padding(2);
            this.FoodMubber_chkbx.Name = "FoodMubber_chkbx";
            this.FoodMubber_chkbx.Size = new System.Drawing.Size(89, 30);
            this.FoodMubber_chkbx.TabIndex = 14;
            this.FoodMubber_chkbx.Text = "Mubber Total\r\n(if applicable)";
            this.FoodMubber_chkbx.UseVisualStyleBackColor = true;
            // 
            // CostumeDisplay_chkbx
            // 
            this.CostumeDisplay_chkbx.AutoSize = true;
            this.CostumeDisplay_chkbx.Location = new System.Drawing.Point(8, 117);
            this.CostumeDisplay_chkbx.Margin = new System.Windows.Forms.Padding(2);
            this.CostumeDisplay_chkbx.Name = "CostumeDisplay_chkbx";
            this.CostumeDisplay_chkbx.Size = new System.Drawing.Size(96, 17);
            this.CostumeDisplay_chkbx.TabIndex = 13;
            this.CostumeDisplay_chkbx.Text = "Costume Coins";
            this.CostumeDisplay_chkbx.UseVisualStyleBackColor = true;
            // 
            // TrapDisplay_chkbx
            // 
            this.TrapDisplay_chkbx.AutoSize = true;
            this.TrapDisplay_chkbx.Location = new System.Drawing.Point(8, 97);
            this.TrapDisplay_chkbx.Margin = new System.Windows.Forms.Padding(2);
            this.TrapDisplay_chkbx.Name = "TrapDisplay_chkbx";
            this.TrapDisplay_chkbx.Size = new System.Drawing.Size(59, 17);
            this.TrapDisplay_chkbx.TabIndex = 12;
            this.TrapDisplay_chkbx.Text = "Trap(s)";
            this.TrapDisplay_chkbx.UseVisualStyleBackColor = true;
            // 
            // ClueDisplay_chkbx
            // 
            this.ClueDisplay_chkbx.AutoSize = true;
            this.ClueDisplay_chkbx.Location = new System.Drawing.Point(8, 77);
            this.ClueDisplay_chkbx.Margin = new System.Windows.Forms.Padding(2);
            this.ClueDisplay_chkbx.Name = "ClueDisplay_chkbx";
            this.ClueDisplay_chkbx.Size = new System.Drawing.Size(58, 17);
            this.ClueDisplay_chkbx.TabIndex = 11;
            this.ClueDisplay_chkbx.Text = "Clue(s)";
            this.ClueDisplay_chkbx.UseVisualStyleBackColor = true;
            // 
            // MubberDisplay_chkbx
            // 
            this.MubberDisplay_chkbx.AutoSize = true;
            this.MubberDisplay_chkbx.Location = new System.Drawing.Point(8, 37);
            this.MubberDisplay_chkbx.Margin = new System.Windows.Forms.Padding(2);
            this.MubberDisplay_chkbx.Name = "MubberDisplay_chkbx";
            this.MubberDisplay_chkbx.Size = new System.Drawing.Size(108, 17);
            this.MubberDisplay_chkbx.TabIndex = 15;
            this.MubberDisplay_chkbx.Text = "Scooby\'s Mubber";
            this.MubberDisplay_chkbx.UseVisualStyleBackColor = true;
            // 
            // InputDisplay_chkbx
            // 
            this.InputDisplay_chkbx.AutoSize = true;
            this.InputDisplay_chkbx.Location = new System.Drawing.Point(8, 117);
            this.InputDisplay_chkbx.Margin = new System.Windows.Forms.Padding(2);
            this.InputDisplay_chkbx.Name = "InputDisplay_chkbx";
            this.InputDisplay_chkbx.Size = new System.Drawing.Size(87, 17);
            this.InputDisplay_chkbx.TabIndex = 14;
            this.InputDisplay_chkbx.Text = "Input Display";
            this.InputDisplay_chkbx.UseVisualStyleBackColor = true;
            // 
            // LevelDisplay_chkbx
            // 
            this.LevelDisplay_chkbx.AutoSize = true;
            this.LevelDisplay_chkbx.Location = new System.Drawing.Point(8, 57);
            this.LevelDisplay_chkbx.Margin = new System.Windows.Forms.Padding(2);
            this.LevelDisplay_chkbx.Name = "LevelDisplay_chkbx";
            this.LevelDisplay_chkbx.Size = new System.Drawing.Size(114, 17);
            this.LevelDisplay_chkbx.TabIndex = 9;
            this.LevelDisplay_chkbx.Text = "Current Level/Hub";
            this.LevelDisplay_chkbx.UseVisualStyleBackColor = true;
            // 
            // POSDisplay_chkbx
            // 
            this.POSDisplay_chkbx.AutoSize = true;
            this.POSDisplay_chkbx.Location = new System.Drawing.Point(8, 97);
            this.POSDisplay_chkbx.Margin = new System.Windows.Forms.Padding(2);
            this.POSDisplay_chkbx.Name = "POSDisplay_chkbx";
            this.POSDisplay_chkbx.Size = new System.Drawing.Size(109, 17);
            this.POSDisplay_chkbx.TabIndex = 8;
            this.POSDisplay_chkbx.Text = "Scooby\'s Position";
            this.POSDisplay_chkbx.UseVisualStyleBackColor = true;
            // 
            // SelectCollectibles_chkbx
            // 
            this.SelectCollectibles_chkbx.AutoSize = true;
            this.SelectCollectibles_chkbx.Location = new System.Drawing.Point(8, 217);
            this.SelectCollectibles_chkbx.Margin = new System.Windows.Forms.Padding(2);
            this.SelectCollectibles_chkbx.Name = "SelectCollectibles_chkbx";
            this.SelectCollectibles_chkbx.Size = new System.Drawing.Size(85, 30);
            this.SelectCollectibles_chkbx.TabIndex = 13;
            this.SelectCollectibles_chkbx.Text = "Select All\r\n(Collectibles)";
            this.SelectCollectibles_chkbx.UseVisualStyleBackColor = true;
            this.SelectCollectibles_chkbx.CheckedChanged += new System.EventHandler(this.SelectCollectibles_chkbx_CheckedChanged);
            // 
            // SelectStats_chkbx
            // 
            this.SelectStats_chkbx.AutoSize = true;
            this.SelectStats_chkbx.Location = new System.Drawing.Point(8, 217);
            this.SelectStats_chkbx.Margin = new System.Windows.Forms.Padding(2);
            this.SelectStats_chkbx.Name = "SelectStats_chkbx";
            this.SelectStats_chkbx.Size = new System.Drawing.Size(70, 30);
            this.SelectStats_chkbx.TabIndex = 13;
            this.SelectStats_chkbx.Text = "Select All\r\n(Stats)";
            this.SelectStats_chkbx.UseVisualStyleBackColor = true;
            this.SelectStats_chkbx.CheckedChanged += new System.EventHandler(this.SelectStats_chkbx_CheckedChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(519, 361);
            this.Controls.Add(this.hooked_lbl);
            this.Controls.Add(this.hook_button);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Stats_grp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainWindow";
            this.Text = "Scooby-Doo Unmasker";
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clicktoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writevalue_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedModeToolStripMenuItem;
        private System.Windows.Forms.Label hooked_lbl;
        private System.Windows.Forms.CheckBox HealthDisplay_chkbx;
        private System.Windows.Forms.CheckBox FoodDisplay_chkbx;
        private System.Windows.Forms.CheckBox CostumeDisplay_chkbx;
        private System.Windows.Forms.CheckBox InputDisplay_chkbx;
        private System.Windows.Forms.CheckBox FoodMubber_chkbx;
        private System.Windows.Forms.CheckBox MubberDisplay_chkbx;
        private System.Windows.Forms.GroupBox Stats_grp;
        private System.Windows.Forms.CheckBox WriteFile_chkbx;
        private System.Windows.Forms.CheckBox LevelDisplay_chkbx;
        private System.Windows.Forms.CheckBox POSDisplay_chkbx;
        private System.Windows.Forms.CheckBox TrapDisplay_chkbx;
        private System.Windows.Forms.CheckBox ClueDisplay_chkbx;
        private System.Windows.Forms.GroupBox Misc_grp;
        private System.Windows.Forms.GroupBox Collectibles_grp;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label levelselect_lbl2;
        private System.Windows.Forms.CheckBox PercentageDisplay_chkbx;
        private System.Windows.Forms.CheckBox SelectStats_chkbx;
        private System.Windows.Forms.CheckBox SelectCollectibles_chkbx;
    }
}

