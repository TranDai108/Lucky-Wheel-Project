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
using System.Threading;

namespace Client
{
    
    public partial class ClientView : Form
    {
        public Player player;
        public string question { get; set; }
        public string answer { get; set; }
        public string round { get; set; }
        public List<Label> lbNames;
        public List<TextBox> tbScores;
        private int score = 0;
        
        private string wheel_res; // Wheel result
        public ClientView()
        {
            InitializeComponent();            
        }
        //Ham public 
        public void InGameDisplay()
        {
            //Luu tru thong tin cua cac Players khac va hien thi theo thu tu
            Client_Socket.otherPlayers.Sort((x, y) => x.turn.CompareTo(y.turn));
            if (Player.turn == 1)
            {
                lbName.Text = Player.name;
                tbScore.Text = Player.score.ToString();
                tbScore.Tag = Player.name;

                lbName2.Text = Client_Socket.otherPlayers[0].name;
                tbScore2.Text = Client_Socket.otherPlayers[0].score;
                tbScore2.Tag = lbName2.Text;

                lbName3.Text = Client_Socket.otherPlayers[1].name;
                tbScore3.Text = Client_Socket.otherPlayers[1].score;
                tbScore3.Tag = lbName3.Text;
            }
            else if(Player.turn == 2)
            {
                lbName.Text = Player.name;
                tbScore.Text = Player.score.ToString();
                tbScore.Tag = Player.name;

                lbName2.Text = Client_Socket.otherPlayers[0].name;
                tbScore2.Text = Client_Socket.otherPlayers[0].score;
                tbScore2.Tag = lbName2.Text;

                lbName3.Text = Client_Socket.otherPlayers[1].name;
                tbScore3.Text = Client_Socket.otherPlayers[1].score;
                tbScore3.Tag = lbName3.Text;
            }
            else if (Player.turn == 3)
            {
                lbName.Text = Player.name;
                tbScore.Text = Player.score.ToString();
                tbScore.Tag = Player.name;

                lbName2.Text = Client_Socket.otherPlayers[0].name;
                tbScore2.Text = Client_Socket.otherPlayers[0].score;
                tbScore2.Tag = lbName2.Text;

                lbName3.Text = Client_Socket.otherPlayers[1].name;
                tbScore3.Text = Client_Socket.otherPlayers[1].score;
                tbScore3.Tag = lbName3.Text;
            }                                
        }
        public void Allow_Playing()
        {
            allowState_button(true);
        }
        //Xu ly Score sau khi quay vong quay
        public void ScoreHandle(string scoreEvent)
        {
            switch(scoreEvent)
            {
                case "+100":
                    {
                        score += 100;
                    }
                    break;
                case "+200":
                    {
                        score += 200; 
                    }
                    break;
                case "+300":
                    {
                        score += 300;
                    }
                    break;
                case "+1000":
                    {
                        score += 1000;
                    }
                    break;
                case "x2":
                    {
                        score *= 2;
                    }
                    break;
                case "Chia đôi":
                    {
                        score /= 2;
                    }
                    break;                
            }
        }
        public void Turn_Notify(string Name)
        {
            Thread.Sleep(1500);
            if(Player.name == Name)
            {
                lbComment.Text = "Tới lượt của bạn \r\n";                
                lbComment.Text += "Vui lòng xoay vòng quay trước khi trả lời";
            }
            else
                lbComment.Text = "Tới lượt của " + Name;
        }
        public void Game_Update(string Character) //UPDATE UI 
        {
            //Cap nhat an di o chu ma nguoi choi khac da chon
            foreach (Control control in Controls)
            {
                if (control is Button && control.Tag != null && control.Tag.ToString() == "Character")
                    if (control.Text == Character)
                        control.Visible = false;
            }
            show_ans(Character);

            //Kiem tra o chu da duoc dien day du hay chua
            int count_showed = 0;
            foreach (Control control in Controls)
            {
                if (control is TextBox && control.Text != "" && control.Tag != null && control.Tag.ToString() == "Ans")
                {
                    count_showed++;
                }
            }
            if (count_showed == answer.Length)
            {
                //Gui totalScore cua player hien tai cho Server khi vong choi ket thuc
                Player.totalScore += int.Parse(tbScore.Text);
                Client_Socket.datatype = "TOTAL_SCORE";
                Client_Socket.SendMessage(Player.name + ";" + Player.totalScore.ToString());
            }
        }

