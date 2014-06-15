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
            this.lblRenderConfigurarionName = new System.Windows.Forms.Label();
            this.lblRenderConfigurationOutput = new System.Windows.Forms.Label();
            this.btnAddWorld = new System.Windows.Forms.Button();
            this.tabsWorlds = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAddMap = new System.Windows.Forms.Button();
            this.lstMaps = new System.Windows.Forms.ListView();
            this.headerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hearderRenderMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTextDimension = new System.Windows.Forms.Label();
            this.lblDimension = new System.Windows.Forms.Label();
            this.lblTextWorldName = new System.Windows.Forms.Label();
            this.lblWorldName = new System.Windows.Forms.Label();
            this.lblTextWorldInput = new System.Windows.Forms.Label();
            this.lblWorldInput = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pnBackgroundColor = new System.Windows.Forms.Panel();
            this.dialogBackgroundColor = new System.Windows.Forms.ColorDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRenderCondigurationOutput = new System.Windows.Forms.Button();
            this.dialogRenderConfigurationOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadConToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dialogSaveProject = new System.Windows.Forms.SaveFileDialog();
            this.dialogOpenProject = new System.Windows.Forms.OpenFileDialog();
            this.tabsWorlds.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRenderConfigurarionName
            // 
            this.lblRenderConfigurarionName.AutoSize = true;
            this.lblRenderConfigurarionName.Location = new System.Drawing.Point(29, 31);
            this.lblRenderConfigurarionName.Name = "lblRenderConfigurarionName";
            this.lblRenderConfigurarionName.Size = new System.Drawing.Size(142, 13);
            this.lblRenderConfigurarionName.TabIndex = 0;
            this.lblRenderConfigurarionName.Text = "lblRenderConfigurarionName";
            // 
            // lblRenderConfigurationOutput
            // 
            this.lblRenderConfigurationOutput.AutoSize = true;
            this.lblRenderConfigurationOutput.Location = new System.Drawing.Point(11, 77);
            this.lblRenderConfigurationOutput.Name = "lblRenderConfigurationOutput";
            this.lblRenderConfigurationOutput.Size = new System.Drawing.Size(146, 13);
            this.lblRenderConfigurationOutput.TabIndex = 1;
            this.lblRenderConfigurationOutput.Text = "lblRenderConfigurationOutput";
            // 
            // btnAddWorld
            // 
            this.btnAddWorld.Location = new System.Drawing.Point(527, 236);
            this.btnAddWorld.Name = "btnAddWorld";
            this.btnAddWorld.Size = new System.Drawing.Size(75, 23);
            this.btnAddWorld.TabIndex = 4;
            this.btnAddWorld.Text = "Add World";
            this.btnAddWorld.UseVisualStyleBackColor = true;
            this.btnAddWorld.Click += new System.EventHandler(this.btnAddWorld_Click);
            // 
            // tabsWorlds
            // 
            this.tabsWorlds.Controls.Add(this.tabPage1);
            this.tabsWorlds.Location = new System.Drawing.Point(7, 261);
            this.tabsWorlds.Name = "tabsWorlds";
            this.tabsWorlds.SelectedIndex = 0;
            this.tabsWorlds.Size = new System.Drawing.Size(595, 334);
            this.tabsWorlds.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAddMap);
            this.tabPage1.Controls.Add(this.lstMaps);
            this.tabPage1.Controls.Add(this.lblTextDimension);
            this.tabPage1.Controls.Add(this.lblDimension);
            this.tabPage1.Controls.Add(this.lblTextWorldName);
            this.tabPage1.Controls.Add(this.lblWorldName);
            this.tabPage1.Controls.Add(this.lblTextWorldInput);
            this.tabPage1.Controls.Add(this.lblWorldInput);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(587, 308);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAddMap
            // 
            this.btnAddMap.Location = new System.Drawing.Point(498, 95);
            this.btnAddMap.Name = "btnAddMap";
            this.btnAddMap.Size = new System.Drawing.Size(75, 23);
            this.btnAddMap.TabIndex = 7;
            this.btnAddMap.Text = "Add Map";
            this.btnAddMap.UseVisualStyleBackColor = true;
            // 
            // lstMaps
            // 
            this.lstMaps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerName,
            this.hearderRenderMode});
            this.lstMaps.FullRowSelect = true;
            this.lstMaps.GridLines = true;
            this.lstMaps.Location = new System.Drawing.Point(13, 124);
            this.lstMaps.MultiSelect = false;
            this.lstMaps.Name = "lstMaps";
            this.lstMaps.Size = new System.Drawing.Size(560, 175);
            this.lstMaps.TabIndex = 6;
            this.lstMaps.UseCompatibleStateImageBehavior = false;
            this.lstMaps.View = System.Windows.Forms.View.Details;
            this.lstMaps.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // headerName
            // 
            this.headerName.Tag = "";
            this.headerName.Text = "Map Name";
            this.headerName.Width = 100;
            // 
            // hearderRenderMode
            // 
            this.hearderRenderMode.Text = "Map Render Mode";
            this.hearderRenderMode.Width = 120;
            // 
            // lblTextDimension
            // 
            this.lblTextDimension.AutoSize = true;
            this.lblTextDimension.Location = new System.Drawing.Point(12, 93);
            this.lblTextDimension.Name = "lblTextDimension";
            this.lblTextDimension.Size = new System.Drawing.Size(87, 13);
            this.lblTextDimension.TabIndex = 5;
            this.lblTextDimension.Text = "lblTextDimension";
            // 
            // lblDimension
            // 
            this.lblDimension.AutoSize = true;
            this.lblDimension.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDimension.Location = new System.Drawing.Point(10, 80);
            this.lblDimension.Name = "lblDimension";
            this.lblDimension.Size = new System.Drawing.Size(65, 13);
            this.lblDimension.TabIndex = 4;
            this.lblDimension.Text = "Dimension";
            // 
            // lblTextWorldName
            // 
            this.lblTextWorldName.AutoSize = true;
            this.lblTextWorldName.Location = new System.Drawing.Point(12, 57);
            this.lblTextWorldName.Name = "lblTextWorldName";
            this.lblTextWorldName.Size = new System.Drawing.Size(94, 13);
            this.lblTextWorldName.TabIndex = 3;
            this.lblTextWorldName.Text = "lblTextWorldName";
            // 
            // lblWorldName
            // 
            this.lblWorldName.AutoSize = true;
            this.lblWorldName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorldName.Location = new System.Drawing.Point(10, 44);
            this.lblWorldName.Name = "lblWorldName";
            this.lblWorldName.Size = new System.Drawing.Size(76, 13);
            this.lblWorldName.TabIndex = 2;
            this.lblWorldName.Text = "World Name";
            // 
            // lblTextWorldInput
            // 
            this.lblTextWorldInput.AutoSize = true;
            this.lblTextWorldInput.Location = new System.Drawing.Point(12, 22);
            this.lblTextWorldInput.Name = "lblTextWorldInput";
            this.lblTextWorldInput.Size = new System.Drawing.Size(90, 13);
            this.lblTextWorldInput.TabIndex = 1;
            this.lblTextWorldInput.Text = "lblTextWorldInput";
            // 
            // lblWorldInput
            // 
            this.lblWorldInput.AutoSize = true;
            this.lblWorldInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorldInput.Location = new System.Drawing.Point(10, 9);
            this.lblWorldInput.Name = "lblWorldInput";
            this.lblWorldInput.Size = new System.Drawing.Size(79, 13);
            this.lblWorldInput.TabIndex = 0;
            this.lblWorldInput.Text = "World Folder";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(527, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "debug";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnBackgroundColor
            // 
            this.pnBackgroundColor.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnBackgroundColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnBackgroundColor.Location = new System.Drawing.Point(14, 125);
            this.pnBackgroundColor.Name = "pnBackgroundColor";
            this.pnBackgroundColor.Size = new System.Drawing.Size(88, 28);
            this.pnBackgroundColor.TabIndex = 7;
            this.pnBackgroundColor.Click += new System.EventHandler(this.pnBackgroundColor_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRenderCondigurationOutput);
            this.groupBox1.Controls.Add(this.lblRenderConfigurationOutput);
            this.groupBox1.Controls.Add(this.pnBackgroundColor);
            this.groupBox1.Controls.Add(this.lblRenderConfigurarionName);
            this.groupBox1.Location = new System.Drawing.Point(12, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 159);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Render Configurations";
            // 
            // btnRenderCondigurationOutput
            // 
            this.btnRenderCondigurationOutput.Location = new System.Drawing.Point(10, 93);
            this.btnRenderCondigurationOutput.Name = "btnRenderCondigurationOutput";
            this.btnRenderCondigurationOutput.Size = new System.Drawing.Size(75, 23);
            this.btnRenderCondigurationOutput.TabIndex = 8;
            this.btnRenderCondigurationOutput.Text = "Search";
            this.btnRenderCondigurationOutput.UseVisualStyleBackColor = true;
            this.btnRenderCondigurationOutput.Click += new System.EventHandler(this.btnRenderCondigurationOutput_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(609, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveConfigurationToolStripMenuItem,
            this.loadConToolStripMenuItem,
            this.newProjectToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveConfigurationToolStripMenuItem
            // 
            this.saveConfigurationToolStripMenuItem.Name = "saveConfigurationToolStripMenuItem";
            this.saveConfigurationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveConfigurationToolStripMenuItem.Text = "Save Project";
            this.saveConfigurationToolStripMenuItem.Click += new System.EventHandler(this.saveConfigurationToolStripMenuItem_Click);
            // 
            // loadConToolStripMenuItem
            // 
            this.loadConToolStripMenuItem.Name = "loadConToolStripMenuItem";
            this.loadConToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadConToolStripMenuItem.Text = "Load Project";
            this.loadConToolStripMenuItem.Click += new System.EventHandler(this.loadConToolStripMenuItem_Click);
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newProjectToolStripMenuItem.Text = "New Project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // dialogSaveProject
            // 
            this.dialogSaveProject.Filter = "MapCrafterGui Configuration Files|*.mcconfig";
            this.dialogSaveProject.Title = "Save Project";
            // 
            // dialogOpenProject
            // 
            this.dialogOpenProject.FileName = "openFileDialog1";
            this.dialogOpenProject.Title = "Open Project";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 605);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabsWorlds);
            this.Controls.Add(this.btnAddWorld);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabsWorlds.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRenderConfigurarionName;
        private System.Windows.Forms.Label lblRenderConfigurationOutput;
        private System.Windows.Forms.Button btnAddWorld;
        private System.Windows.Forms.TabControl tabsWorlds;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblTextWorldName;
        private System.Windows.Forms.Label lblWorldName;
        private System.Windows.Forms.Label lblTextWorldInput;
        private System.Windows.Forms.Label lblWorldInput;
        private System.Windows.Forms.Label lblTextDimension;
        private System.Windows.Forms.Label lblDimension;
        private System.Windows.Forms.ListView lstMaps;
        private System.Windows.Forms.Button btnAddMap;
        private System.Windows.Forms.ColumnHeader headerName;
        private System.Windows.Forms.ColumnHeader hearderRenderMode;
        private System.Windows.Forms.Panel pnBackgroundColor;
        private System.Windows.Forms.ColorDialog dialogBackgroundColor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRenderCondigurationOutput;
        private System.Windows.Forms.FolderBrowserDialog dialogRenderConfigurationOutput;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadConToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog dialogSaveProject;
        private System.Windows.Forms.OpenFileDialog dialogOpenProject;
    }
}

