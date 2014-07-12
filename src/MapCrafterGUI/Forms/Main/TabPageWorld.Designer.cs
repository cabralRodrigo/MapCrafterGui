namespace MapCrafterGUI.Forms.Main
{
    partial class TabPageWorld
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblWorldInput = new System.Windows.Forms.Label();
            this.lblTextWorldInput = new System.Windows.Forms.Label();
            this.lblTextWorldName = new System.Windows.Forms.Label();
            this.lblWorldName = new System.Windows.Forms.Label();
            this.lblDimension = new System.Windows.Forms.Label();
            this.lblTextDimension = new System.Windows.Forms.Label();
            this.lstMaps = new System.Windows.Forms.ListView();
            this.headerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hearderRenderMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddMap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWorldInput
            // 
            this.lblWorldInput.AutoSize = true;
            this.lblWorldInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorldInput.Location = new System.Drawing.Point(10, 9);
            this.lblWorldInput.Name = "lblWorldInput";
            this.lblWorldInput.Size = new System.Drawing.Size(82, 13);
            this.lblWorldInput.TabIndex = 0;
            this.lblWorldInput.Text = "lblWorldInput";
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
            this.lblWorldName.Size = new System.Drawing.Size(85, 13);
            this.lblWorldName.TabIndex = 2;
            this.lblWorldName.Text = "lblWorldName";
            // 
            // lblDimension
            // 
            this.lblDimension.AutoSize = true;
            this.lblDimension.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDimension.Location = new System.Drawing.Point(10, 80);
            this.lblDimension.Name = "lblDimension";
            this.lblDimension.Size = new System.Drawing.Size(78, 13);
            this.lblDimension.TabIndex = 4;
            this.lblDimension.Text = "lblDimension";
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
            // 
            // headerName
            // 
            this.headerName.Text = "Map Name";
            this.headerName.Width = 120;
            // 
            // hearderRenderMode
            // 
            this.hearderRenderMode.Text = "Map Render Mode";
            this.hearderRenderMode.Width = 120;
            // 
            // btnAddMap
            // 
            this.btnAddMap.Location = new System.Drawing.Point(469, 95);
            this.btnAddMap.Name = "btnAddMap";
            this.btnAddMap.Size = new System.Drawing.Size(104, 23);
            this.btnAddMap.TabIndex = 7;
            this.btnAddMap.Text = "btnAddMap";
            this.btnAddMap.UseVisualStyleBackColor = true;
            // 
            // TabPageWorld
            // 
            this.Controls.Add(this.lblTextWorldName);
            this.Controls.Add(this.lblWorldName);
            this.Controls.Add(this.lblTextWorldInput);
            this.Controls.Add(this.lblWorldInput);
            this.Controls.Add(this.lblDimension);
            this.Controls.Add(this.lblTextDimension);
            this.Controls.Add(this.lstMaps);
            this.Controls.Add(this.btnAddMap);
            this.Name = "TabPageWorld";
            this.Size = new System.Drawing.Size(585, 310);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

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

        #endregion
    }
}
