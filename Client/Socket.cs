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
    class Socket
    {
        public static Socket clientSocket;
        public static Thread recvThread;
        public static string datatype = "";
    }

    /*public static void Connect(IPEndPoint serverEP)
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
                ConnectMenu.lobby.Tempdisplay(msg);
            }
        }

        //Terminate this receiving thread when clientSocket is disconnected
        //recvThread.Abort();
    }*/
}
