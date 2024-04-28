
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
            this.SuspendLayout();
            // 
            // lbWinnerName
            // 
            this.lbWinnerName.AutoSize = true;
            this.lbWinnerName.BackColor = System.Drawing.Color.Transparent;
            this.lbWinnerName.Font = new System.Drawing.Font("Microsoft Himalaya", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWinnerName.ForeColor = System.Drawing.Color.Maroon;
            this.lbWinnerName.Location = new System.Drawing.Point(250, 248);
            this.lbWinnerName.Name = "lbWinnerName";
            this.lbWinnerName.Size = new System.Drawing.Size(116, 56);
            this.lbWinnerName.TabIndex = 1;
            this.lbWinnerName.Text = "Name";
            // 
            // Winner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = global::Client.Properties.Resources.Winner1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(620, 727);
            this.Controls.Add(this.lbWinnerName);
            this.DoubleBuffered = true;
            this.Name = "Winner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Winner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbWinnerName;
    }
}