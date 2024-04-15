namespace Client
{
    partial class Lobby
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
            this.rtbNotify = new System.Windows.Forms.RichTextBox();
            this.btLeave = new System.Windows.Forms.Button();
            this.groupBoxP3 = new System.Windows.Forms.GroupBox();
            this.pictureBoxP3 = new System.Windows.Forms.PictureBox();
            this.labelP3 = new System.Windows.Forms.Label();
            this.groupBoxP2 = new System.Windows.Forms.GroupBox();
            this.labelP2 = new System.Windows.Forms.Label();
            this.pictureBoxP2 = new System.Windows.Forms.PictureBox();
            this.groupBoxP1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxP1 = new System.Windows.Forms.PictureBox();
            this.labelP1 = new System.Windows.Forms.Label();
            this.btStart = new System.Windows.Forms.Button();
            this.groupBoxP3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxP3)).BeginInit();
            this.groupBoxP2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxP2)).BeginInit();
            this.groupBoxP1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxP1)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbNotify
            // 
            this.rtbNotify.Location = new System.Drawing.Point(795, 71);
            this.rtbNotify.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtbNotify.Name = "rtbNotify";
            this.rtbNotify.Size = new System.Drawing.Size(310, 374);
            this.rtbNotify.TabIndex = 12;
            this.rtbNotify.Text = "";
            // 
            // btLeave
            // 
            this.btLeave.Location = new System.Drawing.Point(448, 474);
            this.btLeave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btLeave.Name = "btLeave";
            this.btLeave.Size = new System.Drawing.Size(130, 52);
            this.btLeave.TabIndex = 11;
            this.btLeave.Text = "Thoát phòng";
            this.btLeave.UseVisualStyleBackColor = true;
            this.btLeave.Click += new System.EventHandler(this.btLeave_Click);
            // 
            // groupBoxP3
            // 
            this.groupBoxP3.Controls.Add(this.pictureBoxP3);
            this.groupBoxP3.Controls.Add(this.labelP3);
            this.groupBoxP3.Location = new System.Drawing.Point(530, 60);
            this.groupBoxP3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxP3.Name = "groupBoxP3";
            this.groupBoxP3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxP3.Size = new System.Drawing.Size(259, 385);
            this.groupBoxP3.TabIndex = 8;
            this.groupBoxP3.TabStop = false;
            this.groupBoxP3.Text = "PLAYER 3";
            // 
            // pictureBoxP3
            // 
            this.pictureBoxP3.Location = new System.Drawing.Point(23, 74);
            this.pictureBoxP3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxP3.Name = "pictureBoxP3";
            this.pictureBoxP3.Size = new System.Drawing.Size(214, 238);
            this.pictureBoxP3.TabIndex = 2;
            this.pictureBoxP3.TabStop = false;
            // 
            // labelP3
            // 
            this.labelP3.AutoSize = true;
            this.labelP3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP3.Location = new System.Drawing.Point(108, 341);
            this.labelP3.Name = "labelP3";
            this.labelP3.Size = new System.Drawing.Size(30, 26);
            this.labelP3.TabIndex = 1;
            this.labelP3.Text = "...";
            // 
            // groupBoxP2
            // 
            this.groupBoxP2.Controls.Add(this.labelP2);
            this.groupBoxP2.Controls.Add(this.pictureBoxP2);
            this.groupBoxP2.Location = new System.Drawing.Point(280, 60);
            this.groupBoxP2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxP2.Name = "groupBoxP2";
            this.groupBoxP2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxP2.Size = new System.Drawing.Size(243, 385);
            this.groupBoxP2.TabIndex = 9;
            this.groupBoxP2.TabStop = false;
            this.groupBoxP2.Text = "PLAYER 2";
            // 
            // labelP2
            // 
            this.labelP2.AutoSize = true;
            this.labelP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP2.Location = new System.Drawing.Point(108, 341);
            this.labelP2.Name = "labelP2";
            this.labelP2.Size = new System.Drawing.Size(30, 26);
            this.labelP2.TabIndex = 3;
            this.labelP2.Text = "...";
            // 
            // pictureBoxP2
            // 
            this.pictureBoxP2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxP2.Location = new System.Drawing.Point(15, 74);
            this.pictureBoxP2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxP2.Name = "pictureBoxP2";
            this.pictureBoxP2.Size = new System.Drawing.Size(214, 238);
            this.pictureBoxP2.TabIndex = 2;
            this.pictureBoxP2.TabStop = false;
            // 
            // groupBoxP1
            // 
            this.groupBoxP1.Controls.Add(this.pictureBoxP1);
            this.groupBoxP1.Controls.Add(this.labelP1);
            this.groupBoxP1.Location = new System.Drawing.Point(31, 60);
            this.groupBoxP1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxP1.Name = "groupBoxP1";
            this.groupBoxP1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxP1.Size = new System.Drawing.Size(243, 385);
            this.groupBoxP1.TabIndex = 7;
            this.groupBoxP1.TabStop = false;
            this.groupBoxP1.Text = "PLAYER 1";
            // 
            // pictureBoxP1
            // 
            this.pictureBoxP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxP1.Location = new System.Drawing.Point(15, 74);
            this.pictureBoxP1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxP1.Name = "pictureBoxP1";
            this.pictureBoxP1.Size = new System.Drawing.Size(214, 238);
            this.pictureBoxP1.TabIndex = 1;
            this.pictureBoxP1.TabStop = false;
            // 
            // labelP1
            // 
            this.labelP1.AutoSize = true;
            this.labelP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP1.Location = new System.Drawing.Point(108, 341);
            this.labelP1.Name = "labelP1";
            this.labelP1.Size = new System.Drawing.Size(30, 26);
            this.labelP1.TabIndex = 0;
            this.labelP1.Text = "...";
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(219, 474);
            this.btStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(132, 52);
            this.btStart.TabIndex = 6;
            this.btStart.Text = "Bắt đầu ";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 607);
            this.Controls.Add(this.rtbNotify);
            this.Controls.Add(this.btLeave);
            this.Controls.Add(this.groupBoxP3);
            this.Controls.Add(this.groupBoxP2);
            this.Controls.Add(this.groupBoxP1);
            this.Controls.Add(this.btStart);
            this.Name = "Lobby";
            this.Text = "Lobby";
            this.groupBoxP3.ResumeLayout(false);
            this.groupBoxP3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxP3)).EndInit();
            this.groupBoxP2.ResumeLayout(false);
            this.groupBoxP2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxP2)).EndInit();
            this.groupBoxP1.ResumeLayout(false);
            this.groupBoxP1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxP1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbNotify;
        private System.Windows.Forms.Button btLeave;
        private System.Windows.Forms.GroupBox groupBoxP3;
        private System.Windows.Forms.PictureBox pictureBoxP3;
        private System.Windows.Forms.Label labelP3;
        private System.Windows.Forms.GroupBox groupBoxP2;
        private System.Windows.Forms.Label labelP2;
        private System.Windows.Forms.PictureBox pictureBoxP2;
        private System.Windows.Forms.GroupBox groupBoxP1;
        private System.Windows.Forms.PictureBox pictureBoxP1;
        private System.Windows.Forms.Label labelP1;
        private System.Windows.Forms.Button btStart;
    }
}