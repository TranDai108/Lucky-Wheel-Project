
namespace Client
{
    partial class Winner
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
            this.lbWinnerName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbWinnerName
            // 
            this.lbWinnerName.AutoSize = true;
            this.lbWinnerName.BackColor = System.Drawing.Color.Transparent;
            this.lbWinnerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWinnerName.ForeColor = System.Drawing.Color.White;
            this.lbWinnerName.Location = new System.Drawing.Point(353, 245);
            this.lbWinnerName.Name = "lbWinnerName";
            this.lbWinnerName.Size = new System.Drawing.Size(103, 46);
            this.lbWinnerName.TabIndex = 1;
            this.lbWinnerName.Text = "TÊN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(179, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(470, 51);
            this.label1.TabIndex = 2;
            this.label1.Text = "CONGRATULATIONS";
            // 
            // Winner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = global::Client.Properties.Resources.winner;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbWinnerName);
            this.Name = "Winner";
            this.Text = "Winner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbWinnerName;
        private System.Windows.Forms.Label label1;
    }
}