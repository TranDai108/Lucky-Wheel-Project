using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        private static Socket serverSocket;
        private Socket client;
        private static Thread clientThread;
        private static Thread serverlisten;
        private static List<Player> connectedPlayers = new List<Player>();

        private static int currentturn = 1;

        public Server()
        {
            InitializeComponent();
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
            serverSocket.Bind(serverEP);
            serverSocket.Listen(3);
            rtbServer.Text = "Waiting for connection from players ... \r\n";         
        }
        
        public void recvfromClientsocket(Socket client)
        {
            
            Player player = new Player();
            player.playerSocket = client;
            connectedPlayers.Add(player);
            byte[] buffer = new byte[4096];

            while (player.playerSocket.Connected)
            {
                if (player.playerSocket.Available > 0)
                {
                    string message = "";
                    while (player.playerSocket.Available > 0)
                    {
                        int ReadfromBuffer = player.playerSocket.Receive(buffer);
                        message += Encoding.UTF8.GetString(buffer, 0, ReadfromBuffer);
                    }                    
                    UpdateRichTextBox(player.playerSocket.RemoteEndPoint + ": " + message); // Thêm dòng này để cập nhật RichTextBox
                    AnalyzingMess(message, player);
                }
            }

        }

        public static void AnalyzingMess(string mess, Player p)
        {
            string[] arrPayload = mess.Split(';');

            //arrPayload[0]: always indicates client's message type ( using for different types of reply )
            //arrPayload[1]: always indicates the name of client
            //arrPayload[..]: .... ( depends on client's message type )


            switch (arrPayload[0])
            {
                case "CONNECT":
                    {
                        p.name = arrPayload[1];
                        foreach (var player in connectedPlayers)
                        {
                            byte[] buffer = Encoding.UTF8.GetBytes("LOBBYINFO;" + player.name);
                            p.playerSocket.Send(buffer);
                            Thread.Sleep(100);
                        }

                        foreach (var player in connectedPlayers)
                        {
                            if (player.playerSocket != p.playerSocket)
                            {
                                byte[] buffer = Encoding.UTF8.GetBytes("LOBBYINFO;" + p.name);
                                player.playerSocket.Send(buffer);
                                Thread.Sleep(100);
                            }
                        }
                    }
                    break;
                default:
                    break;

            }
        }
        private void UpdateRichTextBox(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateRichTextBox), message);
                return;
            }

            rtbServer.Text += message + Environment.NewLine;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serverlisten = new Thread(() =>
            {
                while (true)
                {
                    client = serverSocket.Accept();
                    UpdateRichTextBox("New connection from " + client.RemoteEndPoint);
                    clientThread = new Thread(() => recvfromClientsocket(client));
                    clientThread.Start();
                }
            });
            serverlisten.Start();
        }
    }
}

