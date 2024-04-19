using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client
{
    public partial class Login_view : Form
    {
        public static Lobby lobby;
        public Login_view()
        {
            InitializeComponent();
        }

        private void lbStart_Click(object sender, EventArgs e)
        {
            ClientView client = new ClientView();
            client.ShowDialog();
        }

        private void Login_view_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*ClientSocket.datatype = "DISCONNECT";
            ClientSocket.SendMessage(Player.name);
            ClientSocket.clientSocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
            ClientSocket.clientSocket.Close();
            this.Show();*/
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            if(tbName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên người chơi trước khi thamg gia", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            lobby = new Lobby();
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse(textBoxIP.Text), 11000);
            Client_Socket.datatype = "CONNECT";
            Client_Socket.Connect(serverEP);
            Player.name = tbName.Text;
            Client_Socket.SendMessage(Player.name);
            lobby.ShowStartButton();
            lobby.FormClosed += new FormClosedEventHandler(lobby_FormClosed);
            this.Hide();
            lobby.Show();
        }

        void lobby_FormClosed(object sender, EventArgs e)
        {
            Client_Socket.datatype = "DISCONNECT";
            Client_Socket.SendMessage(Player.name);
            Client_Socket.clientSocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
            Client_Socket.clientSocket.Close();
            this.Show();
        }

        private void btJoin_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên người chơi trước khi thamg gia", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse(textBoxIP.Text), 11000);
            Client_Socket.datatype = "CONNECT";
            Client_Socket.Connect(serverEP);
            lobby = new Lobby();
            Client_Socket.SendMessage(tbName.Text);

            Player.name = tbName.Text;

            lobby.FormClosed += new FormClosedEventHandler(lobby_FormClosed);
            this.Hide();
            lobby.Show();
        }
    }
}
