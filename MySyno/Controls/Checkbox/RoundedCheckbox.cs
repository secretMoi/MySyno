using System.Drawing;
using System.Windows.Forms;
using MySyno.Core.Figures;

namespace MySyno.Controls.Checkbox
{
    public partial class RoundedCheckbox : ElementGraphic
    {
        private readonly Color _offColor = Color.FromArgb(238, 83, 79);
        private readonly Color _onColor = Color.FromArgb(76, 176, 80);
        private readonly Color _disqueColor = Color.FromArgb(230, 230, 230);

        private int _positionDebut;
        private int _positionFin;

        private const float TailleTexte = 12.5f;

        private const int VitesseAnimation = 2;
        public RoundedCheckbox()
        {
            InitializeComponent();

            Dock = DockStyle.None;

            Figure.InitialiseConteneur(pictureBox);

            InitialiseCadre();
            InitialiseCercle();
            TexteOff();
        }

        private void TexteOff()
        {
            Dimensionne(TailleTexte);
            position.X = elements["Bouton"].Dimension.X - 35;
            position.Y = elements["Disque"].Position.Y - 2;
            AjouterTexte("Label", "Off", _disqueColor, FontStyle.Bold);
        }
        private void TexteOn()
        {
            Dimensionne(TailleTexte);
            position.X = 5;
            position.Y = elements["Disque"].Position.Y - 2;
            AjouterTexte("Label", "On", _disqueColor, FontStyle.Bold);
        }

        private void InitialiseCadre()
        {
            Dimensionne(70, 30);
            AjouterRectangleArrondi("Bouton", dimensions.Xi / 2, _offColor);
        }

        private void InitialiseCercle()
        {
            Dimensionne(20);
            position.X = 10;
            position.Y = (elements["Bouton"].Dimension.Y - dimensions.Y) / 2;
            AjouterDisque("Disque", _disqueColor);

            _positionDebut = position.Xi;
            _positionFin = elements["Bouton"].Dimension.Xi - _positionDebut - dimensions.Xi;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Affiche(e.Graphics);
        }

        private void timerSlide_Tick(object sender, System.EventArgs e)
        {
            if (State)
            {
                Deplace("Disque", -VitesseAnimation);

                if (elements["Disque"].Position.X <= _positionDebut)
                {
                    elements["Disque"].Position.X = _positionDebut;
                    timerSlide.Stop();
                    GetFigure("Bouton").SetBrosse(_offColor);

                    Remove("Label");
                    TexteOff();

                    State = !State;
                }
            }
            else
            {
                Deplace("Disque", VitesseAnimation);

                if (elements["Disque"].Position.X >= _positionFin)
                {
                    elements["Disque"].Position.X = _positionFin;
                    timerSlide.Stop();
                    GetFigure("Bouton").SetBrosse(_onColor);

                    Remove("Label");
                    TexteOn();

                    State = !State;
                }
            }

            pictureBox.Invalidate();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            timerSlide.Start();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (Cursor.Current != Cursors.Hand)
                Cursor.Current = Cursors.Hand;
        }

        public bool State { get; set; }
    }
}
