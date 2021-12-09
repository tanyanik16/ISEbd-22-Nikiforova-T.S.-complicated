namespace WindowsFormsApp1
{
    partial class FormTank
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCreate = new System.Windows.Forms.Button();
            this.pictureBoxTanks = new System.Windows.Forms.PictureBox();
            this.comboRod = new System.Windows.Forms.ComboBox();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonCreateModTank = new System.Windows.Forms.Button();
            this.groupBoxF = new System.Windows.Forms.GroupBox();
            this.checkBoxTriangle = new System.Windows.Forms.CheckBox();
            this.checkBoxRound = new System.Windows.Forms.CheckBox();
            this.checkBoxRectangle = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTanks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxF.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(638, 205);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(130, 32);
            this.buttonCreate.TabIndex = 0;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.Create_Click);
            // 
            // pictureBoxTanks
            // 
            this.pictureBoxTanks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxTanks.ErrorImage = null;
            this.pictureBoxTanks.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTanks.Name = "pictureBoxTanks";
            this.pictureBoxTanks.Size = new System.Drawing.Size(800, 450);
            this.pictureBoxTanks.TabIndex = 1;
            this.pictureBoxTanks.TabStop = false;
            // 
            // comboRod
            // 
            this.comboRod.FormattingEnabled = true;
            this.comboRod.Location = new System.Drawing.Point(622, 246);
            this.comboRod.Margin = new System.Windows.Forms.Padding(4);
            this.comboRod.Name = "comboRod";
            this.comboRod.Size = new System.Drawing.Size(156, 24);
            this.comboRod.TabIndex = 2;
            this.comboRod.Text = "Кол-во орудия";
            // 
            // buttonDown
            // 
            this.buttonDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDown.Location = new System.Drawing.Point(688, 382);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(30, 39);
            this.buttonDown.TabIndex = 3;
            this.buttonDown.Text = "button1";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonLeft.Location = new System.Drawing.Point(633, 382);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(30, 39);
            this.buttonLeft.TabIndex = 4;
            this.buttonLeft.Text = "button2";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRight.Location = new System.Drawing.Point(740, 382);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(28, 39);
            this.buttonRight.TabIndex = 5;
            this.buttonRight.Text = "button3";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUp.Location = new System.Drawing.Point(688, 338);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(30, 38);
            this.buttonUp.TabIndex = 6;
            this.buttonUp.Text = "button4";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(801, 448);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // buttonCreateModTank
            // 
            this.buttonCreateModTank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateModTank.Location = new System.Drawing.Point(640, 156);
            this.buttonCreateModTank.Name = "buttonCreateModTank";
            this.buttonCreateModTank.Size = new System.Drawing.Size(127, 43);
            this.buttonCreateModTank.TabIndex = 7;
            this.buttonCreateModTank.Text = "Создать мод.танк";
            this.buttonCreateModTank.UseVisualStyleBackColor = true;
            this.buttonCreateModTank.Click += new System.EventHandler(this.buttonCreateModTank_Click);
            // 
            // groupBoxF
            // 
            this.groupBoxF.Controls.Add(this.checkBoxTriangle);
            this.groupBoxF.Controls.Add(this.checkBoxRound);
            this.groupBoxF.Controls.Add(this.checkBoxRectangle);
            this.groupBoxF.Location = new System.Drawing.Point(635, 15);
            this.groupBoxF.Name = "groupBoxF";
            this.groupBoxF.Size = new System.Drawing.Size(142, 128);
            this.groupBoxF.TabIndex = 9;
            this.groupBoxF.TabStop = false;
            this.groupBoxF.Text = "groupBox1";
            // 
            // checkBoxTriangle
            // 
            this.checkBoxTriangle.AutoSize = true;
            this.checkBoxTriangle.Location = new System.Drawing.Point(16, 81);
            this.checkBoxTriangle.Name = "checkBoxTriangle";
            this.checkBoxTriangle.Size = new System.Drawing.Size(116, 21);
            this.checkBoxTriangle.TabIndex = 2;
            this.checkBoxTriangle.Text = "Треугольные";
            this.checkBoxTriangle.UseVisualStyleBackColor = true;
            // 
            // checkBoxRound
            // 
            this.checkBoxRound.AutoSize = true;
            this.checkBoxRound.Location = new System.Drawing.Point(16, 55);
            this.checkBoxRound.Name = "checkBoxRound";
            this.checkBoxRound.Size = new System.Drawing.Size(85, 21);
            this.checkBoxRound.TabIndex = 1;
            this.checkBoxRound.Text = "Круглые";
            this.checkBoxRound.UseVisualStyleBackColor = true;
            // 
            // checkBoxRectangle
            // 
            this.checkBoxRectangle.AutoSize = true;
            this.checkBoxRectangle.Location = new System.Drawing.Point(16, 28);
            this.checkBoxRectangle.Name = "checkBoxRectangle";
            this.checkBoxRectangle.Size = new System.Drawing.Size(111, 21);
            this.checkBoxRectangle.TabIndex = 0;
            this.checkBoxRectangle.Text = "Квадратные";
            this.checkBoxRectangle.UseVisualStyleBackColor = true;
            // 
            // FormTank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxF);
            this.Controls.Add(this.buttonCreateModTank);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.comboRod);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.pictureBoxTanks);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormTank";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTanks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxF.ResumeLayout(false);
            this.groupBoxF.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.PictureBox pictureBoxTanks;
        private System.Windows.Forms.ComboBox comboRod;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonCreateModTank;
        private System.Windows.Forms.GroupBox groupBoxF;
        private System.Windows.Forms.CheckBox checkBoxTriangle;
        private System.Windows.Forms.CheckBox checkBoxRound;
        private System.Windows.Forms.CheckBox checkBoxRectangle;
    }
}

