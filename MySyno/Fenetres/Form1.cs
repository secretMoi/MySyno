using System;
using System.Drawing;
using System.Windows.Forms;
using MySyno.Controls;
using MySyno.Pages;

namespace MySyno.Fenetres
{
    public partial class Form1 : FormSsh
    {
        private bool isResizing;
        private Point anciennePositionCurseur;
        private Size ancienneTailleFenetre;
        public Form1()
        {
            InitializeComponent();

            Resize += Form1_Resize;

            Ssh = new SSH("192.168.1.20", "Quentin", "ee6f4e2b02", 32);

            ThemePanel.SetConnection(Ssh);
            Accueil accueil = new Accueil();
            Ssh.Connect(accueil.ChangeEtatConnection);

            panelContainer.Controls.Add(accueil);

            SetSubMenus();
        }

        private void SetSubMenus()
        {
            panelSousMenuDisques.Visible = false;
        }

        private void HideSubMenu()
        {
            if (panelSousMenuDisques.Visible)
                panelSousMenuDisques.Visible = false;
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                HideSubMenu(); // cache les autres sous-menus
                subMenu.Visible = true; // affiche le sous-menu désiré
            }
            else
            {
                subMenu.Visible = false; // ferme ce sous-menu si il était déjà visible
            }
                
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            string nom = ((Button)sender).Name; // récupère le nom du controle appelant
            string[] chaine = nom.Split('_'); // scinde le nom pour avoir les 2 parties

            string @namespace, @class;

            if (chaine.Length == 3) // si c'est un bouton de sous-menu
            {
                @namespace = "MySyno.Pages." + chaine[1];
                @class = chaine[2];
                //HideSubMenu(); // cache les sous-menu
            }
            else // si c'est un bouton de menu
            {
                @namespace = "MySyno.Pages";
                @class = chaine[1];

                // trouve le panel correspondant
                Control[] panel = Controls.Find("PanelSousMenu" + chaine[1], true);
                if(panel.Length > 0) // si un panel existe
                    ShowSubMenu((Panel)panel[0]);
            }

            Type typeClasse = Type.GetType($"{@namespace}.{@class}"); // trouve la classe
            if (typeClasse == null) return; // quitte si la classe est introuvable

            if (!(Activator.CreateInstance(typeClasse) is ThemePanel page)) return;
            panelContainer.Controls.Clear();
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

        private void pictureBoxResize_MouseDown(object sender, MouseEventArgs e)
        {
            isResizing = true;
            anciennePositionCurseur = MousePosition;
            ancienneTailleFenetre = Size;
        }

        private void pictureBoxResize_MouseUp(object sender, MouseEventArgs e)
        {
            isResizing = false;
        }

        private void pictureBoxResize_MouseMove(object sender, MouseEventArgs e)
        {
            if (isResizing)
            {
                Width = MousePosition.X - anciennePositionCurseur.X + ancienneTailleFenetre.Width;
                Height = MousePosition.Y - anciennePositionCurseur.Y + ancienneTailleFenetre.Height;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Update();
        }
    }
}
