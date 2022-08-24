namespace ScoobyNET
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
            this.hook_button = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hooked_lbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Health_chkbx = new System.Windows.Forms.CheckBox();
            this.FoodDisplay_chkbx = new System.Windows.Forms.CheckBox();
            this.Settings_grp = new System.Windows.Forms.GroupBox();
            this.WriteFile_chkbx = new System.Windows.Forms.CheckBox();
            this.LevelDisplay_chkbx = new System.Windows.Forms.CheckBox();
            this.POSDisplay_chkbx = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.Settings_grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // hook_button
            // 
            this.hook_button.Location = new System.Drawing.Point(9, 60);
            this.hook_button.Margin = new System.Windows.Forms.Padding(2);
            this.hook_button.Name = "hook_button";
            this.hook_button.Size = new System.Drawing.Size(383, 19);
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
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(403, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
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
            // 
            // hooked_lbl
            // 
            this.hooked_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hooked_lbl.Location = new System.Drawing.Point(7, 33);
            this.hooked_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hooked_lbl.Name = "hooked_lbl";
            this.hooked_lbl.Size = new System.Drawing.Size(385, 16);
            this.hooked_lbl.TabIndex = 4;
            this.hooked_lbl.Text = "Dolphin is not hooked.\r\n";
            this.hooked_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 137);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 5;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Health_chkbx
            // 
            this.Health_chkbx.AutoSize = true;
            this.Health_chkbx.Location = new System.Drawing.Point(5, 25);
            this.Health_chkbx.Margin = new System.Windows.Forms.Padding(2);
            this.Health_chkbx.Name = "Health_chkbx";
            this.Health_chkbx.Size = new System.Drawing.Size(103, 17);
            this.Health_chkbx.TabIndex = 6;
            this.Health_chkbx.Text = "Scooby\'s Health";
            this.Health_chkbx.UseVisualStyleBackColor = true;
            // 
            // FoodDisplay_chkbx
            // 
            this.FoodDisplay_chkbx.AutoSize = true;
            this.FoodDisplay_chkbx.Location = new System.Drawing.Point(5, 47);
            this.FoodDisplay_chkbx.Margin = new System.Windows.Forms.Padding(2);
            this.FoodDisplay_chkbx.Name = "FoodDisplay_chkbx";
            this.FoodDisplay_chkbx.Size = new System.Drawing.Size(87, 17);
            this.FoodDisplay_chkbx.TabIndex = 7;
            this.FoodDisplay_chkbx.Text = "Food Display";
            this.FoodDisplay_chkbx.UseVisualStyleBackColor = true;
            // 
            // Settings_grp
            // 
            this.Settings_grp.Controls.Add(this.WriteFile_chkbx);
            this.Settings_grp.Controls.Add(this.LevelDisplay_chkbx);
            this.Settings_grp.Controls.Add(this.POSDisplay_chkbx);
            this.Settings_grp.Controls.Add(this.Health_chkbx);
            this.Settings_grp.Controls.Add(this.FoodDisplay_chkbx);
            this.Settings_grp.Controls.Add(this.button1);
            this.Settings_grp.Location = new System.Drawing.Point(12, 84);
            this.Settings_grp.Name = "Settings_grp";
            this.Settings_grp.Size = new System.Drawing.Size(379, 161);
            this.Settings_grp.TabIndex = 8;
            this.Settings_grp.TabStop = false;
            this.Settings_grp.Text = "Settings";
            // 
            // WriteFile_chkbx
            // 
            this.WriteFile_chkbx.AutoSize = true;
            this.WriteFile_chkbx.Location = new System.Drawing.Point(275, 25);
            this.WriteFile_chkbx.Margin = new System.Windows.Forms.Padding(2);
            this.WriteFile_chkbx.Name = "WriteFile_chkbx";
            this.WriteFile_chkbx.Size = new System.Drawing.Size(99, 17);
            this.WriteFile_chkbx.TabIndex = 10;
            this.WriteFile_chkbx.Text = "Write to text file";
            this.WriteFile_chkbx.UseVisualStyleBackColor = true;
            // 
            // LevelDisplay_chkbx
            // 
            this.LevelDisplay_chkbx.AutoSize = true;
            this.LevelDisplay_chkbx.Location = new System.Drawing.Point(5, 89);
            this.LevelDisplay_chkbx.Margin = new System.Windows.Forms.Padding(2);
            this.LevelDisplay_chkbx.Name = "LevelDisplay_chkbx";
            this.LevelDisplay_chkbx.Size = new System.Drawing.Size(89, 17);
            this.LevelDisplay_chkbx.TabIndex = 9;
            this.LevelDisplay_chkbx.Text = "Level Display";
            this.LevelDisplay_chkbx.UseVisualStyleBackColor = true;
            // 
            // POSDisplay_chkbx
            // 
            this.POSDisplay_chkbx.AutoSize = true;
            this.POSDisplay_chkbx.Location = new System.Drawing.Point(5, 68);
            this.POSDisplay_chkbx.Margin = new System.Windows.Forms.Padding(2);
            this.POSDisplay_chkbx.Name = "POSDisplay_chkbx";
            this.POSDisplay_chkbx.Size = new System.Drawing.Size(100, 17);
            this.POSDisplay_chkbx.TabIndex = 8;
            this.POSDisplay_chkbx.Text = "Position Display";
            this.POSDisplay_chkbx.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 257);
            this.Controls.Add(this.Settings_grp);
            this.Controls.Add(this.hooked_lbl);
            this.Controls.Add(this.hook_button);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Unmasked Tool";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Settings_grp.ResumeLayout(false);
            this.Settings_grp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button hook_button;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label hooked_lbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.CheckBox Health_chkbx;
        private System.Windows.Forms.CheckBox FoodDisplay_chkbx;
        private System.Windows.Forms.GroupBox Settings_grp;
        private System.Windows.Forms.CheckBox WriteFile_chkbx;
        private System.Windows.Forms.CheckBox LevelDisplay_chkbx;
        private System.Windows.Forms.CheckBox POSDisplay_chkbx;
    }
}

