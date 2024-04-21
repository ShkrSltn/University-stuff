
namespace Lab1
{
    partial class Form1
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
            this.Bt_1 = new System.Windows.Forms.Button();
            this.RTB_1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.L_1 = new System.Windows.Forms.Label();
            this.L_2 = new System.Windows.Forms.Label();
            this.RTB_2 = new System.Windows.Forms.RichTextBox();
            this.RTB_3 = new System.Windows.Forms.RichTextBox();
            this.L_3 = new System.Windows.Forms.Label();
            this.ColorB_red = new System.Windows.Forms.Button();
            this.L_4 = new System.Windows.Forms.Label();
            this.ColorB_yellow = new System.Windows.Forms.Button();
            this.ColorB_blue = new System.Windows.Forms.Button();
            this.ColorB_green = new System.Windows.Forms.Button();
            this.ColorB_brown = new System.Windows.Forms.Button();
            this.ColorB_black = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Bt_1
            // 
            this.Bt_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bt_1.Location = new System.Drawing.Point(1046, 124);
            this.Bt_1.Name = "Bt_1";
            this.Bt_1.Size = new System.Drawing.Size(262, 23);
            this.Bt_1.TabIndex = 0;
            this.Bt_1.Text = "Применить";
            this.Bt_1.UseVisualStyleBackColor = true;
            this.Bt_1.Click += new System.EventHandler(this.Click_BT_1);
            // 
            // RTB_1
            // 
            this.RTB_1.Location = new System.Drawing.Point(1046, 30);
            this.RTB_1.Name = "RTB_1";
            this.RTB_1.Size = new System.Drawing.Size(35, 20);
            this.RTB_1.TabIndex = 1;
            this.RTB_1.Text = "-4";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // L_1
            // 
            this.L_1.AutoSize = true;
            this.L_1.Location = new System.Drawing.Point(1046, 11);
            this.L_1.Name = "L_1";
            this.L_1.Size = new System.Drawing.Size(18, 13);
            this.L_1.TabIndex = 2;
            this.L_1.Text = "от";
            // 
            // L_2
            // 
            this.L_2.AutoSize = true;
            this.L_2.Location = new System.Drawing.Point(1077, 11);
            this.L_2.Name = "L_2";
            this.L_2.Size = new System.Drawing.Size(19, 13);
            this.L_2.TabIndex = 4;
            this.L_2.Text = "до";
            // 
            // RTB_2
            // 
            this.RTB_2.Location = new System.Drawing.Point(1077, 30);
            this.RTB_2.Name = "RTB_2";
            this.RTB_2.Size = new System.Drawing.Size(35, 20);
            this.RTB_2.TabIndex = 3;
            this.RTB_2.Text = "4";
            // 
            // RTB_3
            // 
            this.RTB_3.Location = new System.Drawing.Point(1118, 30);
            this.RTB_3.Name = "RTB_3";
            this.RTB_3.Size = new System.Drawing.Size(85, 20);
            this.RTB_3.TabIndex = 5;
            this.RTB_3.Text = "3";
            // 
            // L_3
            // 
            this.L_3.AutoSize = true;
            this.L_3.Location = new System.Drawing.Point(1118, 11);
            this.L_3.Name = "L_3";
            this.L_3.Size = new System.Drawing.Size(84, 13);
            this.L_3.TabIndex = 6;
            this.L_3.Text = "толщина линии";
            // 
            // ColorB_red
            // 
            this.ColorB_red.BackColor = System.Drawing.Color.Red;
            this.ColorB_red.Location = new System.Drawing.Point(1046, 81);
            this.ColorB_red.Name = "ColorB_red";
            this.ColorB_red.Size = new System.Drawing.Size(25, 25);
            this.ColorB_red.TabIndex = 7;
            this.ColorB_red.UseVisualStyleBackColor = false;
            this.ColorB_red.Click += new System.EventHandler(this.Color_Click);
            // 
            // L_4
            // 
            this.L_4.AutoSize = true;
            this.L_4.Location = new System.Drawing.Point(1046, 62);
            this.L_4.Name = "L_4";
            this.L_4.Size = new System.Drawing.Size(65, 13);
            this.L_4.TabIndex = 8;
            this.L_4.Text = "Цвет линии";
            // 
            // ColorB_yellow
            // 
            this.ColorB_yellow.BackColor = System.Drawing.Color.Yellow;
            this.ColorB_yellow.Location = new System.Drawing.Point(1077, 81);
            this.ColorB_yellow.Name = "ColorB_yellow";
            this.ColorB_yellow.Size = new System.Drawing.Size(25, 25);
            this.ColorB_yellow.TabIndex = 9;
            this.ColorB_yellow.UseVisualStyleBackColor = false;
            this.ColorB_yellow.Click += new System.EventHandler(this.Color_Click);
            // 
            // ColorB_blue
            // 
            this.ColorB_blue.BackColor = System.Drawing.Color.Blue;
            this.ColorB_blue.Location = new System.Drawing.Point(1108, 81);
            this.ColorB_blue.Name = "ColorB_blue";
            this.ColorB_blue.Size = new System.Drawing.Size(25, 25);
            this.ColorB_blue.TabIndex = 10;
            this.ColorB_blue.UseVisualStyleBackColor = false;
            this.ColorB_blue.Click += new System.EventHandler(this.Color_Click);
            // 
            // ColorB_green
            // 
            this.ColorB_green.BackColor = System.Drawing.Color.Green;
            this.ColorB_green.Location = new System.Drawing.Point(1139, 81);
            this.ColorB_green.Name = "ColorB_green";
            this.ColorB_green.Size = new System.Drawing.Size(25, 25);
            this.ColorB_green.TabIndex = 11;
            this.ColorB_green.UseVisualStyleBackColor = false;
            this.ColorB_green.Click += new System.EventHandler(this.Color_Click);
            // 
            // ColorB_brown
            // 
            this.ColorB_brown.BackColor = System.Drawing.Color.Brown;
            this.ColorB_brown.Location = new System.Drawing.Point(1170, 81);
            this.ColorB_brown.Name = "ColorB_brown";
            this.ColorB_brown.Size = new System.Drawing.Size(25, 25);
            this.ColorB_brown.TabIndex = 12;
            this.ColorB_brown.UseVisualStyleBackColor = false;
            this.ColorB_brown.Click += new System.EventHandler(this.Color_Click);
            // 
            // ColorB_black
            // 
            this.ColorB_black.BackColor = System.Drawing.Color.Black;
            this.ColorB_black.Location = new System.Drawing.Point(1201, 81);
            this.ColorB_black.Name = "ColorB_black";
            this.ColorB_black.Size = new System.Drawing.Size(25, 25);
            this.ColorB_black.TabIndex = 13;
            this.ColorB_black.UseVisualStyleBackColor = false;
            this.ColorB_black.Click += new System.EventHandler(this.Color_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 693);
            this.Controls.Add(this.ColorB_black);
            this.Controls.Add(this.ColorB_brown);
            this.Controls.Add(this.ColorB_green);
            this.Controls.Add(this.ColorB_blue);
            this.Controls.Add(this.ColorB_yellow);
            this.Controls.Add(this.L_4);
            this.Controls.Add(this.ColorB_red);
            this.Controls.Add(this.L_3);
            this.Controls.Add(this.RTB_3);
            this.Controls.Add(this.L_2);
            this.Controls.Add(this.RTB_2);
            this.Controls.Add(this.L_1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RTB_1);
            this.Controls.Add(this.Bt_1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Bt_1;
        private System.Windows.Forms.RichTextBox RTB_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label L_1;
        private System.Windows.Forms.Label L_2;
        private System.Windows.Forms.RichTextBox RTB_2;
        private System.Windows.Forms.RichTextBox RTB_3;
        private System.Windows.Forms.Label L_3;
        private System.Windows.Forms.Button ColorB_red;
        private System.Windows.Forms.Label L_4;
        private System.Windows.Forms.Button ColorB_yellow;
        private System.Windows.Forms.Button ColorB_blue;
        private System.Windows.Forms.Button ColorB_green;
        private System.Windows.Forms.Button ColorB_brown;
        private System.Windows.Forms.Button ColorB_black;
    }
}

