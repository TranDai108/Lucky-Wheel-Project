using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Lobby : Form
    {
        public Lobby lobby;
        public List<PictureBox> PlayerIcons = new List<PictureBox>();
        public int connectedPlayer = 0;
        public Lobby()
        {
            InitializeComponent();
            //Khoa kiem tra luong de khong bi Cross-thread
            CheckForIllegalCrossThreadCalls = false;
            lobby = this;
            btStart.Visible = false;

            PlayerIcons.Add(pictureBoxP1);
            PlayerIcons.Add(pictureBoxP2);
            PlayerIcons.Add(pictureBoxP3);
        }
        public void ShowStartButton()
        {
            btStart.Visible = true;
        }
        public void Disable_Enable_Start(bool check)
        {
            if (check == true)
                btStart.Enabled = true;
            else
                btStart.Enabled = false;
        }
        public void DisplayConnectedPlayer(string name)
        {
            PlayerIcons[connectedPlayer].Image = Properties.Resources.avatar_default_icon;
            PlayerIcons[connectedPlayer].SizeMode = PictureBoxSizeMode.StretchImage;
            connectedPlayer++;                        
            switch (connectedPlayer)
            {
                case 1:
                    labelP1.Text = name;
                    break;
                case 2:
                    labelP2.Text = name;
                    break;
                case 3:
                    labelP3.Text = name;
                    break;
                default:
                    break;
            }
        }               
        private void btStart_Click(object sender, EventArgs e)
        {
            Client_Socket.datatype = "START";
            Client_Socket.SendMessage("");
        }
        
        private void btLeave_Click(object sender, EventArgs e)
        {
            connectedPlayer--;            
            
            this.Close();
        }
    }
}
