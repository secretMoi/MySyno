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

            ssh.RaiseCustomEvent += SetText;
            ssh.Test();

            ssh.CommandeEvent += Resultat;
            ssh.SendCommand("ls");


            //ssh.Disconnect();
        }

        public void SetText(object sender, CustomEventArgs e)
        {
            button1.Text = e.Message;
        }

        public void Resultat(object sender, CustomEventArgs e)
        {
            // Cross thread - so you don't get the cross-threading exception
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    Resultat(sender, e);
                });
                return;
            }

            // Change control

            richTextBox1.Text = e.Message;
        }
    }
}
