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
            ClientView client = new ClientView(tbName.Text);
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
            lobby = new Lobby();
            lobby.Show();
        }

        private void btJoin_Click(object sender, EventArgs e)
        {

        }
    }
}
