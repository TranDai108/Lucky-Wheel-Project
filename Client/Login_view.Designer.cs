
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbStart = new System.Windows.Forms.Label();
            this.btCreate = new System.Windows.Forms.Button();
            this.btJoin = new System.Windows.Forms.Button();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(618, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập Tên Người Chơi: ";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(619, 120);
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(171, 35);
            this.tbName.TabIndex = 1;
            this.tbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbStart
            // 
            this.lbStart.AutoSize = true;
            this.lbStart.BackColor = System.Drawing.Color.Transparent;
            this.lbStart.Font = new System.Drawing.Font("Palatino Linotype", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbStart.ForeColor = System.Drawing.Color.Yellow;
            this.lbStart.Location = new System.Drawing.Point(160, 432);
            this.lbStart.Name = "lbStart";
            this.lbStart.Size = new System.Drawing.Size(500, 55);
            this.lbStart.TabIndex = 2;
            this.lbStart.Text = "VÒNG QUAY MAY MẮN";
            // 
            // btCreate
            // 
            this.btCreate.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCreate.Location = new System.Drawing.Point(621, 273);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(169, 61);
            this.btCreate.TabIndex = 3;
            this.btCreate.Text = "Tạo Phòng";
            this.btCreate.UseVisualStyleBackColor = false;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // btJoin
            // 
            this.btJoin.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btJoin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btJoin.Location = new System.Drawing.Point(620, 352);
            this.btJoin.Name = "btJoin";
            this.btJoin.Size = new System.Drawing.Size(170, 58);
            this.btJoin.TabIndex = 4;
            this.btJoin.Text = "Tham gia phòng";
            this.btJoin.UseVisualStyleBackColor = false;
            this.btJoin.Click += new System.EventHandler(this.btJoin_Click);
            // 
            // textBoxIP
            // 
            this.textBoxIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIP.Location = new System.Drawing.Point(619, 198);
            this.textBoxIP.Multiline = true;
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(171, 38);
            this.textBoxIP.TabIndex = 5;
            this.textBoxIP.Text = "127.0.0.1";
            this.textBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(617, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Địa chỉ IP phòng";
            // 
            // Login_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.client_login_BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(823, 519);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.btJoin);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.lbStart);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Name = "Login_view";
            this.Text = "Login_view";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbStart;
        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.Button btJoin;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label label2;
    }
}