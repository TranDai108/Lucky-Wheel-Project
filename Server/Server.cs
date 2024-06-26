﻿using Newtonsoft.Json.Linq;
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
        private static List<string> UsedQuestions = new List<string>();

        private static int currentturn = 1;
        private static int currentround = 1;
        private static string question;
        private static string answer;
        private static string questionPath;
        public Server()
        {
            InitializeComponent();            
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverEP = new IPEndPoint(ipAddress, 11000);
            serverSocket.Bind(serverEP);
            serverSocket.Listen(3);
            rtbServer.Text += "Chờ đợi kết nối từ người chơi ... \r\n";         
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
                        try
                        {
                            randomQuestion();
                        }
                        catch(Exception)
                        {
                            MessageBox.Show("Vui lòng chọn file gói câu hỏi trước khi bắt đầu trò chơi !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
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
                                byte[] buffer = Encoding.UTF8.GetBytes("CR;" + arrPayload[1]); //CR + character
                                player.playerSocket.Send(buffer);                                
                            }
                        }
                    }
                    break;
                case "CHOOSE_WRONG":
                    {                     
                        currentturn++;
                        if (currentturn > 3)
                            currentturn = 1;
                        foreach (var player in connectedPlayers)
                        {
                            byte[] buffer = Encoding.UTF8.GetBytes("CW;" + arrPayload[1]); //CW + character
                            player.playerSocket.Send(buffer);
                            Thread.Sleep(100);
                            buffer = Encoding.UTF8.GetBytes("TURN;" + connectedPlayers[currentturn - 1].name);
                            player.playerSocket.Send(buffer);
                        }
                    }
                    break;
                case "ENDTURN":
                    {
                        currentturn++;
                        if (currentturn > 3)
                            currentturn = 1;
                        foreach (var player in connectedPlayers)
                        {
                            byte[] buffer = Encoding.UTF8.GetBytes("TURN;" + connectedPlayers[currentturn - 1].name);
                            player.playerSocket.Send(buffer);
                        }
                    }
                    break;
                case "SCORE_CHANGED":
                    {
                        foreach (var player in connectedPlayers)
                        {
                            // Update Name + Score
                            byte[] buffer = Encoding.UTF8.GetBytes("SCORE_UPDATE;" + arrPayload[1] + ";" + arrPayload[2]);
                            player.playerSocket.Send(buffer);
                        }
                    }
                    break;
                case "TOTAL_SCORE":
                    {
                        foreach (var player in connectedPlayers)
                        {
                            if (player.name == arrPayload[1])
                                player.totalscore = int.Parse(arrPayload[2]);
                        }
                    }
                    break;
                case "WIN_ROUND":
                    {
                        // Tuong tu buoc set up tuy nhien phai cap nhat them vong choi tiep theo
                        currentround++;
                        if(currentround > 3)
                        {                                                        
                            connectedPlayers.Sort((x, y) => x.totalscore.CompareTo(y.totalscore));
                            string WinnerName = connectedPlayers[connectedPlayers.Count - 1].name;
                            foreach (var player in connectedPlayers)
                            {
                                string makemsg = "ENDGAME;" + WinnerName;
                                byte[] buffer = Encoding.UTF8.GetBytes(makemsg);
                                player.playerSocket.Send(buffer);
                            }
                            break;
                        }
                        foreach (var player in connectedPlayers)
                        {
                            if (player.name == arrPayload[1])
                                player.totalscore = int.Parse(arrPayload[2]);
                        }
                        randomQuestion();
                        foreach (var player in connectedPlayers)
                        {
                            string makemsg = "NEW_ROUND;" + currentround.ToString();
                            byte[] buffer = Encoding.UTF8.GetBytes(makemsg);
                            player.playerSocket.Send(buffer);
                            Thread.Sleep(100);
                        }
                        foreach (var player in connectedPlayers)
                        {
                            string makemsg = "LOAD_QA;" + question + ";" + answer;
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
                default:
                    break;

            }
        }

        // Other methods
        public static void randomQuestion()
        {
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
            // Kiểm tra câu hỏi đã được sử dụng hay chưa 
            while (UsedQuestions.Contains(question))
            {
                random = new Random();
                randomIndex = random.Next(0, questionsArray.Count);
                randomQuestionObject = (JObject)questionsArray[randomIndex];
                question = (string)randomQuestionObject["question"];
            }
            UsedQuestions.Add(question);
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
        private void btFetchQuestion_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Đường dẫn của file được chọn
                MessageBox.Show("Nạp câu hỏi thành công !", "Thông báo", MessageBoxButtons.OK);
                questionPath = openFileDialog.FileName;

            }
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
        
        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            serverSocket.Close();
            serverlisten.Abort();
            if(clientThread != null)
                clientThread.Abort();
        }

        /*static IPAddress GetLocalIPAddress()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }

            }

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }*/
    }
}

