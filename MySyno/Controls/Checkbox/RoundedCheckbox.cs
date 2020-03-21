using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySyno.Core;
using MySyno.Core.Figures;
using Rectangle = System.Drawing.Rectangle;

namespace MySyno.Controls.Checkbox
{
    public partial class RoundedCheckbox : ElementGraphic
    {
        private bool _etat;
        private Color OffColor = Color.FromArgb(238, 83, 79);
        private Color OnColor = Color.FromArgb(76, 176, 80);
        private Color DisqueColor = Color.FromArgb(230, 230, 230);

        private int _positionDebut;
        private int _positionFin;

        private const int VitesseAnimation = 2;
        public RoundedCheckbox()
        {
            InitializeComponent();

            Dock = DockStyle.None;

            Figure.InitialiseConteneur(pictureBox);

            InitialiseCadre();
            InitialiseCercle();
        }

        private void InitialiseCadre()
        {
            Dimensionne(70, 30);
            AjouterRectangleArrondi("Bouton", dimensions.Xi / 2, OffColor);
        }

        private void InitialiseCercle()
        {
            Dimensionne(20);
            position.X = 10;
            position.Y = (elements["Bouton"].Dimension.Y - dimensions.Y) / 2;
            AjouterDisque("Disque", DisqueColor);

            _positionDebut = position.Xi;
            _positionFin = elements["Bouton"].Dimension.Xi - _positionDebut - dimensions.Xi;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Affiche(e.Graphics);
        }

        private void timerSlide_Tick(object sender, System.EventArgs e)
        {
            if (_etat)
            {
                Deplace("Disque", -VitesseAnimation);

                if (elements["Disque"].Position.X <= _positionDebut)
                {
                    elements["Disque"].Position.X = _positionDebut;
                    timerSlide.Stop();
                    GetFigure("Bouton").SetBrosse(OffColor);
                    _etat = !_etat;
                }
            }
            else
            {
                Deplace("Disque", VitesseAnimation);

                if (elements["Disque"].Position.X >= _positionFin)
                {
                    elements["Disque"].Position.X = _positionFin;
                    timerSlide.Stop();
                    GetFigure("Bouton").SetBrosse(OnColor);
                    _etat = !_etat;
                }
            }

            pictureBox.Invalidate();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            timerSlide.Start();
        }
    }
}
