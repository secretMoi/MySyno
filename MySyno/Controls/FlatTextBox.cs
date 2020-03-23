using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using MySyno.Core;
using MySyno.Core.Figures;

namespace MySyno.Controls
{
    public partial class FlatTextBox : ElementGraphic
    {
        private bool _state;

        public FlatTextBox()
        {
            InitializeComponent();

            Dock = DockStyle.None;

            SetTextBox();

            InitGraphiqueFromPictureBox(pictureBox);
        }

        private void SetTextBox()
        {
            // Fond
            Dimensionne(pictureBox.Size);
            position = new Couple(0, 0);
            AjouterRectangle("Fond", Color.FromArgb(25, 118, 211));

            // Souligne
            position = new Couple(
                elements["Fond"].Position.X + 5,
                elements["Fond"].Position.Y + elements["Fond"].Dimension.Y - 5
            );
            dimensions = new Couple(
                elements["Fond"].Position.X + elements["Fond"].Dimension.X - 5,
                position.Y
                );
            AjouterLigne("Souligne", Color.White, 1);
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Affiche(e.Graphics);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            /*_state = true;
            timerClignote.Start();*/
        }

        private void timerClignote_Tick(object sender, EventArgs e)
        {
            if (_state)
            {
                // Ligne verticale
                position = new Couple(
                    elements["Fond"].Position.X + elements["Fond"].Dimension.X - 10,
                    position.Y
                );
                dimensions = new Couple(
                    position.X,
                    elements["Fond"].Position.Y + 5
                );
                AjouterLigne("Clignote", Color.White, 1);

                _state = false;
            }
            else
            {
                Remove("Clignote");
                _state = true;
            }

            pictureBox.Invalidate();
        }

        [Description("Text"), Category("Data"), Browsable(true)]
        public string Texte { get; set; }
    }
}
