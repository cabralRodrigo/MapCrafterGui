namespace MapCrafterGUI.Dialogs
{
    partial class frmAddWorld
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnInputFolder = new System.Windows.Forms.Button();
            this.txtInputFolder = new System.Windows.Forms.TextBox();
            this.lblInputFolder = new System.Windows.Forms.Label();
            this.lblWorldName = new System.Windows.Forms.Label();
            this.txtWorldName = new System.Windows.Forms.TextBox();
            this.cbDimension = new System.Windows.Forms.ComboBox();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.lblDimension = new System.Windows.Forms.Label();
            this.validationControl = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.validationControl)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(307, 130);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "btnAdd.Text";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(388, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "btnCancel.Text";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnInputFolder
            // 
            this.btnInputFolder.Location = new System.Drawing.Point(388, 26);
            this.btnInputFolder.Name = "btnInputFolder";
            this.btnInputFolder.Size = new System.Drawing.Size(75, 23);
            this.btnInputFolder.TabIndex = 2;
            this.btnInputFolder.Text = "btnInputFolder.Text";
            this.btnInputFolder.UseVisualStyleBackColor = true;
            this.btnInputFolder.Click += new System.EventHandler(this.btnInputFolder_Click);
            // 
            // txtInputFolder
            // 
            this.txtInputFolder.Location = new System.Drawing.Point(15, 28);
            this.txtInputFolder.Name = "txtInputFolder";
            this.txtInputFolder.Size = new System.Drawing.Size(318, 20);
            this.txtInputFolder.TabIndex = 3;
            this.txtInputFolder.TextChanged += new System.EventHandler(this.txtInputFolder_TextChanged);
            // 
            // lblInputFolder
            // 
            this.lblInputFolder.AutoSize = true;
            this.lblInputFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputFolder.Location = new System.Drawing.Point(12, 9);
            this.lblInputFolder.Name = "lblInputFolder";
            this.lblInputFolder.Size = new System.Drawing.Size(113, 13);
            this.lblInputFolder.TabIndex = 4;
            this.lblInputFolder.Text = "lblInputFolder.Text";
            // 
            // lblWorldName
            // 
            this.lblWorldName.AutoSize = true;
            this.lblWorldName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorldName.Location = new System.Drawing.Point(12, 62);
            this.lblWorldName.Name = "lblWorldName";
            this.lblWorldName.Size = new System.Drawing.Size(114, 13);
            this.lblWorldName.TabIndex = 7;
            this.lblWorldName.Text = "lblWorldName.Text";
            // 
            // txtWorldName
            // 
            this.txtWorldName.Location = new System.Drawing.Point(15, 79);
            this.txtWorldName.Name = "txtWorldName";
            this.txtWorldName.Size = new System.Drawing.Size(318, 20);
            this.txtWorldName.TabIndex = 6;
            this.txtWorldName.TextChanged += new System.EventHandler(this.txtWorldName_TextChanged);
            // 
            // cbDimension
            // 
            this.cbDimension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDimension.FormattingEnabled = true;
            this.cbDimension.Location = new System.Drawing.Point(15, 132);
            this.cbDimension.Name = "cbDimension";
            this.cbDimension.Size = new System.Drawing.Size(121, 21);
            this.cbDimension.TabIndex = 8;
            // 
            // folderDialog
            // 
            this.folderDialog.Description = "folderDialog.Description";
            // 
            // lblDimension
            // 
            this.lblDimension.AutoSize = true;
            this.lblDimension.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDimension.Location = new System.Drawing.Point(13, 116);
            this.lblDimension.Name = "lblDimension";
            this.lblDimension.Size = new System.Drawing.Size(107, 13);
            this.lblDimension.TabIndex = 9;
            this.lblDimension.Text = "lblDimension.Text";
            // 
            // validationControl
            // 
            this.validationControl.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.validationControl.ContainerControl = this;
            // 
            // frmAddWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 166);
            this.ControlBox = false;
            this.Controls.Add(this.lblDimension);
            this.Controls.Add(this.cbDimension);
            this.Controls.Add(this.lblWorldName);
            this.Controls.Add(this.txtWorldName);
            this.Controls.Add(this.lblInputFolder);
            this.Controls.Add(this.txtInputFolder);
            this.Controls.Add(this.btnInputFolder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAddWorld";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddWorld.Text";
            ((System.ComponentModel.ISupportInitialize)(this.validationControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnInputFolder;
        private System.Windows.Forms.TextBox txtInputFolder;
        private System.Windows.Forms.Label lblInputFolder;
        private System.Windows.Forms.Label lblWorldName;
        private System.Windows.Forms.TextBox txtWorldName;
        private System.Windows.Forms.ComboBox cbDimension;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.Label lblDimension;
        private System.Windows.Forms.ErrorProvider validationControl;
    }
}