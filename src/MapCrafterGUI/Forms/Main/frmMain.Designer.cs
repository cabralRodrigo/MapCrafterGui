namespace MapCrafterGUI.Forms
{
    partial class frmMain
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
            this.btnAddWorld = new System.Windows.Forms.Button();
            this.tabsWorlds = new System.Windows.Forms.TabControl();
            this.button1 = new System.Windows.Forms.Button();
            this.pnBackgroundColor = new System.Windows.Forms.Panel();
            this.dialogBackgroundColor = new System.Windows.Forms.ColorDialog();
            this.groupRenderConfig = new System.Windows.Forms.GroupBox();
            this.lblRenderConfigurationColor = new System.Windows.Forms.Label();
            this.lblRenderConfigurationFileName = new System.Windows.Forms.Label();
            this.lblRenderConfigurationOutputPath = new System.Windows.Forms.Label();
            this.txtRenderConfigurationFileName = new System.Windows.Forms.TextBox();
            this.txtRenderConfigurationOutputPath = new System.Windows.Forms.TextBox();
            this.btnRenderCondigurationOutput = new System.Windows.Forms.Button();
            this.dialogRenderConfigurationOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLoadConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.dialogSaveProject = new System.Windows.Forms.SaveFileDialog();
            this.dialogOpenProject = new System.Windows.Forms.OpenFileDialog();
            this.groupRenderConfig.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddWorld
            // 
            this.btnAddWorld.Location = new System.Drawing.Point(496, 236);
            this.btnAddWorld.Name = "btnAddWorld";
            this.btnAddWorld.Size = new System.Drawing.Size(106, 23);
            this.btnAddWorld.TabIndex = 4;
            this.btnAddWorld.Text = "btnAddWorld.Text";
            this.btnAddWorld.UseVisualStyleBackColor = true;
            this.btnAddWorld.Click += new System.EventHandler(this.btnAddWorld_Click);
            // 
            // tabsWorlds
            // 
            this.tabsWorlds.Location = new System.Drawing.Point(7, 261);
            this.tabsWorlds.Name = "tabsWorlds";
            this.tabsWorlds.SelectedIndex = 0;
            this.tabsWorlds.Size = new System.Drawing.Size(595, 334);
            this.tabsWorlds.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(415, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "debug";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // pnBackgroundColor
            // 
            this.pnBackgroundColor.BackColor = System.Drawing.Color.White;
            this.pnBackgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnBackgroundColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnBackgroundColor.Location = new System.Drawing.Point(10, 140);
            this.pnBackgroundColor.Name = "pnBackgroundColor";
            this.pnBackgroundColor.Size = new System.Drawing.Size(258, 28);
            this.pnBackgroundColor.TabIndex = 7;
            this.pnBackgroundColor.Click += new System.EventHandler(this.pnBackgroundColor_Click);
            // 
            // groupRenderConfig
            // 
            this.groupRenderConfig.Controls.Add(this.lblRenderConfigurationColor);
            this.groupRenderConfig.Controls.Add(this.lblRenderConfigurationFileName);
            this.groupRenderConfig.Controls.Add(this.lblRenderConfigurationOutputPath);
            this.groupRenderConfig.Controls.Add(this.txtRenderConfigurationFileName);
            this.groupRenderConfig.Controls.Add(this.txtRenderConfigurationOutputPath);
            this.groupRenderConfig.Controls.Add(this.btnRenderCondigurationOutput);
            this.groupRenderConfig.Controls.Add(this.pnBackgroundColor);
            this.groupRenderConfig.Location = new System.Drawing.Point(7, 27);
            this.groupRenderConfig.Name = "groupRenderConfig";
            this.groupRenderConfig.Size = new System.Drawing.Size(595, 185);
            this.groupRenderConfig.TabIndex = 8;
            this.groupRenderConfig.TabStop = false;
            this.groupRenderConfig.Text = "groupRenderConfig.Text";
            // 
            // lblRenderConfigurationColor
            // 
            this.lblRenderConfigurationColor.AutoSize = true;
            this.lblRenderConfigurationColor.Location = new System.Drawing.Point(10, 121);
            this.lblRenderConfigurationColor.Name = "lblRenderConfigurationColor";
            this.lblRenderConfigurationColor.Size = new System.Drawing.Size(162, 13);
            this.lblRenderConfigurationColor.TabIndex = 13;
            this.lblRenderConfigurationColor.Text = "lblRenderConfigurationColor.Text";
            // 
            // lblRenderConfigurationFileName
            // 
            this.lblRenderConfigurationFileName.AutoSize = true;
            this.lblRenderConfigurationFileName.Location = new System.Drawing.Point(7, 73);
            this.lblRenderConfigurationFileName.Name = "lblRenderConfigurationFileName";
            this.lblRenderConfigurationFileName.Size = new System.Drawing.Size(182, 13);
            this.lblRenderConfigurationFileName.TabIndex = 12;
            this.lblRenderConfigurationFileName.Text = "lblRenderConfigurationFileName.Text";
            // 
            // lblRenderConfigurationOutputPath
            // 
            this.lblRenderConfigurationOutputPath.AutoSize = true;
            this.lblRenderConfigurationOutputPath.Location = new System.Drawing.Point(7, 25);
            this.lblRenderConfigurationOutputPath.Name = "lblRenderConfigurationOutputPath";
            this.lblRenderConfigurationOutputPath.Size = new System.Drawing.Size(192, 13);
            this.lblRenderConfigurationOutputPath.TabIndex = 11;
            this.lblRenderConfigurationOutputPath.Text = "lblRenderConfigurationOutputPath.Text";
            // 
            // txtRenderConfigurationFileName
            // 
            this.txtRenderConfigurationFileName.Location = new System.Drawing.Point(10, 89);
            this.txtRenderConfigurationFileName.Name = "txtRenderConfigurationFileName";
            this.txtRenderConfigurationFileName.Size = new System.Drawing.Size(230, 20);
            this.txtRenderConfigurationFileName.TabIndex = 10;
            // 
            // txtRenderConfigurationOutputPath
            // 
            this.txtRenderConfigurationOutputPath.Location = new System.Drawing.Point(10, 41);
            this.txtRenderConfigurationOutputPath.Name = "txtRenderConfigurationOutputPath";
            this.txtRenderConfigurationOutputPath.Size = new System.Drawing.Size(480, 20);
            this.txtRenderConfigurationOutputPath.TabIndex = 9;
            // 
            // btnRenderCondigurationOutput
            // 
            this.btnRenderCondigurationOutput.Location = new System.Drawing.Point(502, 40);
            this.btnRenderCondigurationOutput.Name = "btnRenderCondigurationOutput";
            this.btnRenderCondigurationOutput.Size = new System.Drawing.Size(87, 23);
            this.btnRenderCondigurationOutput.TabIndex = 8;
            this.btnRenderCondigurationOutput.Text = "btnRenderCondigurationOutput.Text";
            this.btnRenderCondigurationOutput.UseVisualStyleBackColor = true;
            this.btnRenderCondigurationOutput.Click += new System.EventHandler(this.btnRenderCondigurationOutput_Click);
            // 
            // dialogRenderConfigurationOutput
            // 
            this.dialogRenderConfigurationOutput.Description = "dialogRenderConfigurationOutput.Description";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(609, 24);
            this.menu.TabIndex = 9;
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewConfig,
            this.menuItemLoadConfig,
            this.menuItemSaveConfig});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(117, 20);
            this.menuItemFile.Text = "menuItemFile.Text";
            // 
            // menuItemNewConfig
            // 
            this.menuItemNewConfig.Name = "menuItemNewConfig";
            this.menuItemNewConfig.Size = new System.Drawing.Size(214, 22);
            this.menuItemNewConfig.Text = "menuItemNewConfig.Text";
            this.menuItemNewConfig.Click += new System.EventHandler(this.menuItemNewConfig_Click);
            // 
            // menuItemLoadConfig
            // 
            this.menuItemLoadConfig.Name = "menuItemLoadConfig";
            this.menuItemLoadConfig.Size = new System.Drawing.Size(214, 22);
            this.menuItemLoadConfig.Text = "loadItemLoadConfig.Text";
            this.menuItemLoadConfig.Click += new System.EventHandler(this.menuItemLoadConfig_Click);
            // 
            // menuItemSaveConfig
            // 
            this.menuItemSaveConfig.Name = "menuItemSaveConfig";
            this.menuItemSaveConfig.Size = new System.Drawing.Size(214, 22);
            this.menuItemSaveConfig.Text = "menuItemSaveConfig.Text";
            this.menuItemSaveConfig.Click += new System.EventHandler(this.menuItemSaveConfig_Click);
            // 
            // dialogSaveProject
            // 
            this.dialogSaveProject.Title = "dialogSaveProject.Title";
            // 
            // dialogOpenProject
            // 
            this.dialogOpenProject.Title = "dialogOpenProject.Title";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 605);
            this.Controls.Add(this.groupRenderConfig);
            this.Controls.Add(this.tabsWorlds);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAddWorld);
            this.Controls.Add(this.menu);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain.Text";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupRenderConfig.ResumeLayout(false);
            this.groupRenderConfig.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddWorld;
        private System.Windows.Forms.TabControl tabsWorlds;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnBackgroundColor;
        private System.Windows.Forms.ColorDialog dialogBackgroundColor;
        private System.Windows.Forms.GroupBox groupRenderConfig;
        private System.Windows.Forms.Button btnRenderCondigurationOutput;
        private System.Windows.Forms.FolderBrowserDialog dialogRenderConfigurationOutput;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveConfig;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoadConfig;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewConfig;
        private System.Windows.Forms.SaveFileDialog dialogSaveProject;
        private System.Windows.Forms.OpenFileDialog dialogOpenProject;
        private System.Windows.Forms.Label lblRenderConfigurationFileName;
        private System.Windows.Forms.Label lblRenderConfigurationOutputPath;
        private System.Windows.Forms.TextBox txtRenderConfigurationFileName;
        private System.Windows.Forms.TextBox txtRenderConfigurationOutputPath;
        private System.Windows.Forms.Label lblRenderConfigurationColor;
    }
}

