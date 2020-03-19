using System;
using System.Windows.Forms;
using MySyno.Controls;
using MySyno.Pages;

namespace MySyno.Fenetres
{
    public partial class Form1 : FormSsh
    {
        public Form1()
        {
            InitializeComponent();

            Ssh = new SSH("192.168.1.20", "Quentin", "ee6f4e2b02", 32);

            ThemePanel.SetConnection(Ssh);
            Accueil accueil = new Accueil();
            Ssh.Connect(accueil.ChangeEtatConnection);
            accueil.Dock = DockStyle.Fill;

            panelContainer.Controls.Add(accueil);
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            string nom = ((Button)sender).Name; // récupère le nom du controle appelant
            string[] chaine = nom.Split('_'); // scinde le nom pour avoir les 2 parties

            string @namespace, @class;

            if (chaine.Length == 3)
            {
                @namespace = "MySyno.Pages." + chaine[1];
                @class = chaine[2];
            }
            else
            {
                @namespace = "MySyno.Pages";
                @class = chaine[1];
            }

            Type typeClasse = Type.GetType($"{@namespace}.{@class}"); // trouve la classe
            if (typeClasse == null) return; // quitte si la classe est introuvable

            if (!(Activator.CreateInstance(typeClasse) is ThemePanel page)) return;
            panelContainer.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(page);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Ssh.Disconnect();
            Ssh.Dispose();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBoxReduce_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture started by the mouse down.
                Capture = false;

                // Create and send a WM_NCLBUTTONDOWN message.
                const int WM_NCLBUTTONDOWN = 0x00A1;
                const int HTCAPTION = 2;
                Message msg =
                    Message.Create(this.Handle, WM_NCLBUTTONDOWN,
                        new IntPtr(HTCAPTION), IntPtr.Zero);
                this.DefWndProc(ref msg);
            }
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture started by the mouse down.
                panelHeader.Capture = false;

                // Create and send a WM_NCLBUTTONDOWN message.
                const int WM_NCLBUTTONDOWN = 0x00A1;
                const int HTCAPTION = 2;
                Message msg =
                    Message.Create(this.Handle, WM_NCLBUTTONDOWN,
                        new IntPtr(HTCAPTION), IntPtr.Zero);
                this.DefWndProc(ref msg);
            }
        }
    }
}
