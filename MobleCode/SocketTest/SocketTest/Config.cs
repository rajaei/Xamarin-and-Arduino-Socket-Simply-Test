using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketTest
{
    public static class Config
    {
        public static IPAddress ipAdd = System.Net.IPAddress.Parse("192.168.4.1");
        public static Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);

        public static IPEndPoint remoteEP = new IPEndPoint(ipAdd, 80);

    }
}
