using System;
using System.Drawing;
using System.Windows.Forms;
using MySyno.Controls;
using MySyno.Pages;

namespace MySyno.Fenetres
{
    public partial class Form1 : FormSsh
    {
        private bool _isResizing;
        private Point _anciennePositionCurseur;
        private Size _ancienneTailleFenetre;
        private Panel _subMenuPanelToHide;
        private Panel _subMenuPanelToShow;
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
            panelSousMenuDisques.Size = new Size(panelSousMenuDisques.Size.Width, 0);
        }

        private void HideSubMenu()
        {
            if (panelSousMenuDisques.Size.Height == panelSousMenuDisques.MaximumSize.Height)
                _subMenuPanelToHide = panelSousMenuDisques;
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if (panelSousMenuDisques.Size.Height == panelSousMenuDisques.MinimumSize.Height)
            {
                HideSubMenu(); // cache les autres sous-menus
                _subMenuPanelToShow = subMenu;
            }
            else
                _subMenuPanelToHide = subMenu;

            timerMenuDeroulant.Start();
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
                const int wmNclbuttondown = 0x00A1;
                const int htcaption = 2;
                Message msg =
                    Message.Create(Handle, wmNclbuttondown,
                        new IntPtr(htcaption), IntPtr.Zero);
                DefWndProc(ref msg);
            }
        }

        private void pictureBoxResize_MouseDown(object sender, MouseEventArgs e)
        {
            _isResizing = true;
            _anciennePositionCurseur = MousePosition;
            _ancienneTailleFenetre = Size;
        }

        private void pictureBoxResize_MouseUp(object sender, MouseEventArgs e)
        {
            _isResizing = false;
        }

        private void pictureBoxResize_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isResizing)
            {
                Width = MousePosition.X - _anciennePositionCurseur.X + _ancienneTailleFenetre.Width;
                Height = MousePosition.Y - _anciennePositionCurseur.Y + _ancienneTailleFenetre.Height;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Update();
        }

        private void timerMenuDeroulant_Tick(object sender, EventArgs e)
        {
            if (_subMenuPanelToShow != null)
            {
                _subMenuPanelToShow.Height += 10;
                if (_subMenuPanelToShow.Size.Height == _subMenuPanelToShow.MaximumSize.Height)
                {
                    timerMenuDeroulant.Stop();
                    _subMenuPanelToShow = null;
                }
            }
            if (_subMenuPanelToHide != null)
            {
                _subMenuPanelToHide.Height -= 10;
                if (_subMenuPanelToHide.Size.Height == _subMenuPanelToHide.MinimumSize.Height)
                {
                    timerMenuDeroulant.Stop();
                    _subMenuPanelToHide = null;
                }
            }
        }

        private void pictureBoxClose_MouseEnter(object sender, EventArgs e)
        {
            /*int nouvelleTaille = 48;
            Size ancienneTaille = pictureBoxClose.Size;
            Point nouvellePosition = new Point(
                pictureBoxClose.Location.X - Math.Abs(nouvelleTaille - ancienneTaille.Width) / 2,
                pictureBoxClose.Location.Y - Math.Abs(nouvelleTaille - ancienneTaille.Height) / 2
            );
            pictureBoxClose.Location = nouvellePosition;
            pictureBoxClose.Size = new Size(nouvelleTaille, nouvelleTaille);*/
            Zoom(pictureBoxClose, 48);
        }

        private void pictureBoxClose_MouseLeave(object sender, EventArgs e)
        {
            /*int nouvelleTaille = 32;
            Size ancienneTaille = pictureBoxClose.Size;
            Point nouvellePosition = new Point(
                pictureBoxClose.Location.X + Math.Abs(nouvelleTaille - ancienneTaille.Width) / 2,
                pictureBoxClose.Location.Y + Math.Abs(nouvelleTaille - ancienneTaille.Height) / 2
            );
            pictureBoxClose.Location = nouvellePosition;
            pictureBoxClose.Size = new Size(nouvelleTaille, nouvelleTaille);*/
            Zoom(pictureBoxClose, 32);
        }

        private void pictureBoxReduce_MouseEnter(object sender, EventArgs e)
        {
            Zoom(pictureBoxReduce, 48);
        }

        private void pictureBoxReduce_MouseLeave(object sender, EventArgs e)
        {
            Zoom(pictureBoxReduce, 32);
        }

        private void Zoom(Control control, int taille)
        {
            int sensZoom = 1;

            Size ancienneTaille = control.Size;

            if (taille > ancienneTaille.Width)
                sensZoom = -1;

            Point nouvellePosition = new Point(
                control.Location.X + sensZoom * Math.Abs(taille - ancienneTaille.Width) / 2,
                control.Location.Y + sensZoom * Math.Abs(taille - ancienneTaille.Height) / 2
            );
            control.Location = nouvellePosition;
            control.Size = new Size(taille, taille);
        }
    }
}