
namespace Lab_1_IA
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Essences_text = new System.Windows.Forms.RichTextBox();
            this.Relation_text = new System.Windows.Forms.RichTextBox();
            this.Knowledge_text = new System.Windows.Forms.RichTextBox();
            this.num_1 = new System.Windows.Forms.TextBox();
            this.num_2 = new System.Windows.Forms.TextBox();
            this.num_3 = new System.Windows.Forms.TextBox();
            this.Answer_text = new System.Windows.Forms.RichTextBox();
            this.Request_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Essences_text
            // 
            this.Essences_text.Location = new System.Drawing.Point(12, 264);
            this.Essences_text.Name = "Essences_text";
            this.Essences_text.Size = new System.Drawing.Size(306, 395);
            this.Essences_text.TabIndex = 1;
            this.Essences_text.Text = "";
            // 
            // Relation_text
            // 
            this.Relation_text.Location = new System.Drawing.Point(491, 264);
            this.Relation_text.Name = "Relation_text";
            this.Relation_text.Size = new System.Drawing.Size(306, 395);
            this.Relation_text.TabIndex = 2;
            this.Relation_text.Text = "";
            // 
            // Knowledge_text
            // 
            this.Knowledge_text.Location = new System.Drawing.Point(949, 264);
            this.Knowledge_text.Name = "Knowledge_text";
            this.Knowledge_text.Size = new System.Drawing.Size(306, 395);
            this.Knowledge_text.TabIndex = 3;
            this.Knowledge_text.Text = "";
            // 
            // num_1
            // 
            this.num_1.Location = new System.Drawing.Point(418, 33);
            this.num_1.Name = "num_1";
            this.num_1.Size = new System.Drawing.Size(100, 23);
            this.num_1.TabIndex = 4;
            // 
            // num_2
            // 
            this.num_2.Location = new System.Drawing.Point(579, 34);
            this.num_2.Name = "num_2";
            this.num_2.Size = new System.Drawing.Size(100, 23);
            this.num_2.TabIndex = 5;
            // 
            // num_3
            // 
            this.num_3.Location = new System.Drawing.Point(744, 34);
            this.num_3.Name = "num_3";
            this.num_3.Size = new System.Drawing.Size(100, 23);
            this.num_3.TabIndex = 6;
            // 
            // Answer_text
            // 
            this.Answer_text.Location = new System.Drawing.Point(387, 63);
            this.Answer_text.Name = "Answer_text";
            this.Answer_text.Size = new System.Drawing.Size(519, 96);
            this.Answer_text.TabIndex = 7;
            this.Answer_text.Text = "";
            // 
            // Request_btn
            // 
            this.Request_btn.Location = new System.Drawing.Point(920, 33);
            this.Request_btn.Name = "Request_btn";
            this.Request_btn.Size = new System.Drawing.Size(75, 23);
            this.Request_btn.TabIndex = 8;
            this.Request_btn.Text = "Ответ";
            this.Request_btn.UseVisualStyleBackColor = true;
            this.Request_btn.Click += new System.EventHandler(this.onAnswer);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 671);
            this.Controls.Add(this.Request_btn);
            this.Controls.Add(this.Answer_text);
            this.Controls.Add(this.num_3);
            this.Controls.Add(this.num_2);
            this.Controls.Add(this.num_1);
            this.Controls.Add(this.Knowledge_text);
            this.Controls.Add(this.Relation_text);
            this.Controls.Add(this.Essences_text);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.onLoadForm);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Essences_text;
        private System.Windows.Forms.RichTextBox Relation_text;
        private System.Windows.Forms.RichTextBox Knowledge_text;
        private System.Windows.Forms.TextBox num_1;
        private System.Windows.Forms.TextBox num_2;
        private System.Windows.Forms.TextBox num_3;
        private System.Windows.Forms.RichTextBox Answer_text;
        private System.Windows.Forms.Button Request_btn;
    }
}

