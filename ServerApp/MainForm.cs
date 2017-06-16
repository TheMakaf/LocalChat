using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerApp
{
    public partial class MainForm : Form
    {
        private IDisposable SignalR { get; set; }
        const string ServerURI = "http://*:8080";

        public MainForm()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            WriteToConsole("Starting server...");
            StartButton.Enabled = false;
            Task.Run(() => StartServer());
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StartServer()
        {
            try
            {
                SignalR = WebApp.Start(ServerURI);
            }
            catch (TargetInvocationException)
            {
                WriteToConsole("Server failed to start. A server is already running on " + ServerURI);
                this.Invoke((Action)(() => StartButton.Enabled = true));
                return;
            }
            this.Invoke((Action)(() => StartButton.Enabled = false));
            WriteToConsole("Server started at " + ServerURI);
        }

        internal void WriteToConsole(String message)
        {
                if (logBox.InvokeRequired)
                {
                    this.Invoke((Action)(() =>
                        WriteToConsole(message)
                    ));
                    return;
                }
                logBox.AppendText(message + Environment.NewLine);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SignalR != null)
            {
                SignalR.Dispose();
            }
        }

        private void logBox_TextChanged(object sender, EventArgs e)
        {
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();
        }
    }

    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
    public class MyHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }
        public override Task OnConnected()
        {
            Program.isForm.WriteToConsole(DateTime.Now + " Client connected: " + Context.ConnectionId);
            return base.OnConnected();
        }
        public override Task OnDisconnected()
        {
            Program.isForm.WriteToConsole(DateTime.Now + " Client disconnected: " + Context.ConnectionId);
            return base.OnDisconnected();
        }
    }
}
