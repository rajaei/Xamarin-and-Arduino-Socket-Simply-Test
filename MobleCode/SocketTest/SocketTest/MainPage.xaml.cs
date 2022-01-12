using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocketTest
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnSendCommand_Clicked(object sender, EventArgs e)
        {
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];
            try
            {

                if (!Config.socket.Connected)
                {
                    Config.ipAdd = System.Net.IPAddress.Parse(txtIP.Text);
                    Config.socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                    Config.remoteEP = new IPEndPoint(Config.ipAdd, int.Parse(txtPort.Text));
                    Config.socket.Connect(Config.remoteEP);
                }
                Config.socket.SendTimeout = 300;
                byte[] byData = UnicodeEncoding.UTF8.GetBytes(txtMessage.Text + "\r\n");
                Config.socket.Send(byData);

            }
            catch (Exception ex)
            {
                DisplayAlert("Error",ex.Message,"Ok");
            }

        }

        private void btnClose_Clicked(object sender, EventArgs e)
        {
            Config.socket.Close();
        }
    }
}
