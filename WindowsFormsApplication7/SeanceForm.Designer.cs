namespace WindowsFormsApplication7
{
    partial class SeanceForm
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
            this.dgSeances = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFilm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChange = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgSeances)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgSeances
            // 
            this.dgSeances.AllowUserToAddRows = false;
            this.dgSeances.AllowUserToDeleteRows = false;
            this.dgSeances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSeances.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cId,
            this.cRoom,
            this.cFilm,
            this.cPrice,
            this.cTime,
            this.cDate,
            this.ColChange});
            this.dgSeances.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgSeances.Location = new System.Drawing.Point(0, 0);
            this.dgSeances.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgSeances.Name = "dgSeances";
            this.dgSeances.ReadOnly = true;
            this.dgSeances.RowTemplate.Height = 24;
            this.dgSeances.Size = new System.Drawing.Size(771, 236);
            this.dgSeances.TabIndex = 0;
            this.dgSeances.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSeances_CellContentClick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(654, 73);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 35);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 280);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(771, 119);
            this.panel1.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 35);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(123, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 35);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // cId
            // 
            this.cId.HeaderText = "ID";
            this.cId.Name = "cId";
            this.cId.ReadOnly = true;
            // 
            // cRoom
            // 
            this.cRoom.HeaderText = "Комната";
            this.cRoom.Name = "cRoom";
            this.cRoom.ReadOnly = true;
            this.cRoom.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cRoom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cFilm
            // 
            this.cFilm.HeaderText = "Фильм";
            this.cFilm.Name = "cFilm";
            this.cFilm.ReadOnly = true;
            this.cFilm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cFilm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cPrice
            // 
            this.cPrice.HeaderText = "Цена";
            this.cPrice.Name = "cPrice";
            this.cPrice.ReadOnly = true;
            // 
            // cTime
            // 
            this.cTime.HeaderText = "Время";
            this.cTime.Name = "cTime";
            this.cTime.ReadOnly = true;
            // 
            // cDate
            // 
            this.cDate.HeaderText = "Дата";
            this.cDate.Name = "cDate";
            this.cDate.ReadOnly = true;
            // 
            // ColChange
            // 
            this.ColChange.HeaderText = "Изменить";
            this.ColChange.Name = "ColChange";
            this.ColChange.ReadOnly = true;
            // 
            // SeanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 399);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgSeances);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SeanceForm";
            this.Text = "SeanceForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgSeances)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSeances;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn cId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFilm;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDate;
        private System.Windows.Forms.DataGridViewButtonColumn ColChange;
    }
}