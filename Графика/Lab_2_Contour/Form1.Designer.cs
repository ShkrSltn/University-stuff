
namespace Lab_2_Contour
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
            this.L_3 = new System.Windows.Forms.Label();
            this.RTB_widch = new System.Windows.Forms.RichTextBox();
            this.L_2 = new System.Windows.Forms.Label();
            this.RTB_xmax = new System.Windows.Forms.RichTextBox();
            this.L_1 = new System.Windows.Forms.Label();
            this.RTB_xmin = new System.Windows.Forms.RichTextBox();
            this.Bt_1 = new System.Windows.Forms.Button();
            this.RTB_zmin = new System.Windows.Forms.TextBox();
            this.RTB_zmax = new System.Windows.Forms.TextBox();
            this.RTB_step = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // L_3
            // 
            this.L_3.AutoSize = true;
            this.L_3.Location = new System.Drawing.Point(1135, 9);
            this.L_3.Name = "L_3";
            this.L_3.Size = new System.Drawing.Size(84, 13);
            this.L_3.TabIndex = 20;
            this.L_3.Text = "толщина линии";
            // 
            // RTB_widch
            // 
            this.RTB_widch.Location = new System.Drawing.Point(1135, 28);
            this.RTB_widch.Name = "RTB_widch";
            this.RTB_widch.Size = new System.Drawing.Size(84, 20);
            this.RTB_widch.TabIndex = 19;
            this.RTB_widch.Text = "3";
            // 
            // L_2
            // 
            this.L_2.AutoSize = true;
            this.L_2.Location = new System.Drawing.Point(1094, 9);
            this.L_2.Name = "L_2";
            this.L_2.Size = new System.Drawing.Size(29, 13);
            this.L_2.TabIndex = 18;
            this.L_2.Text = "до X";
            // 
            // RTB_xmax
            // 
            this.RTB_xmax.Location = new System.Drawing.Point(1094, 28);
            this.RTB_xmax.Name = "RTB_xmax";
            this.RTB_xmax.Size = new System.Drawing.Size(35, 20);
            this.RTB_xmax.TabIndex = 17;
            this.RTB_xmax.Text = "4";
            // 
            // L_1
            // 
            this.L_1.AutoSize = true;
            this.L_1.Location = new System.Drawing.Point(1063, 9);
            this.L_1.Name = "L_1";
            this.L_1.Size = new System.Drawing.Size(28, 13);
            this.L_1.TabIndex = 16;
            this.L_1.Text = "от X";
            // 
            // RTB_xmin
            // 
            this.RTB_xmin.Location = new System.Drawing.Point(1063, 28);
            this.RTB_xmin.Name = "RTB_xmin";
            this.RTB_xmin.Size = new System.Drawing.Size(35, 20);
            this.RTB_xmin.TabIndex = 15;
            this.RTB_xmin.Text = "-4";
            // 
            // Bt_1
            // 
            this.Bt_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bt_1.Location = new System.Drawing.Point(1066, 109);
            this.Bt_1.Name = "Bt_1";
            this.Bt_1.Size = new System.Drawing.Size(157, 23);
            this.Bt_1.TabIndex = 14;
            this.Bt_1.Text = "Применить";
            this.Bt_1.UseVisualStyleBackColor = true;
            this.Bt_1.Click += new System.EventHandler(this.Click_BT_1);
            // 
            // RTB_zmin
            // 
            this.RTB_zmin.Location = new System.Drawing.Point(1066, 70);
            this.RTB_zmin.Name = "RTB_zmin";
            this.RTB_zmin.Size = new System.Drawing.Size(30, 20);
            this.RTB_zmin.TabIndex = 21;
            this.RTB_zmin.Text = "-1";
            // 
            // RTB_zmax
            // 
            this.RTB_zmax.Location = new System.Drawing.Point(1126, 70);
            this.RTB_zmax.Name = "RTB_zmax";
            this.RTB_zmax.Size = new System.Drawing.Size(30, 20);
            this.RTB_zmax.TabIndex = 22;
            this.RTB_zmax.Text = "1";
            // 
            // RTB_step
            // 
            this.RTB_step.Location = new System.Drawing.Point(1189, 70);
            this.RTB_step.Name = "RTB_step";
            this.RTB_step.Size = new System.Drawing.Size(30, 20);
            this.RTB_step.TabIndex = 23;
            this.RTB_step.Text = "0,5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1063, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "от Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1128, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "от Z";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1190, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Шаг";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 643);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RTB_step);
            this.Controls.Add(this.RTB_zmax);
            this.Controls.Add(this.RTB_zmin);
            this.Controls.Add(this.L_3);
            this.Controls.Add(this.RTB_widch);
            this.Controls.Add(this.L_2);
            this.Controls.Add(this.RTB_xmax);
            this.Controls.Add(this.L_1);
            this.Controls.Add(this.RTB_xmin);
            this.Controls.Add(this.Bt_1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label L_3;
        private System.Windows.Forms.RichTextBox RTB_widch;
        private System.Windows.Forms.Label L_2;
        private System.Windows.Forms.RichTextBox RTB_xmax;
        private System.Windows.Forms.Label L_1;
        private System.Windows.Forms.RichTextBox RTB_xmin;
        private System.Windows.Forms.Button Bt_1;
        private System.Windows.Forms.TextBox RTB_zmin;
        private System.Windows.Forms.TextBox RTB_zmax;
        private System.Windows.Forms.TextBox RTB_step;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

