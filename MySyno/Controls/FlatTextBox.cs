using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MySyno.Core;
using MySyno.Core.Figures;

namespace MySyno.Controls
{
    public partial class FlatTextBox : ElementGraphic
    {
        public FlatTextBox()
        {
            InitializeComponent();

            Dock = DockStyle.None;

            Figure.InitialiseConteneur(pictureBox);

            SetTextBox();

            Graphique = Graphics.FromHwnd(pictureBox.Handle);
        }

        private void SetTextBox()
        {
            Dimensionne(150, 40);
            position = new Couple(0, 0);
            AjouterRectangle(false, "Fond", Color.FromArgb(25, 118, 211));
        }

        [Description("Text"), Category("Data"), Browsable(true)]
        public string Texte { get; set; }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Affiche(e.Graphics);
        }
    }
}
