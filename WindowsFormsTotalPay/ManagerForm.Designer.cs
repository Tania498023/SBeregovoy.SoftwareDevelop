namespace WindowsFormsTotalPay
{
    partial class ManagerForm
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbUserNames = new System.Windows.Forms.ListBox();
            this.EnterRoles = new System.Windows.Forms.Label();
            this.EnterUsers = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.delButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.comboxPolzovatelName = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.EnterRole = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.EnterName = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbUserNames);
            this.tabPage2.Controls.Add(this.EnterRoles);
            this.tabPage2.Controls.Add(this.EnterUsers);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.delButton);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.comboBoxRole);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(838, 444);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbUserNames
            // 
            this.lbUserNames.FormattingEnabled = true;
            this.lbUserNames.ItemHeight = 16;
            this.lbUserNames.Location = new System.Drawing.Point(16, 121);
            this.lbUserNames.Name = "lbUserNames";
            this.lbUserNames.Size = new System.Drawing.Size(120, 84);
            this.lbUserNames.TabIndex = 38;
            // 
            // EnterRoles
            // 
            this.EnterRoles.AutoSize = true;
            this.EnterRoles.Location = new System.Drawing.Point(704, 406);
            this.EnterRoles.Name = "EnterRoles";
            this.EnterRoles.Size = new System.Drawing.Size(39, 16);
            this.EnterRoles.TabIndex = 37;
            this.EnterRoles.Text = "Роль";
            // 
            // EnterUsers
            // 
            this.EnterUsers.AutoSize = true;
            this.EnterUsers.Location = new System.Drawing.Point(650, 406);
            this.EnterUsers.Name = "EnterUsers";
            this.EnterUsers.Size = new System.Drawing.Size(33, 16);
            this.EnterUsers.TabIndex = 36;
            this.EnterUsers.Text = "Имя";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 16);
            this.label8.TabIndex = 35;
            this.label8.Text = "Список пользователей";
            this.label8.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(16, 219);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(419, 22);
            this.textBox3.TabIndex = 29;
            this.textBox3.Text = "Отчет по всем сотрудникам";
            this.textBox3.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(16, 338);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(419, 22);
            this.textBox4.TabIndex = 30;
            this.textBox4.Text = "Отчет по конкретному сотруднику";
            this.textBox4.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(481, 219);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(349, 31);
            this.button3.TabIndex = 31;
            this.button3.Text = "Сформировать";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(481, 338);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(349, 29);
            this.button4.TabIndex = 32;
            this.button4.Text = "Сформировать";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(481, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(349, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "Добавить нового пользователя";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Выберите роль";
            this.label3.Visible = false;
            // 
            // delButton
            // 
            this.delButton.Location = new System.Drawing.Point(481, 117);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(349, 37);
            this.delButton.TabIndex = 21;
            this.delButton.Text = "Удалить зарегистрированного пользователя";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Visible = false;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Введите пользователя";
            this.label2.Visible = false;
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Location = new System.Drawing.Point(191, 69);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(176, 24);
            this.comboBoxRole.TabIndex = 26;
            this.comboBoxRole.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.comboxPolzovatelName);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.EnterRole);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.textBox7);
            this.tabPage1.Controls.Add(this.EnterName);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(838, 444);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(475, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 16);
            this.label7.TabIndex = 35;
            this.label7.Text = "Список пользователей";
            this.label7.Visible = false;
            // 
            // comboxPolzovatelName
            // 
            this.comboxPolzovatelName.FormattingEnabled = true;
            this.comboxPolzovatelName.Location = new System.Drawing.Point(653, 11);
            this.comboxPolzovatelName.Name = "comboxPolzovatelName";
            this.comboxPolzovatelName.Size = new System.Drawing.Size(167, 24);
            this.comboxPolzovatelName.TabIndex = 34;
            this.comboxPolzovatelName.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(666, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Добавить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EnterRole
            // 
            this.EnterRole.AutoSize = true;
            this.EnterRole.Location = new System.Drawing.Point(70, 14);
            this.EnterRole.Name = "EnterRole";
            this.EnterRole.Size = new System.Drawing.Size(39, 16);
            this.EnterRole.TabIndex = 33;
            this.EnterRole.Text = "Роль";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(194, 130);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(48, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(258, 131);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(388, 21);
            this.textBox7.TabIndex = 24;
            // 
            // EnterName
            // 
            this.EnterName.AutoSize = true;
            this.EnterName.Location = new System.Drawing.Point(16, 14);
            this.EnterName.Name = "EnterName";
            this.EnterName.Size = new System.Drawing.Size(33, 16);
            this.EnterName.TabIndex = 32;
            this.EnterName.Text = "Имя";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(13, 132);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(160, 22);
            this.dateTimePicker1.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "Дата";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-531, -50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Добавить/просмотреть отработанное время";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "Работы";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "Часы";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 158);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(830, 278);
            this.dataGridView1.TabIndex = 25;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(846, 473);
            this.tabControl1.TabIndex = 34;
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 473);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ManagerForm";
            this.Text = "ManagerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManagerForm_FormClosing);
            this.Load += new System.EventHandler(this.ManagerForm_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label EnterRole;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label EnterName;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboxPolzovatelName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label EnterRoles;
        private System.Windows.Forms.Label EnterUsers;
        private System.Windows.Forms.ListBox lbUserNames;
    }
}