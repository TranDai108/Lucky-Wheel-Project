using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientView : Form
    {
        private Size initialFormSize;
        public ClientView()
        {
            InitializeComponent();
            initialFormSize = this.Size;
            // Gắn sự kiện SizeChanged cho form
            this.SizeChanged += Form1_SizeChanged;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            // Tính tỉ lệ thay đổi của kích thước form so với kích thước ban đầu
            float widthRatio = (float)this.Size.Width / (float)initialFormSize.Width;
            float heightRatio = (float)this.Size.Height / (float)initialFormSize.Height;

            // Điều chỉnh kích thước của các control tương ứng
            foreach (Control control in this.Controls)
            {
                float x = control.Location.X;
                float y = control.Location.Y;
                control.Width = (int)(control.Width * widthRatio);
                control.Height = (int)(control.Height * heightRatio);
                control.Location = new System.Drawing.Point((int)(x * widthRatio), (int)(y * heightRatio));
            }

            // Lưu kích thước hiện tại của form để sử dụng cho lần thay đổi tiếp theo
            initialFormSize = this.Size;
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            btnA.Visible = false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
