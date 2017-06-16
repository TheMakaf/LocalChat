using Microsoft.AspNet.SignalR.Client;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class ClientForm : Form
    {
        private String UserName { get; set; }
        private IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://192.168.0.100:8080/signalr";
        private HubConnection Connection { get; set; }

        public ClientForm()
        {
            InitializeComponent();
            signBox.Focus();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (sendBox.Text != "")
            {
                HubProxy.Invoke("Send", UserName, sendBox.Text);
                sendBox.Text = String.Empty;
                sendBox.Focus();
            }
        }


        private async void ConnectAsync()
        {
            Connection = new HubConnection(ServerURI);
            Connection.Closed += Connection_Closed;
            HubProxy = Connection.CreateHubProxy("MyHub");
            HubProxy.On<string, string>("AddMessage", (name, message) =>
                this.Invoke((Action)(() =>
                    dataBox.AppendText(String.Format("{0}: {1}" + Environment.NewLine, name, message))
                ))
            );
            try
            {
                await Connection.Start();
                
            }
            catch (HttpRequestException)
            {
                statusLabel.Text = "Unable to connect to server: Start server before connecting clients.";
                return;
            }

            signButton.Enabled = false;
            signBox.Enabled = false;
            sendBox.Enabled = true;
            SendButton.Enabled = true;
            sendBox.Focus();
            statusLabel.Text="Connected to server at " + ServerURI;
        }

        private void Connection_Closed()
        {
            this.Invoke((Action)(() => signBox.Enabled = true));
            this.Invoke((Action)(() => signButton.Enabled = true));
            this.Invoke((Action)(() => sendBox.Enabled = false));
            this.Invoke((Action)(() => SendButton.Enabled = false));
            this.Invoke((Action)(() => statusLabel.Text = "You have been disconnected."));
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Connection != null)
            {
                Connection.Stop();
                Connection.Dispose();
            }
        }

        private void signButton_Click(object sender, EventArgs e)
        {
            UserName = signBox.Text;
            if (!String.IsNullOrEmpty(UserName))
            {
                statusLabel.Text="Connecting to server...";
                ConnectAsync();

            }
        }

        private void sendBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendButton_Click(this, new EventArgs());
            }
        }

        private void dataBox_TextChanged(object sender, EventArgs e)
        {
            dataBox.SelectionStart = dataBox.Text.Length;
            dataBox.ScrollToCaret();
        }
    }
}
