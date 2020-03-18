using System;
using System.Windows.Forms;

namespace MySyno.Fenetres
{
    public partial class Form1 : FormSsh
    {
        public Form1()
        {
            InitializeComponent();

            Ssh = new SSH("192.168.1.20", "Quentin", "ee6f4e2b02", 32);
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            string nom = ((ToolStripMenuItem)sender).Name; // récupère le nom du controle appelant
            string[] chaine = nom.Split('_'); // scinde le nom pour avoir les 2 parties

            string @namespace = GetType().Namespace;
            string @class = chaine[1];

            // équivalent var typeClasse = Type.GetType(String.Format("{0}.{1}", @namespace, @class));
            var typeClasse = Type.GetType($"{@namespace}.{@class}"); // trouve la classe
            if (typeClasse == null) return; // quitte si la classe est introuvable
            Form fenetre = Activator.CreateInstance(typeClasse) as Form; // instancie un objet

            fenetre?.Show(); // Affiche la fenêtre
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ssh.Connect();

            Ssh.SendCommand("df", Resultat);
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
            Ssh.Disconnect();
        }
    }
}
