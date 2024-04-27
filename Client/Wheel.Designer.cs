
namespace Client
{
    partial class Wheel
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
            this.btSpin = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btRes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btSpin
            // 
            this.btSpin.BackColor = System.Drawing.Color.Firebrick;
            this.btSpin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSpin.ForeColor = System.Drawing.Color.Black;
            this.btSpin.Location = new System.Drawing.Point(256, 544);
            this.btSpin.Name = "btSpin";
            this.btSpin.Size = new System.Drawing.Size(178, 62);
            this.btSpin.TabIndex = 2;
            this.btSpin.Text = "QUAY";
            this.btSpin.UseVisualStyleBackColor = false;
            this.btSpin.Click += new System.EventHandler(this.btSpin_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Client.Properties.Resources.arrow;
            this.pictureBox2.Location = new System.Drawing.Point(293, 173);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(99, 46);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Client.Properties.Resources.wheel_update;
            this.pictureBox1.InitialImage = global::Client.Properties.Resources.wheel_new;
            this.pictureBox1.Location = new System.Drawing.Point(161, 190);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(364, 316);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btRes
            // 
            this.btRes.BackColor = System.Drawing.Color.Linen;
            this.btRes.Enabled = false;
            this.btRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRes.ForeColor = System.Drawing.Color.Black;
            this.btRes.Location = new System.Drawing.Point(256, 486);
            this.btRes.Name = "btRes";
            this.btRes.Size = new System.Drawing.Size(178, 41);
            this.btRes.TabIndex = 4;
            this.btRes.Text = "...";
            this.btRes.UseVisualStyleBackColor = false;
            this.btRes.Click += new System.EventHandler(this.btRes_Click);
            // 
            // Wheel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BackgroundImage = global::Client.Properties.Resources.Wheel_BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(688, 730);
            this.Controls.Add(this.btRes);
            this.Controls.Add(this.btSpin);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "Wheel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wheel";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btSpin;
        private System.Windows.Forms.Button btRes;
    }
}