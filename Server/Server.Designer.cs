
namespace Server
{
    partial class Server
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
            this.rtbServer = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btFetchQuestion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbServer
            // 
            this.rtbServer.BackColor = System.Drawing.SystemColors.Info;
            this.rtbServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rtbServer.Location = new System.Drawing.Point(61, 97);
            this.rtbServer.Name = "rtbServer";
            this.rtbServer.Size = new System.Drawing.Size(672, 318);
            this.rtbServer.TabIndex = 0;
            this.rtbServer.Text = "Vui lòng chọn file câu hỏi trước khi chơi (file json)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightPink;
            this.label1.Location = new System.Drawing.Point(330, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "SERVER";
            // 
            // btFetchQuestion
            // 
            this.btFetchQuestion.BackColor = System.Drawing.Color.Pink;
            this.btFetchQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFetchQuestion.Location = new System.Drawing.Point(570, 41);
            this.btFetchQuestion.Name = "btFetchQuestion";
            this.btFetchQuestion.Size = new System.Drawing.Size(163, 48);
            this.btFetchQuestion.TabIndex = 2;
            this.btFetchQuestion.Text = "Nạp câu hỏi";
            this.btFetchQuestion.UseVisualStyleBackColor = false;
            this.btFetchQuestion.Click += new System.EventHandler(this.btFetchQuestion_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btFetchQuestion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbServer);
            this.Name = "Server";
            this.Text = "Server Notification";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btFetchQuestion;
    }
}

