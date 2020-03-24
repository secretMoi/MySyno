using System.Drawing;
using System.Windows.Forms;
using MySyno.Core.Figures;

namespace MySyno.Controls.Checkbox
{
    public partial class RoundedCheckbox : UserControl
    {
        private readonly ElementGraphic element;

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

            element = new ElementGraphic(pictureBox);

            InitialiseCadre();
            InitialiseCercle();
            TexteOff();
        }

        private void TexteOff()
        {
            element.Dimensionne(TailleTexte);
            element.Positionne(
                element.Dimension("Bouton").X - 35,
                element.Position("Disque").Y - 2
            );
            
            element.AjouterTexte("Label", "Off", _disqueColor, FontStyle.Bold);
        }
        private void TexteOn()
        {
            element.Dimensionne(TailleTexte);
            element.Positionne(
                5,
                element.Position("Disque").Y - 2
            );

            element.AjouterTexte("Label", "On", _disqueColor, FontStyle.Bold);
        }

        private void InitialiseCadre()
        {
            element.Dimensionne(70, 30);
            element.AjouterRectangleArrondi("Bouton", element.GetDimension.Xi / 2, _offColor);
        }

        private void InitialiseCercle()
        {
            element.Dimensionne(20);
            element.Positionne(
                10,
                (element.Dimension("Bouton").Y - element.GetDimension.Y) / 2
                );

            element.AjouterDisque("Disque", _disqueColor);

            _positionDebut = element.GetPosition.Xi;
            _positionFin = element.Dimension("Bouton").Xi - _positionDebut - element.GetDimension.Xi;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            element.Affiche(e.Graphics);
        }

        private void timerSlide_Tick(object sender, System.EventArgs e)
        {
            if (State)
            {
                element.Deplace("Disque", -VitesseAnimation);

                if (element.Position("Disque").X <= _positionDebut)
                {
                    element.Position("Disque").X = _positionDebut;
                    timerSlide.Stop();
                    element.GetFigure("Bouton").SetBrosse(_offColor);

                    element.Remove("Label");
                    TexteOff();

                    State = !State;
                }
            }
            else
            {
                element.Deplace("Disque", VitesseAnimation);

                if (element.Position("Disque").X >= _positionFin)
                {
                    element.Position("Disque").X = _positionFin;
                    timerSlide.Stop();
                    element.GetFigure("Bouton").SetBrosse(_onColor);

                    element.Remove("Label");
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
