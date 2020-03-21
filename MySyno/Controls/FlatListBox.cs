using System;
using System.Drawing;
using System.Windows.Forms;
using MySyno.Controls.Buttons;

namespace MySyno.Controls
{
    public partial class FlatListBox : UserControl
    {
        private bool _state;
        private int _vitesse;
        private readonly int _vitesseOrigine;

        public FlatListBox()
        {
            InitializeComponent();

            _vitesse = _vitesseOrigine = 1;
            Add("coucou", Test);
            Add("coucou2", Test);
            Add("coucou", Test);
            Add("coucou", Test);
            Add("coucou", Test);
        }

        public void Add(string text, EventHandler click)
        {
            _vitesse += _vitesseOrigine; // augmente la vitesse à chaque création de bouton pour que le temps d'ouverture/fermeture reste le même

            FlatButton flatButton = new FlatButton
            {
                Height = 40,
                Text = @"   " + text,
                BackColor = Color.FromArgb(25, 118, 211),
                TextAlign = ContentAlignment.MiddleLeft,
                Width = panelCorps.Width,
                Location = new Point(0, panelCorps.MaximumSize.Height)
            };

            flatButton.Name = Name + "Sub" + panelCorps.MaximumSize.Height / flatButton.Height;

            flatButton.Click += click;

            panelCorps.MaximumSize = new Size(panelCorps.Width, panelCorps.MaximumSize.Height + flatButton.Height);
            MaximumSize = new Size(panelCorps.Width, MaximumSize.Height + flatButton.Height);
            panelCorps.Controls.Add(flatButton);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!_state) // si fermé à ouvert
            {
                panelCorps.Height += _vitesse;
                if (panelCorps.Size.Height == panelCorps.MaximumSize.Height)
                {
                    timer.Stop();
                    pictureBox.Image = Image.FromFile("Ressources/Images/up-arrow.png");
                    _state = true;
                }
            }
            else // sinon ouvert à fermé
            {
                panelCorps.Height -= _vitesse;
                if (panelCorps.Size.Height == panelCorps.MinimumSize.Height)
                {
                    timer.Stop();
                    pictureBox.Image = Image.FromFile("Ressources/Images/down-arrow.png");
                    _state = false;
                }
            }
        }

        private void Test(object sender, EventArgs e)
        {

        }

        private void panelTitre_MouseDown(object sender, MouseEventArgs e)
        {
            timer.Start();
        }
    }
}