        //Cap nhat diem cua nguoi choi khac khi co thay doi
        public void Score_Update(string Name, string Score)
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox && control.Tag != null && control.Tag.ToString() == Name)
                    control.Text = Score;
            }
        }
        
        //Ham Private
        //An chon vong quay
        private void btWheel_Click(object sender, EventArgs e)
        {
            Wheel wheel = new Wheel();
            
            wheel.ShowDialog();
            wheel_res = wheel.get_res();
            ScoreHandle(wheel_res);
            if(wheel_res == "Mất lượt")
            {
                Client_Socket.datatype = "ENDTURN";
                Client_Socket.SendMessage(Player.name);
                allowState_button(false);
            }
            else
            {                
                foreach (Control control in Controls)
                {
                    if (control is Button && control.Name != "btWheel")
                        control.Enabled = true;
                }
                btWheel.Enabled = false;
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
        //Check dap an va comment 
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
                // Neu nguoi choi chon dung, duoc chon tiep 
                lbComment.Text = "Có " + count_char + " ký tự " + t + " trong đáp án, bạn được quyền trả lời tiếp ";
                
                tbScore.Text = score.ToString();
                Player.score = int.Parse(tbScore.Text);
                
                Client_Socket.datatype = "CHOOSE_RIGHT";                
                Thread.Sleep(100);
                Client_Socket.SendMessage(t);

                //Don't enable the wheel
                changeState_wheel(false);
                return true;
            }                
            else
            {
                // Neu nguoi choi chon sai, mat luot, chuyen sang luot choi cua nguoi choi tiep theo 
                score = Player.score;
                lbComment.Text = "Không có ký tự " + t + " nào trong đáp án, bạn bị mất lượt ";                

                Client_Socket.datatype = "CHOOSE_WRONG";                
                Thread.Sleep(100);
                Client_Socket.SendMessage(t);

                //Enable the wheel
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
                if (control is TextBox && control.Tag != null && control.Tag.ToString() == "Ans")
                {
                    if (control.AccessibleName == t)
                        control.Text = t;
                }
            }
        }

        private void tbScore_TextChanged(object sender, EventArgs e)
        {
            Client_Socket.datatype = "SCORE_CHANGED";
            string data = Player.name + ";" + tbScore.Text;            
            Client_Socket.SendMessage(data);
            
        }
        
        //Chuyen trang thai button (enable / disable)
        private void allowState_button(bool check)
        {
            if(check == false) // Tra loi sai khong duoc chon dap an nua
            {
                foreach (Control control in Controls)
                {
                    if (control is Button)
                        control.Enabled = false;                    
                }
            }
            else // Tra loi dung lan luot thuc hien quay vong quay roi moi chon dap an
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
        private void check_win()
        {
            int count_showed = 0;
            foreach (Control control in Controls)
            {
                if (control is TextBox && control.Text != "" && control.Tag != null && control.Tag.ToString() == "Ans")
                {                    
                    count_showed++;
                }
            }
            if (count_showed == answer.Length)
            {
                Player.totalScore += int.Parse(tbScore.Text);
                MessageBox.Show("Bạn đã chiến thắng vòng chơi này !", "Thông báo", MessageBoxButtons.OK);
                Thread.Sleep(1500);
                Client_Socket.datatype = "WIN_ROUND";
                Client_Socket.SendMessage(Player.name + ";" + Player.totalScore.ToString());                                                                
            }            
        }   

        private void ClientView_Load(object sender, EventArgs e)
        {            
            int i = 0;
            lbQuestion.Text = question;
            tbRound.Text = round;
            int ans_length = answer.Length + 1;

            //Hien thi so luong o chu tuong ung voi dap an
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
            allowState_button(false);
        }
        
    }
}
