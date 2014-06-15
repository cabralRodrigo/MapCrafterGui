namespace MapCrafterGUI.Dialogs
{
    partial class AddMap
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblTextWorldName = new System.Windows.Forms.Label();
            this.clbRotations = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // lblRenderMode
            // 
            this.lblRenderMode.AutoSize = true;
            this.lblRenderMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenderMode.Location = new System.Drawing.Point(10, 228);
            this.lblRenderMode.Name = "lblRenderMode";
            this.lblRenderMode.Size = new System.Drawing.Size(79, 13);
            this.lblRenderMode.TabIndex = 18;
            this.lblRenderMode.Text = "RenderMode";
            // 
            // cbRenderMode
            // 
            this.cbRenderMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRenderMode.FormattingEnabled = true;
            this.cbRenderMode.Location = new System.Drawing.Point(12, 243);
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
            this.lblMapName.Size = new System.Drawing.Size(67, 13);
            this.lblMapName.TabIndex = 14;
            this.lblMapName.Text = "Map Name";
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
            this.btnCancel.Location = new System.Drawing.Point(253, 241);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(172, 241);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "OK";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "World Name";
            // 
            // lblTextWorldName
            // 
            this.lblTextWorldName.AutoSize = true;
            this.lblTextWorldName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextWorldName.Location = new System.Drawing.Point(12, 23);
            this.lblTextWorldName.Name = "lblTextWorldName";
            this.lblTextWorldName.Size = new System.Drawing.Size(88, 13);
            this.lblTextWorldName.TabIndex = 20;
            this.lblTextWorldName.Text = "lblTextWorlName";
            // 
            // checkedListBox1
            // 
            this.clbRotations.FormattingEnabled = true;
            this.clbRotations.Location = new System.Drawing.Point(12, 118);
            this.clbRotations.Name = "checkedListBox1";
            this.clbRotations.Size = new System.Drawing.Size(120, 94);
            this.clbRotations.TabIndex = 21;
            // 
            // AddMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 276);
            this.ControlBox = false;
            this.Controls.Add(this.clbRotations);
            this.Controls.Add(this.lblTextWorldName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRenderMode);
            this.Controls.Add(this.cbRenderMode);
            this.Controls.Add(this.lblMapName);
            this.Controls.Add(this.txtMapName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Name = "AddMap";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Map";
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTextWorldName;
        private System.Windows.Forms.CheckedListBox clbRotations;
    }
}