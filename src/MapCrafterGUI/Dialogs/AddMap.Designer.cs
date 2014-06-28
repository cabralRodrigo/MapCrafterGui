namespace MapCrafterGUI.Dialogs
{
    partial class frmAddMap
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
            this.lblRenderMode = new System.Windows.Forms.Label();
            this.cbRenderMode = new System.Windows.Forms.ComboBox();
            this.lblMapName = new System.Windows.Forms.Label();
            this.txtMapName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblWorldName = new System.Windows.Forms.Label();
            this.lblTextWorldName = new System.Windows.Forms.Label();
            this.clbRotations = new System.Windows.Forms.CheckedListBox();
            this.lblRotations = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRenderMode
            // 
            this.lblRenderMode.AutoSize = true;
            this.lblRenderMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenderMode.Location = new System.Drawing.Point(10, 227);
            this.lblRenderMode.Name = "lblRenderMode";
            this.lblRenderMode.Size = new System.Drawing.Size(121, 13);
            this.lblRenderMode.TabIndex = 18;
            this.lblRenderMode.Text = "lblRenderMode.Text";
            // 
            // cbRenderMode
            // 
            this.cbRenderMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRenderMode.FormattingEnabled = true;
            this.cbRenderMode.Location = new System.Drawing.Point(12, 242);
            this.cbRenderMode.Name = "cbRenderMode";
            this.cbRenderMode.Size = new System.Drawing.Size(121, 21);
            this.cbRenderMode.TabIndex = 17;
            // 
            // lblMapName
            // 
            this.lblMapName.AutoSize = true;
            this.lblMapName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMapName.Location = new System.Drawing.Point(9, 55);
            this.lblMapName.Name = "lblMapName";
            this.lblMapName.Size = new System.Drawing.Size(105, 13);
            this.lblMapName.TabIndex = 14;
            this.lblMapName.Text = "lblMapName.Text";
            // 
            // txtMapName
            // 
            this.txtMapName.Location = new System.Drawing.Point(12, 74);
            this.txtMapName.Name = "txtMapName";
            this.txtMapName.Size = new System.Drawing.Size(318, 20);
            this.txtMapName.TabIndex = 13;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(253, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "btnCancel.Text";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(172, 240);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "btnAdd.Text";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblWorldName
            // 
            this.lblWorldName.AutoSize = true;
            this.lblWorldName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorldName.Location = new System.Drawing.Point(9, 9);
            this.lblWorldName.Name = "lblWorldName";
            this.lblWorldName.Size = new System.Drawing.Size(114, 13);
            this.lblWorldName.TabIndex = 19;
            this.lblWorldName.Text = "lblWorldName.Text";
            // 
            // lblTextWorldName
            // 
            this.lblTextWorldName.AutoSize = true;
            this.lblTextWorldName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextWorldName.Location = new System.Drawing.Point(12, 23);
            this.lblTextWorldName.Name = "lblTextWorldName";
            this.lblTextWorldName.Size = new System.Drawing.Size(118, 13);
            this.lblTextWorldName.TabIndex = 20;
            this.lblTextWorldName.Text = "lblTextWorldName.Text";
            // 
            // clbRotations
            // 
            this.clbRotations.FormattingEnabled = true;
            this.clbRotations.Location = new System.Drawing.Point(12, 122);
            this.clbRotations.Name = "clbRotations";
            this.clbRotations.Size = new System.Drawing.Size(120, 94);
            this.clbRotations.TabIndex = 21;
            // 
            // lblRotations
            // 
            this.lblRotations.AutoSize = true;
            this.lblRotations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRotations.Location = new System.Drawing.Point(9, 106);
            this.lblRotations.Name = "lblRotations";
            this.lblRotations.Size = new System.Drawing.Size(103, 13);
            this.lblRotations.TabIndex = 22;
            this.lblRotations.Text = "lblRotations.Text";
            // 
            // frmAddMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 275);
            this.ControlBox = false;
            this.Controls.Add(this.lblRotations);
            this.Controls.Add(this.clbRotations);
            this.Controls.Add(this.lblTextWorldName);
            this.Controls.Add(this.lblWorldName);
            this.Controls.Add(this.lblRenderMode);
            this.Controls.Add(this.cbRenderMode);
            this.Controls.Add(this.lblMapName);
            this.Controls.Add(this.txtMapName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Name = "frmAddMap";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddMap.Text";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRenderMode;
        private System.Windows.Forms.ComboBox cbRenderMode;
        private System.Windows.Forms.Label lblMapName;
        private System.Windows.Forms.TextBox txtMapName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblWorldName;
        private System.Windows.Forms.Label lblTextWorldName;
        private System.Windows.Forms.CheckedListBox clbRotations;
        private System.Windows.Forms.Label lblRotations;
    }
}