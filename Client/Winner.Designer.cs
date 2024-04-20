
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
            this.lbNotify = new System.Windows.Forms.Label();
            this.lbWinnerName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbNotify
            // 
            this.lbNotify.AutoSize = true;
            this.lbNotify.Location = new System.Drawing.Point(365, 135);
            this.lbNotify.Name = "lbNotify";
            this.lbNotify.Size = new System.Drawing.Size(74, 20);
            this.lbNotify.TabIndex = 0;
            this.lbNotify.Text = "WINNER";
            // 
            // lbWinnerName
            // 
            this.lbWinnerName.AutoSize = true;
            this.lbWinnerName.Location = new System.Drawing.Point(353, 231);
            this.lbWinnerName.Name = "lbWinnerName";
            this.lbWinnerName.Size = new System.Drawing.Size(99, 20);
            this.lbWinnerName.TabIndex = 1;
            this.lbWinnerName.Text = "winner name";
            // 
            // Winner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbWinnerName);
            this.Controls.Add(this.lbNotify);
            this.Name = "Winner";
            this.Text = "Winner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNotify;
        private System.Windows.Forms.Label lbWinnerName;
    }
}