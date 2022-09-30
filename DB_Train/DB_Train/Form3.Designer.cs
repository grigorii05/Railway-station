namespace DB_Train
{
    partial class Form3
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
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.to = new System.Windows.Forms.ComboBox();
            this.from = new System.Windows.Forms.ComboBox();
            this.dates = new System.Windows.Forms.ComboBox();
            this.places = new System.Windows.Forms.ComboBox();
            this.wagons = new System.Windows.Forms.ComboBox();
            this.trains = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FIO = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.WorE = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.types = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(122, 350);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 13);
            this.label16.TabIndex = 64;
            this.label16.Text = "Цена";
            this.label16.UseWaitCursor = true;
            this.label16.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(131, 301);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 13);
            this.label15.TabIndex = 63;
            this.label15.Text = "Время_приб";
            this.label15.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(158, 259);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 62;
            this.label14.Text = "Время_отпр";
            this.label14.Visible = false;
            // 
            // to
            // 
            this.to.FormattingEnabled = true;
            this.to.Location = new System.Drawing.Point(319, 26);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(121, 21);
            this.to.TabIndex = 61;
            // 
            // from
            // 
            this.from.FormattingEnabled = true;
            this.from.Location = new System.Drawing.Point(176, 26);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(121, 21);
            this.from.TabIndex = 60;
            // 
            // dates
            // 
            this.dates.FormattingEnabled = true;
            this.dates.Location = new System.Drawing.Point(645, 107);
            this.dates.Name = "dates";
            this.dates.Size = new System.Drawing.Size(121, 21);
            this.dates.TabIndex = 59;
            // 
            // places
            // 
            this.places.FormattingEnabled = true;
            this.places.Location = new System.Drawing.Point(501, 106);
            this.places.Name = "places";
            this.places.Size = new System.Drawing.Size(121, 21);
            this.places.TabIndex = 58;
            // 
            // wagons
            // 
            this.wagons.FormattingEnabled = true;
            this.wagons.Location = new System.Drawing.Point(349, 106);
            this.wagons.Name = "wagons";
            this.wagons.Size = new System.Drawing.Size(121, 21);
            this.wagons.TabIndex = 57;
            // 
            // trains
            // 
            this.trains.FormattingEnabled = true;
            this.trains.Location = new System.Drawing.Point(28, 106);
            this.trains.Name = "trains";
            this.trains.Size = new System.Drawing.Size(121, 21);
            this.trains.TabIndex = 55;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(615, 331);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 54;
            this.label13.Text = "Билет куплен";
            this.label13.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(615, 356);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(175, 13);
            this.label12.TabIndex = 53;
            this.label12.Text = "Недостаточно средств на карте !";
            this.label12.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(33, 350);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 52;
            this.label11.Text = "Цена билета:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(456, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 38);
            this.button1.TabIndex = 51;
            this.button1.Text = "Купить билет";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 301);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "Время прибытия:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 259);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 13);
            this.label10.TabIndex = 49;
            this.label10.Text = "Время отправления:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "Направление(Восток или Запад)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(316, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 47;
            this.label6.Text = "Куда";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(195, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "Откуда";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(642, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Дата";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(498, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "№ места";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "№ вагона";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "№ поезда";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 133);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 50);
            this.button2.TabIndex = 65;
            this.button2.Text = "Перейти к выбору вагона";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(28, 200);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(187, 43);
            this.button3.TabIndex = 75;
            this.button3.Text = "Узнать время и цену билета";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "Тип вагона";
            // 
            // FIO
            // 
            this.FIO.Location = new System.Drawing.Point(456, 294);
            this.FIO.Name = "FIO";
            this.FIO.Size = new System.Drawing.Size(100, 20);
            this.FIO.TabIndex = 78;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(453, 268);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 13);
            this.label17.TabIndex = 79;
            this.label17.Text = "ФИО";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(344, 133);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 50);
            this.button4.TabIndex = 80;
            this.button4.Text = "Перейти к выбору места";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // WorE
            // 
            this.WorE.FormattingEnabled = true;
            this.WorE.Location = new System.Drawing.Point(12, 25);
            this.WorE.Name = "WorE";
            this.WorE.Size = new System.Drawing.Size(121, 21);
            this.WorE.TabIndex = 81;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(316, 268);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 13);
            this.label18.TabIndex = 83;
            this.label18.Text = "Пароль";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(319, 294);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 82;
            // 
            // types
            // 
            this.types.FormattingEnabled = true;
            this.types.Location = new System.Drawing.Point(176, 109);
            this.types.Name = "types";
            this.types.Size = new System.Drawing.Size(121, 21);
            this.types.TabIndex = 84;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 390);
            this.Controls.Add(this.types);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.WorE);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.FIO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.to);
            this.Controls.Add(this.from);
            this.Controls.Add(this.dates);
            this.Controls.Add(this.places);
            this.Controls.Add(this.wagons);
            this.Controls.Add(this.trains);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Form3";
            this.Text = "Покупка билета";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox to;
        private System.Windows.Forms.ComboBox from;
        private System.Windows.Forms.ComboBox dates;
        private System.Windows.Forms.ComboBox places;
        private System.Windows.Forms.ComboBox wagons;
        private System.Windows.Forms.ComboBox trains;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FIO;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox WorE;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox types;
    }
}