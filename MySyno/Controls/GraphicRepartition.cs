using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySyno.Core;
using MySyno.Core.Figures;

namespace MySyno.Controls
{
    public partial class GraphicRepartition : ElementGraphic
    {
        private Dictionary<string, float> data;

        public GraphicRepartition() : base(new Couple(0,0))
        {
            InitializeComponent();

            Figure.InitialiseConteneur(pictureBox1);

            data = new Dictionary<string, float>();
            data.Add("coucoucoucoucoucoucoucou", 100);
            data.Add("beuhbeuhbeuhbeuh", 50);
            data.Add("b", 10);

            CreateElement();
        }

        private void CreateElement()
        {
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
                AjouterTexte("Valeur" + element.Key, element.Value.ToString(), Color.White);

                compteur++;
            }
        }

        private float PlusGrandeValeur()
        {
            float valeurMax = Single.MinValue;

            foreach (KeyValuePair<string, float> element in data)
                if (element.Value > valeurMax)
                    valeurMax = element.Value;

            return valeurMax;
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
    }
}
