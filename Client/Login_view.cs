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

        private void button1_Click(object sender, EventArgs e)
        {
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse(textBoxIP.Text), 11000);
            ClientSocket.datatype = "CONNECT";
            ClientSocket.Connect(serverEP);
            lobby = new Lobby();
            ClientSocket.SendMessage(textBoxName.Text);

            Player.name = textBoxName.Text;

            lobby.FormClosed += new FormClosedEventHandler(Login_view_FormClosed);
            lobby.ShowStartButton();
            this.Hide();
            lobby.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse(textBoxIP.Text), 11000);
            ClientSocket.datatype = "CONNECT";
            ClientSocket.Connect(serverEP);
            lobby = new Lobby();
            ClientSocket.SendMessage(textBoxName.Text);

            Player.name = textBoxName.Text;

            lobby.FormClosed += new FormClosedEventHandler(Login_view_FormClosed);
            this.Hide();
            lobby.Show();
        }

        private void Login_view_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClientSocket.datatype = "DISCONNECT";
            ClientSocket.SendMessage(Player.name);
            ClientSocket.clientSocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
            ClientSocket.clientSocket.Close();
            this.Show();
        }
    }
}
