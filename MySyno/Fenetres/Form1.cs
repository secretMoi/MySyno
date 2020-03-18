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
            Ssh.Connect();

            Accueil accueil = new Accueil();
            accueil.Dock = DockStyle.Fill;
            accueil.SetConnection(Ssh);
            
            panelContainer.Controls.Add(accueil);
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            string nom = ((Button)sender).Name; // récupère le nom du controle appelant
            string[] chaine = nom.Split('_'); // scinde le nom pour avoir les 2 parties

            string @namespace = "MySyno.Pages." + chaine[1];
            string @class = chaine[2];

            // équivalent var typeClasse = Type.GetType(String.Format("{0}.{1}", @namespace, @class));
            var typeClasse = Type.GetType($"{@namespace}.{@class}"); // trouve la classe
            if (typeClasse == null) return; // quitte si la classe est introuvable

            panelContainer.Controls.Clear();
            ThemePanel page = Activator.CreateInstance(typeClasse) as ThemePanel; // instancie un objet
            page.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(page);

            /*Form fenetre = Activator.CreateInstance(typeClasse) as Form; // instancie un objet

            fenetre?.Show(); // Affiche la fenêtre*/
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Ssh.Disconnect();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
