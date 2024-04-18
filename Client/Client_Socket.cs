using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Client
{
    public class Client_Socket
    {
        public static Socket clientSocket;
        public static Thread recvThread;
        public static string datatype = ""; // Kieu du lieu nguoi choi gui cho server

        public static void Connect(IPEndPoint serverEP)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverEP);
            recvThread = new Thread(() => readingReturnData());
            recvThread.Start();
        }

        public static void SendMessage(string data)
        {
            string msgstr = datatype + ";" + data;
            byte[] msg = Encoding.UTF8.GetBytes(msgstr);
            clientSocket.Send(msg);
        }
        public static void readingReturnData()
        {
            byte[] buffer = new byte[1024];

            while (clientSocket.Connected)
            {
                if (clientSocket.Available > 0)
                {
                    string msg = "";

                    while (clientSocket.Available > 0)
                    {
                        int bRead = clientSocket.Receive(buffer);
                        msg += Encoding.UTF8.GetString(buffer, 0, bRead);
                    }

                    AnalyzingReturnMessage(msg);
                    Login_view.lobby.Tempdisplay(msg);
                }
            }
            //Terminate this receiving thread when clientSocket is disconnected
            //recvThread.Abort();
        }
        public static ClientView GamePlay;
        public static List<OtherPlayers> otherPlayers;
        public static void AnalyzingReturnMessage(string msg)
        {
            string[] Payload = msg.Split(';');

            switch(Payload[0])
            {
                case "LOBBYINFO":
                    {
                        Login_view.lobby.DisplayConnectedPlayer(Payload[1]);
                    }
                    break;
                case "LOAD_QA":
                    {
                        GamePlay = new ClientView();                        
                        Login_view.lobby.Invoke((MethodInvoker)delegate ()
                        {
                            GamePlay.question = Payload[1];
                            GamePlay.answer = Payload[2];                            
                            GamePlay.Show();
                        }
                        );
                    }
                    break;
                case "INGAME": //need to fix bugs 
                    {
                        Player.turn = int.Parse(Payload[2]);
                        Player.score = int.Parse(Payload[3]);                                               
                        otherPlayers = new List<OtherPlayers>();
                        Login_view.lobby.Invoke((MethodInvoker)delegate ()
                        {
                            GamePlay.Text = Payload[1];
                        }
                        );
                        
                    }
                    break;
                default:
                    break;
            }

        }
    }

}
