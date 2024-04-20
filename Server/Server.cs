using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private static string question;
        private static string answer;
        private static string questionPath;
        public Server()
        {
            InitializeComponent();
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
            serverSocket.Bind(serverEP);
            serverSocket.Listen(3);
            rtbServer.Text += "Waiting for connection from players ... \r\n";         
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
                case "DISCONNECT":
                    {
                        // Remove the disconnected player from list
                        foreach (var player in connectedPlayers.ToList())
                        {
                            if (player.name == arrPayload[1])
                            {
                                player.playerSocket.Shutdown(SocketShutdown.Both);
                                player.playerSocket.Close();
                                connectedPlayers.Remove(player);
                            }
                        }
                    }
                    break;
                case "START":
                    {
                        randomQuestion();
                        foreach (var player in connectedPlayers)
                        {                            
                            string makemsg = "LOAD_QA;" + question + ";" + answer ;
                            byte[] buffer = Encoding.UTF8.GetBytes(makemsg);
                            player.playerSocket.Send(buffer);
                            Thread.Sleep(100);
                        }
                        SetUpPlayerTurn();
                        connectedPlayers.Sort((x, y) => x.turn.CompareTo(y.turn));                        
                        foreach (var player in connectedPlayers)
                        {                            
                            string makemsg = "INGAME;" + player.name + ";" + player.turn + ";" + player.score;
                            byte[] buffer = Encoding.UTF8.GetBytes(makemsg);
                            player.playerSocket.Send(buffer);                            
                            Thread.Sleep(100);
                        }


                        foreach (var player in connectedPlayers)
                        {
                            foreach (var player_ in connectedPlayers)
                            {
                                if (player.name != player_.name)
                                {
                                    string makemsg = "OTHERINFO;" + player_.name + ";" + player_.turn + ";" + player.score;
                                    byte[] buffer = Encoding.UTF8.GetBytes(makemsg);
                                    player.playerSocket.Send(buffer);
                                    Console.WriteLine("Sendback: " + makemsg);
                                    Thread.Sleep(100);
                                }
                            }
                        }

                        foreach (var player in connectedPlayers)
                        {
                            string makemsg = "SETUP;" + player.name;
                            byte[] buffer = Encoding.UTF8.GetBytes(makemsg);
                            player.playerSocket.Send(buffer);
                            Console.WriteLine("Sendback: " + makemsg);
                            Thread.Sleep(100);
                        }

                        foreach (var player in connectedPlayers)
                        {
                            string makemsg_ = "TURN;" + connectedPlayers[currentturn - 1].name;
                            byte[] buffer_ = Encoding.UTF8.GetBytes(makemsg_);
                            player.playerSocket.Send(buffer_);
                            Console.WriteLine("Sendback: " + makemsg_);
                            Thread.Sleep(100);
                        }
                    }
                    break;
                case "CHOOSE_RIGHT":
                    {                        
                        foreach (var player in connectedPlayers)
                        {
                            if (player.playerSocket != p.playerSocket)
                            {
                                byte[] buffer = Encoding.UTF8.GetBytes("CR;" + arrPayload[1]);
                                player.playerSocket.Send(buffer);                                
                            }
                        }
                    }
                    break;
                case "CHOOSE_WRONG":
                    {
                        // Bugs ngay lan quay thu 2 
                        currentturn++;
                        if (currentturn > 3)
                            currentturn = 1;
                        foreach (var player in connectedPlayers)
                        {
                            byte[] buffer = Encoding.UTF8.GetBytes("CW;" + arrPayload[1]);
                            player.playerSocket.Send(buffer);
                            Thread.Sleep(100);
                            buffer = Encoding.UTF8.GetBytes("TURN;" + connectedPlayers[currentturn - 1].name);
                            player.playerSocket.Send(buffer);
                        }
                    }
                    break;
                case "SCORE_CHANGED":
                    {
                        foreach (var player in connectedPlayers)
                        {
                            if (player.playerSocket != p.playerSocket)
                            {
                                byte[] buffer = Encoding.UTF8.GetBytes("SCORE_UPDATE;" + arrPayload[1] + ";" + arrPayload[2]);
                                player.playerSocket.Send(buffer);                                
                            }
                        }
                    }
                    break;
                default:
                    break;

            }
        }


        public static void randomQuestion()
        {
            // Lấy filepath hiện tại và gán file questions.json vào 
            //string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions18.json");

            // Đọc nội dung từ tệp JSON
            string jsonText = File.ReadAllText(questionPath);
            
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
        }

        private static void SetUpPlayerTurn()
        {
            int i = 1;
            foreach (var player in connectedPlayers)
            {
                player.turn = i;
                i++;
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

        private void btFetchQuestion_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Đường dẫn của file được chọn
                questionPath = openFileDialog.FileName;                
                
            }
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            serverSocket.Close();
            serverlisten.Abort();
            clientThread.Abort();
        }
    }
}

