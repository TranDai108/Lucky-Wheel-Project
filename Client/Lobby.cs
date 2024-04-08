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
        public List<PictureBox> PlayerIcon = new List<PictureBox>();
        public int connectedPlayer = 0;
        public Lobby()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            lobby = this;
            btnStart.Visible = false;
        }
        public void ShowStartButton()
        {
            btnStart.Visible = true;
        }
        public void Tempdisplay(string msg)
        {
            richTextBox1.Text += msg + '\n';
        }

        public void DisplayConnectedPlayer(string name)
        {
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
        private void btnStart_Click(object sender, EventArgs e)
        {
            ClientSocket.datatype = "START";
            ClientSocket.SendMessage("");
        }
        private void btnLeave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
