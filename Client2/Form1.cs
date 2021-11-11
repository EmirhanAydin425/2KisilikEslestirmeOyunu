using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SimpleTcpClient client2;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            client2.Connect(txtHost.Text, Convert.ToInt32(txtPort.Text));
            btnConnect.Enabled = false;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            client2 = new SimpleTcpClient();
            client2.StringEncoder = Encoding.UTF8;
            client2.DataReceived += Client2_DataReceived;
        }

        private void Client2_DataReceived(object sender, SimpleTCP.Message e)
        {
            txtStatus.Invoke((MethodInvoker)delegate ()
            {
                txtStatus.Text += e.MessageString;
            });
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            client2.WriteLineAndGetReply(txtMessage.Text, TimeSpan.FromSeconds(3));
        }
    }
}
