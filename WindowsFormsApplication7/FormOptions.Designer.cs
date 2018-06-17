namespace WindowsFormsApplication7
{
    partial class FormOptions
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
            this.cbAutoSelectFilm = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbAutoSelectDate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbAutoSelectFilm
            // 
            this.cbAutoSelectFilm.AutoSize = true;
            this.cbAutoSelectFilm.Location = new System.Drawing.Point(9, 10);
            this.cbAutoSelectFilm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbAutoSelectFilm.Name = "cbAutoSelectFilm";
            this.cbAutoSelectFilm.Size = new System.Drawing.Size(143, 17);
            this.cbAutoSelectFilm.TabIndex = 0;
            this.cbAutoSelectFilm.Text = "Автозаполнение полей";
            this.cbAutoSelectFilm.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(9, 137);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(9, 164);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 22);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Закрыть";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbAutoSelectDate
            // 
            this.cbAutoSelectDate.AutoSize = true;
            this.cbAutoSelectDate.Location = new System.Drawing.Point(9, 32);
            this.cbAutoSelectDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbAutoSelectDate.Name = "cbAutoSelectDate";
            this.cbAutoSelectDate.Size = new System.Drawing.Size(200, 17);
            this.cbAutoSelectDate.TabIndex = 3;
            this.cbAutoSelectDate.Text = "Автозаполнение ближайщей даты";
            this.cbAutoSelectDate.UseVisualStyleBackColor = true;
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 206);
            this.Controls.Add(this.cbAutoSelectDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbAutoSelectFilm);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormOptions";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.FormOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbAutoSelectFilm;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbAutoSelectDate;
    }
}