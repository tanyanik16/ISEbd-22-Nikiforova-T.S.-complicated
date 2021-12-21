namespace WindowsFormsApp1
{
    partial class FormParking
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
            this.pictureBoxParking = new System.Windows.Forms.PictureBox();
            this.buttonModTank = new System.Windows.Forms.Button();
            this.groupBoxParking = new System.Windows.Forms.GroupBox();
            this.buttonZ = new System.Windows.Forms.Button();
            this.maskedTextBoxParking = new System.Windows.Forms.MaskedTextBox();
            this.labelParking = new System.Windows.Forms.Label();
            this.listBoxParking = new System.Windows.Forms.ListBox();
            this.textBoxParking = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonStack = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.текущуюПарковкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеПарковкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.однуПарковкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеПарковкиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParking)).BeginInit();
            this.groupBoxParking.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxParking
            // 
            this.pictureBoxParking.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxParking.Location = new System.Drawing.Point(0, 28);
            this.pictureBoxParking.Name = "pictureBoxParking";
            this.pictureBoxParking.Size = new System.Drawing.Size(669, 422);
            this.pictureBoxParking.TabIndex = 0;
            this.pictureBoxParking.TabStop = false;
            // 
            // buttonModTank
            // 
            this.buttonModTank.Location = new System.Drawing.Point(681, 26);
            this.buttonModTank.Name = "buttonModTank";
            this.buttonModTank.Size = new System.Drawing.Size(112, 58);
            this.buttonModTank.TabIndex = 2;
            this.buttonModTank.Text = "Добавить танк";
            this.buttonModTank.UseVisualStyleBackColor = true;
            this.buttonModTank.Click += new System.EventHandler(this.buttonModTank_Click);
            // 
            // groupBoxParking
            // 
            this.groupBoxParking.Controls.Add(this.buttonZ);
            this.groupBoxParking.Controls.Add(this.maskedTextBoxParking);
            this.groupBoxParking.Controls.Add(this.labelParking);
            this.groupBoxParking.Location = new System.Drawing.Point(675, 127);
            this.groupBoxParking.Name = "groupBoxParking";
            this.groupBoxParking.Size = new System.Drawing.Size(115, 107);
            this.groupBoxParking.TabIndex = 3;
            this.groupBoxParking.TabStop = false;
            this.groupBoxParking.Text = "Забрать танк";
            // 
            // buttonZ
            // 
            this.buttonZ.Location = new System.Drawing.Point(22, 69);
            this.buttonZ.Name = "buttonZ";
            this.buttonZ.Size = new System.Drawing.Size(81, 32);
            this.buttonZ.TabIndex = 2;
            this.buttonZ.Text = "Забрать";
            this.buttonZ.UseVisualStyleBackColor = true;
            this.buttonZ.Click += new System.EventHandler(this.buttonZ_Click);
            // 
            // maskedTextBoxParking
            // 
            this.maskedTextBoxParking.Location = new System.Drawing.Point(51, 27);
            this.maskedTextBoxParking.Name = "maskedTextBoxParking";
            this.maskedTextBoxParking.Size = new System.Drawing.Size(58, 22);
            this.maskedTextBoxParking.TabIndex = 1;
            // 
            // labelParking
            // 
            this.labelParking.AutoSize = true;
            this.labelParking.Location = new System.Drawing.Point(0, 30);
            this.labelParking.Name = "labelParking";
            this.labelParking.Size = new System.Drawing.Size(53, 17);
            this.labelParking.TabIndex = 0;
            this.labelParking.Text = "Место:";
            // 
            // listBoxParking
            // 
            this.listBoxParking.FormattingEnabled = true;
            this.listBoxParking.ItemHeight = 16;
            this.listBoxParking.Location = new System.Drawing.Point(681, 269);
            this.listBoxParking.Name = "listBoxParking";
            this.listBoxParking.Size = new System.Drawing.Size(103, 68);
            this.listBoxParking.TabIndex = 4;
            this.listBoxParking.SelectedIndexChanged += new System.EventHandler(this.listBoxParking_SelectedIndexChanged);
            // 
            // textBoxParking
            // 
            this.textBoxParking.Location = new System.Drawing.Point(678, 241);
            this.textBoxParking.Name = "textBoxParking";
            this.textBoxParking.Size = new System.Drawing.Size(112, 22);
            this.textBoxParking.TabIndex = 5;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(678, 343);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(110, 30);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Добавить парковку";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(678, 379);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(113, 23);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonStack
            // 
            this.buttonStack.Location = new System.Drawing.Point(681, 408);
            this.buttonStack.Name = "buttonStack";
            this.buttonStack.Size = new System.Drawing.Size(100, 23);
            this.buttonStack.TabIndex = 8;
            this.buttonStack.Text = "Stack";
            this.buttonStack.UseVisualStyleBackColor = true;
            this.buttonStack.Click += new System.EventHandler(this.buttonStack_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.загрузитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.текущуюПарковкуToolStripMenuItem,
            this.всеПарковкиToolStripMenuItem});
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // текущуюПарковкуToolStripMenuItem
            // 
            this.текущуюПарковкуToolStripMenuItem.Name = "текущуюПарковкуToolStripMenuItem";
            this.текущуюПарковкуToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.текущуюПарковкуToolStripMenuItem.Text = "Текущую парковку";
            this.текущуюПарковкуToolStripMenuItem.Click += new System.EventHandler(this.текущуюПарковкуToolStripMenuItem_Click);
            // 
            // всеПарковкиToolStripMenuItem
            // 
            this.всеПарковкиToolStripMenuItem.Name = "всеПарковкиToolStripMenuItem";
            this.всеПарковкиToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.всеПарковкиToolStripMenuItem.Text = "Все парковки";
            this.всеПарковкиToolStripMenuItem.Click += new System.EventHandler(this.всеПарковкиToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.однуПарковкуToolStripMenuItem,
            this.всеПарковкиToolStripMenuItem1});
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            // 
            // однуПарковкуToolStripMenuItem
            // 
            this.однуПарковкуToolStripMenuItem.Name = "однуПарковкуToolStripMenuItem";
            this.однуПарковкуToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.однуПарковкуToolStripMenuItem.Text = "Одну парковку";
            this.однуПарковкуToolStripMenuItem.Click += new System.EventHandler(this.однуПарковкуToolStripMenuItem_Click);
            // 
            // всеПарковкиToolStripMenuItem1
            // 
            this.всеПарковкиToolStripMenuItem1.Name = "всеПарковкиToolStripMenuItem1";
            this.всеПарковкиToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.всеПарковкиToolStripMenuItem1.Text = "Все парковки";
            this.всеПарковкиToolStripMenuItem1.Click += new System.EventHandler(this.всеПарковкиToolStripMenuItem1_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "txt file | *.txt";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "txt file | *.txt";
            // 
            // FormParking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStack);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxParking);
            this.Controls.Add(this.listBoxParking);
            this.Controls.Add(this.groupBoxParking);
            this.Controls.Add(this.buttonModTank);
            this.Controls.Add(this.pictureBoxParking);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormParking";
            this.Text = "FormParking";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParking)).EndInit();
            this.groupBoxParking.ResumeLayout(false);
            this.groupBoxParking.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxParking;
        private System.Windows.Forms.Button buttonModTank;
        private System.Windows.Forms.GroupBox groupBoxParking;
        private System.Windows.Forms.Button buttonZ;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxParking;
        private System.Windows.Forms.Label labelParking;
        private System.Windows.Forms.ListBox listBoxParking;
        private System.Windows.Forms.TextBox textBoxParking;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonStack;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem текущуюПарковкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеПарковкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem однуПарковкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеПарковкиToolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}