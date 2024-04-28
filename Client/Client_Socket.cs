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
        public static int Playerround = 1;
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
                    

                }
            }
        }
        public static ClientView GamePlay;
        public static Winner WinnerForm;
        public static List<OtherPlayers> otherPlayers;
        public static void AnalyzingReturnMessage(string msg)
        {
            string[] Payload = msg.Split(';');            
            switch(Payload[0])
            {
                case "LOBBYINFO":
                    {
                        Login_view.lobby.DisplayConnectedPlayer(Payload[1]);

                        //Kiem tra dieu kien khi da du nguoi moi duoc an nut start tro choi
                        if (Login_view.lobby.connectedPlayer == 3)
                            Login_view.lobby.Disable_Enable_Start(true);
                        else
                            Login_view.lobby.Disable_Enable_Start(false);
                    }
                    break;
                case "LOAD_QA":
                    {
                        GamePlay = new ClientView();                        
                        Login_view.lobby.Invoke((MethodInvoker)delegate ()
                        {
                            GamePlay.question = Payload[1];
                            GamePlay.answer = Payload[2];
                            GamePlay.round = Playerround.ToString();
                            GamePlay.Show();
                        }
                        );
                    }
                    break;
                case "INGAME": 
                    {
                        Player.turn = int.Parse(Payload[2]);
                        Player.score = int.Parse(Payload[3]);                                               
                        otherPlayers = new List<OtherPlayers>();
                        Login_view.lobby.Invoke((MethodInvoker)delegate ()
                        {
                            GamePlay.Text = Payload[1];
                            Login_view.lobby.Hide();
                        }
                        );                        
                    }
                    break;
                case "OTHERINFO":
                    {
                        OtherPlayers otherplayer = new OtherPlayers();
                        otherplayer.name = Payload[1];
                        otherplayer.turn = Payload[2];
                        otherplayer.score = Payload[3];
                        otherPlayers.Add(otherplayer);
                    }
                    break;
                case "SETUP":
                    {
                        GamePlay.Invoke((MethodInvoker)delegate ()
                        {
                            GamePlay.InGameDisplay();
                        }
                        );
                    }
                    break;
                case "TURN":
                    {                        
                        if (Payload[1] == Player.name)
                        {
                            GamePlay.Invoke((MethodInvoker)delegate ()
                            {                                
                                GamePlay.Allow_Playing();
                                GamePlay.Turn_Notify(Payload[1]);
                            }
                            );
                        }
                        else
                        {
                            GamePlay.Invoke((MethodInvoker)delegate ()
                            {
                                GamePlay.Turn_Notify(Payload[1]);
                            }
                            );
                        }

                    }
                    break;
                case "CR": //ANOTHER PLAYER CHOOSE RIGHT ANS
                    {
                        GamePlay.Invoke((MethodInvoker)delegate ()
                        {
                            GamePlay.Game_Update(Payload[1]);
                        }
                        );
                    }
                    break;
                case "CW": //ANOTHER PLAYER CHOOSE WRONG ANS
                    {                        
                        GamePlay.Invoke((MethodInvoker)delegate ()
                        {
                            GamePlay.Game_Update(Payload[1]);
                        }
                       );
                    }
                    break;
                case "SCORE_UPDATE": //UPDATE ANOTHER PLAYER'S SCORE
                    {                        
                        GamePlay.Invoke((MethodInvoker)delegate ()
                        {
                            GamePlay.Score_Update(Payload[1],Payload[2]);
                        }
                       );
                    }
                    break;
                case "NEW_ROUND":
                    {
                        Playerround = int.Parse(Payload[1]);
                        GamePlay.Invoke((MethodInvoker)delegate ()
                        {
                            GamePlay.Close();                                                            
                        }
                        );
                    }
                    break;
                case "ENDGAME":
                    {                        
                        GamePlay.Invoke((MethodInvoker)delegate ()
                        {
                            GamePlay.Close();
                        }
                        );
                        WinnerForm = new Winner();
                        Login_view.lobby.Invoke((MethodInvoker)delegate ()
                        {
                            WinnerForm.Show();
                            WinnerForm.UpdateWinner(Payload[1]);
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
