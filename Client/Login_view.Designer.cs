
namespace Client
{
    partial class Login_view
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbStart = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(631, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập Tên Người Chơi: ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(628, 227);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(171, 35);
            this.textBox1.TabIndex = 1;
            // 
            // lbStart
            // 
            this.lbStart.AutoSize = true;
            this.lbStart.BackColor = System.Drawing.Color.Transparent;
            this.lbStart.Font = new System.Drawing.Font("Playfair Display", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbStart.Location = new System.Drawing.Point(357, 447);
            this.lbStart.Name = "lbStart";
            this.lbStart.Size = new System.Drawing.Size(171, 51);
            this.lbStart.TabIndex = 2;
            this.lbStart.Text = "BẮT ĐẦU";
            this.lbStart.Click += new System.EventHandler(this.lbStart_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(628, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 53);
            this.button1.TabIndex = 3;
            this.button1.Text = "Tạo Phòng";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(628, 348);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 58);
            this.button2.TabIndex = 4;
            this.button2.Text = "Tham gia phòng";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Login_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.client_login_BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(822, 545);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbStart);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Login_view";
            this.Text = "Login_view";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbStart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}