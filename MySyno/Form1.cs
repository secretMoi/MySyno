using System;
using System.Windows.Forms;

namespace MySyno
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SSH ssh = new SSH("192.168.1.20", "Quentin", "ee6f4e2b02", 32);
            ssh.Connect();
            button1.Text = SSH.test();
            ssh.Disconnect();
        }
    }
}
