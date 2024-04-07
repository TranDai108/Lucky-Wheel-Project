using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;
namespace Client
{
    public partial class ClientView : Form
    {

        public string question = "";
        public string answer = "";
        private string wheel_res; // Wheel result
        public ClientView()
        {
            InitializeComponent();
            randomQuestion();
        }

        public void randomQuestion()
        {
            // Đọc nội dung từ tệp JSON
            string jsonText = File.ReadAllText(@"C:\Users\Admin\source\repos\Lucky-Wheel-Project\questions.json");

            // Phân tích nội dung JSON
            JObject json = JObject.Parse(jsonText);

            // Lấy ra mảng các câu hỏi từ đối tượng JSON
            JArray questionsArray = (JArray)json["questions"];

            // Chọn ngẫu nhiên một câu hỏi từ mảng
            Random random = new Random();
            int randomIndex = random.Next(0, questionsArray.Count);
            JObject randomQuestionObject = (JObject)questionsArray[randomIndex];

            question = (string)randomQuestionObject["question"];
            answer = (string)randomQuestionObject["answer"];
            lbQuestion.Text = question;
        }

        //An chon vong quay
        private void btWheel_Click(object sender, EventArgs e)
        {
            Wheel wheel = new Wheel();
            
            wheel.ShowDialog();
            wheel_res = wheel.get_res();
            tbScore.Text = wheel_res;
            foreach (Control control in Controls)
            {
                if (control is Button && control.Name != "btWheel")
                    control.Enabled = true;
            }
        }
        
        //Enable/Disable vong quay
        private void changeState_wheel(bool state)
        {
            if (state == true)
                btWheel.Enabled = false;
            else
                btWheel.Enabled = true;
        }

        //check  dap an va comment 
        private bool comment(string t)
        {
            int count_char = 0;
            for(int i = 0; i < answer.Length; i++)
            {
                if (answer[i].ToString() == t)
                    count_char++;
            }
            if (count_char > 0)
            {
                //Neu nguoi choi chon dung, duoc chon tiep 
                lbComment.Text = "Có " + count_char + " ký tự " + t + " trong đáp án, bạn được quyền trả lời tiếp ";
                changeState_wheel(false);
                return true;
            }
                
            else
            {
                // Neu nguoi choi chon sai, mat luot, chuyen sang luot choi cua nguoi choi tiep theo 
                lbComment.Text = "Không có ký tự " + t + " nào trong đáp án, bạn bị mất lượt ";
                changeState_wheel(true);
                return false;
            }
         
        }

        //Su kien khi an vao 1 phim chu cai
        private void btwWord_MouseClick(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.Visible = false;
            string input = button.Text;
            show_ans(input);
            allowState_button(comment(input));
            check_win();
        }

        //Show dap an ket qua sau khi nguoi dung an vao button 
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

        //Chuyen trang thai button (enable / disable)
        private void allowState_button(bool check)
        {
            if(check == false) // tra loi sai khong duoc chon dap an nua
            {
                foreach (Control control in Controls)
                {
                    if (control is Button && control.Name != "btWheel")
                        control.Enabled = false;
                    if (control is Button && control.Name == "btWheel")
                        control.Enabled = false;
                }
            }
            else // tra loi dung lan luot thuc hien quay vong quay roi moi chon dap an
            {
                foreach (Control control in Controls)
                {
                    if (control is Button && control.Name != "btWheel")
                        control.Enabled = false;
                    if (control is Button && control.Name == "btWheel")
                        control.Enabled = true;
                }
            }
            
        }

        //Kiem tra dieu kien da chien thang hay chua (neu o chu da hoan thien thi chien thang)
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
            if (count_showed == answer.Length+1)
            {
                MessageBox.Show("Bạn đã chiến thắng vòng chơi này !", "Thông báo", MessageBoxButtons.OK);
                this.Refresh();
                return true;
                
            }
            else
                return false;
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
            allowState_button(true);
        }       

        
    }
}
