using System;
using System.Windows.Forms;

namespace MySyno
{
    public partial class Form1 : Form
    {
        readonly SSH ssh;

        public Form1()
        {
            InitializeComponent();

            ssh = new SSH("192.168.1.20", "Quentin", "ee6f4e2b02", 32);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ssh.Connect();

            //ssh.CommandeEvent += Resultat;
            ssh.SendCommand("ls", Resultat);
        }

        public void Resultat(object sender, CommandEventArgs e)
        {
            // permet de lancer cette méthode via un autre thread
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    Resultat(sender, e);
                });
                return;
            }

            // Change control
            richTextBox1.Text = e.Message;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ssh.Disconnect();
        }
    }
}
