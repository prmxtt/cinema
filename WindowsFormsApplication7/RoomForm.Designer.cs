namespace WindowsFormsApplication7
{
    partial class RoomForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.tbColCount = new System.Windows.Forms.TextBox();
            this.tbRowCount = new System.Windows.Forms.TextBox();
            this.panelRoom = new System.Windows.Forms.Panel();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(557, 474);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbColCount
            // 
            this.tbColCount.Location = new System.Drawing.Point(41, 47);
            this.tbColCount.Name = "tbColCount";
            this.tbColCount.Size = new System.Drawing.Size(100, 22);
            this.tbColCount.TabIndex = 1;
            // 
            // tbRowCount
            // 
            this.tbRowCount.Location = new System.Drawing.Point(41, 75);
            this.tbRowCount.Name = "tbRowCount";
            this.tbRowCount.Size = new System.Drawing.Size(100, 22);
            this.tbRowCount.TabIndex = 2;
            // 
            // panelRoom
            // 
            this.panelRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRoom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelRoom.Location = new System.Drawing.Point(12, 156);
            this.panelRoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelRoom.Name = "panelRoom";
            this.panelRoom.Size = new System.Drawing.Size(675, 297);
            this.panelRoom.TabIndex = 3;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(41, 19);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 22);
            this.tbName.TabIndex = 4;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(158, 75);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(130, 23);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 509);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.panelRoom);
            this.Controls.Add(this.tbRowCount);
            this.Controls.Add(this.tbColCount);
            this.Controls.Add(this.btnSave);
            this.Name = "RoomForm";
            this.Text = "RoomForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbColCount;
        private System.Windows.Forms.TextBox tbRowCount;
        private System.Windows.Forms.Panel panelRoom;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnApply;
    }
}