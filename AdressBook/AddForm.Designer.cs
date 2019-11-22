namespace AdressBook
{
    partial class AddForm
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
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.famTxt = new System.Windows.Forms.TextBox();
            this.octhTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.depCombo = new System.Windows.Forms.ComboBox();
            this.rankCombo = new System.Windows.Forms.ComboBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.addDol = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.emailTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(168, 14);
            this.nameTxt.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(180, 29);
            this.nameTxt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Фамилия ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Отчество";
            // 
            // famTxt
            // 
            this.famTxt.Location = new System.Drawing.Point(168, 64);
            this.famTxt.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.famTxt.Name = "famTxt";
            this.famTxt.Size = new System.Drawing.Size(180, 29);
            this.famTxt.TabIndex = 4;
            // 
            // octhTxt
            // 
            this.octhTxt.Location = new System.Drawing.Point(168, 115);
            this.octhTxt.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.octhTxt.Name = "octhTxt";
            this.octhTxt.Size = new System.Drawing.Size(180, 29);
            this.octhTxt.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Должность";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "Отдел";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 22);
            this.label6.TabIndex = 8;
            this.label6.Text = "Email";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // depCombo
            // 
            this.depCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.depCombo.FormattingEnabled = true;
            this.depCombo.Location = new System.Drawing.Point(169, 236);
            this.depCombo.Name = "depCombo";
            this.depCombo.Size = new System.Drawing.Size(180, 30);
            this.depCombo.TabIndex = 10;
            // 
            // rankCombo
            // 
            this.rankCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rankCombo.FormattingEnabled = true;
            this.rankCombo.Location = new System.Drawing.Point(169, 277);
            this.rankCombo.Name = "rankCombo";
            this.rankCombo.Size = new System.Drawing.Size(180, 30);
            this.rankCombo.TabIndex = 11;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(92, 333);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(189, 50);
            this.SaveBtn.TabIndex = 12;
            this.SaveBtn.Text = "Сохранить";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // addDol
            // 
            this.addDol.Location = new System.Drawing.Point(355, 277);
            this.addDol.Name = "addDol";
            this.addDol.Size = new System.Drawing.Size(107, 30);
            this.addDol.TabIndex = 14;
            this.addDol.Text = "Добавить";
            this.addDol.UseVisualStyleBackColor = true;
            this.addDol.Click += new System.EventHandler(this.addDol_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 22);
            this.label7.TabIndex = 15;
            this.label7.Text = "Телефон";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(168, 199);
            this.maskedTextBox1.Mask = "(999) 000-00-00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(180, 29);
            this.maskedTextBox1.TabIndex = 16;
            this.maskedTextBox1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // emailTxt
            // 
            this.emailTxt.Location = new System.Drawing.Point(169, 161);
            this.emailTxt.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(180, 29);
            this.emailTxt.TabIndex = 17;
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 393);
            this.Controls.Add(this.emailTxt);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.addDol);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.rankCombo);
            this.Controls.Add(this.depCombo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.octhTxt);
            this.Controls.Add(this.famTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameTxt);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "AddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление пользователя";
            this.Load += new System.EventHandler(this.AddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox famTxt;
        private System.Windows.Forms.TextBox octhTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox depCombo;
        private System.Windows.Forms.ComboBox rankCombo;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button addDol;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.TextBox emailTxt;
    }
}

