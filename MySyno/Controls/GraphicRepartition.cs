using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using MySyno.Core;
using MySyno.Core.Figures;

namespace MySyno.Controls
{
    public partial class GraphicRepartition : ElementGraphic
    {
        private Dictionary<string, float> data;

        private Figure _premiere;
        private Figure _derniereFigure;

        public GraphicRepartition() : base(new Couple(0,0))
        {
            InitializeComponent();

            Figure.InitialiseConteneur(pictureBox1);

            pictureBox1.MouseWheel += pictureBox1_MouseWheel;
        }

        public void CreateElement(Dictionary<string, float> incomingData = null)
        {
            if(incomingData == null && data == null) return;

            if(incomingData != null)
                data = incomingData;

            int compteur = 0;

            float rapport = (Width - 100) / PlusGrandeValeur() * 0.95f;
            foreach (KeyValuePair<string, float> element in data)
            {
                // nom
                Dimensionne(12.5f);
                position.X = 10;
                position.Y = compteur * dimensions.Y * 4;
                AjouterTexte("Label" + element.Key, element.Key, Color.Black);

                // barre
                position.X = 100;
                position.Y += 25;
                Dimensionne((int) (element.Value * rapport), 20);
                AjouterRectangle("Rectangle" + element.Key, Color.FromArgb(33, 150, 245));

                // valeur
                Dimensionne(12.5f);
                position.X += 7;
                position.Y -= 1;
                // CultureInfo.CurrentCulture pour adapter la chaine à une vue UI
                // CultureInfo.InvariantCulture pour garder les données brutes, les enregistrer dans un fichier par exemple
                AjouterTexte("Valeur" + element.Key, element.Value.ToString(CultureInfo.CurrentCulture), Color.White);

                if (compteur == 0) _premiere = GetFigure("Label" + element.Key);
                if (compteur == data.Count - 1) _derniereFigure = GetFigure("Label" + element.Key);

                 compteur++;
            }

            pictureBox1.Invalidate();
        }

        private float PlusGrandeValeur()
        {
            float valeurMax = float.MinValue;

            foreach (KeyValuePair<string, float> element in data)
                if (element.Value > valeurMax)
                    valeurMax = element.Value;

            return valeurMax;
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            int scroll = e.Delta;

            if (_premiere.Position.Y + scroll < 100 && _derniereFigure.Position.Y + scroll > 100)
            {
                Deplace(0, scroll);
            }

            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Affiche(e.Graphics);
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            elements.Clear();
            pictureBox1.Image = null;
            CreateElement();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }
    }
}
