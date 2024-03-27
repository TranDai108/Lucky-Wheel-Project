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
        string question = "Con gi vo duyen nhat the gioi ?";
        string answer = "CONNGUOI";
        
        public ClientView()
        {
            InitializeComponent();
            lbQuestion.Text = question;
        }        
        private void button1_Click(object sender, EventArgs e)
        {
            Wheel wheel = new Wheel();
            wheel.ShowDialog();
        }
        private void comment(string t)
        {
            int count_char = 0;
            for(int i = 0; i < answer.Length; i++)
            {
                if (answer[i].ToString() == t)
                    count_char++;
            }
            if (count_char > 0)
                lbComment.Text = "Có " + count_char + " ký tự " + t + " trong đáp án ";
            else
                lbComment.Text = "Không có ký tự " + t + " nào trong đáp án ";
        }

        //show dap an ket qua sau khi nguoi dung an vao
        private void show_ans(string t)
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox && control.Tag != null)
                {
                    if (control.Tag.ToString() == "Ans")
                    {
                        if (control.AccessibleName == t)
                            control.Text = t;
                    }    
                }
            }
        }

        private bool check_win()
        {
            int count_showed = 0;
            foreach (Control control in Controls)
            {
                if (control is TextBox && control.Text != "")
                {                    
                    count_showed++;
                }
            }
            if (count_showed == answer.Length)
            {
                MessageBox.Show("Bạn đã chiến thắng vòng chơi này !", "Thông báo", MessageBoxButtons.OK);
                this.Refresh();
                return true;
                
            }
            else
                return false;
        }
        private void btwWord_MouseClick(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.Visible = false;
            string text = button.Text;
            show_ans(text);
            comment(text);
            check_win();
            
        }

        private void ClientView_Load(object sender, EventArgs e)
        {
            int i = 0;
            int ans_length = answer.Length + 1;
            foreach(Control control in Controls)
            {
                if(control is TextBox && control.Tag != null)
                {
                    if (control.Tag.ToString() == "Ans")
                    {
                        ans_length--;

                    }
                    if (ans_length <= 0 && control.Tag.ToString() == "Ans")
                    {

                        control.Visible = false;
                    }
                    else
                    {
                        control.AccessibleName = answer[i].ToString();
                        i++;
                    }

                }
                
            }
        }

        private void ClientView_Leave(object sender, EventArgs e)
        {
            
        }
    }
}
