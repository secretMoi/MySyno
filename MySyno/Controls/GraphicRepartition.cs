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
		private Dictionary<string, float> _data;

		// utilisé pour ne pas scroller trop haut ou trop bas
		private Figure _premiereFigure;
		private Figure _derniereFigure;

		public GraphicRepartition() : base(new Couple(0,0))
		{
			InitializeComponent();

			Figure.InitialiseConteneur(pictureBox1);

			pictureBox1.MouseWheel += pictureBox1_MouseWheel;
		}

		public void CreateElement(Dictionary<string, float> incomingData = null)
		{
			if(incomingData == null && _data == null) return; // si aucune donnée ne peut être utilisée

			if(incomingData != null) // si on ne recycle pas les données existantes mais qu'on en prend des nouvelles
				_data = incomingData;

			int compteur = 0;

            Couple positionSourceLigneVerticale = new Couple();
            Couple positionDestinationLigneVerticale = new Couple();

			float rapport = (Width - 100) / PlusGrandeValeur() * 0.95f;
			foreach (KeyValuePair<string, float> element in _data)
			{
				// nom
				Dimensionne(12.5f);
				position.X = 10;
				position.Y = compteur * dimensions.Y * 5;
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
				
				AjouterTexte("Valeur" + element.Key, ConvertitNombre(element.Value), Color.White);

                if (compteur == 0) // si premier élément
                {
                    _premiereFigure = GetFigure("Label" + element.Key);

                    positionSourceLigneVerticale = new Couple(
                        GetFigure("Rectangle" + element.Key).Position.X + GetFigure("Rectangle" + element.Key).Dimension.X,
                        GetFigure("Rectangle" + element.Key).Position.Y
					);

                }

                if (compteur == _data.Count - 1) // si dernier élément
				{
                    _derniereFigure = GetFigure("Label" + element.Key);

                    positionDestinationLigneVerticale = new Couple(
                        positionSourceLigneVerticale.X,
                        GetFigure("Rectangle" + element.Key).Position.Y + GetFigure("Rectangle" + element.Key).Dimension.Y
					);
				}

                compteur++;
			}

            position = positionSourceLigneVerticale;
            dimensions = positionDestinationLigneVerticale;
			AjouterLigne("LigneVerticale", Color.Black, 1);

			pictureBox1.Invalidate();
		}

		// nombre déjà de base en Ko
		// convertit le nombre float en une chaine lisible
        private static string ConvertitNombre(float nombre)
        {
            string resultat;

            // CultureInfo.CurrentCulture pour adapter la chaine à une vue UI
            // CultureInfo.InvariantCulture pour garder les données brutes, les enregistrer dans un fichier par exemple

            if (nombre > Math.Pow(1024, 2))
            {
                nombre /= (float)Math.Pow(1024, 2);
                nombre = Truncate(nombre, 2);
                resultat = nombre.ToString(CultureInfo.CurrentCulture);
                resultat += " Go";
            }
            else if(nombre > 1024)
            {
                nombre /= 1024;
                nombre = Truncate(nombre, 2);
				resultat = nombre.ToString(CultureInfo.CurrentCulture);
                resultat += " Mo";
            }
            else
            {
                nombre = Truncate(nombre, 2);
				resultat = nombre.ToString(CultureInfo.CurrentCulture);
                resultat += " Ko";
			}

			return resultat;
        }

		// arrondi le nombre
        public static float Truncate(float value, int digits)
        {
            double mult = Math.Pow(10.0, digits);
            double result = Math.Truncate(mult * value) / mult;
            return (float)result;
        }

		// trouve la plus grande valeur du dictionnaire
		private float PlusGrandeValeur()
		{
			float valeurMax = float.MinValue;

			foreach (KeyValuePair<string, float> element in _data)
				if (element.Value > valeurMax)
					valeurMax = element.Value;

			return valeurMax;
		}

		// event lors du scolling
		private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
		{
			int scroll = e.Delta;

			if (_premiereFigure.Position.Y + scroll < 100 && _derniereFigure.Position.Y + scroll > 100)
			{
				Deplace(0, scroll);

				pictureBox1.Invalidate();
			}
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			Affiche(e.Graphics);
		}

		// event lors du redimensionnement de la fenêtre
		private void pictureBox1_SizeChanged(object sender, EventArgs e)
		{
			elements.Clear();
			pictureBox1.Image = null;
			CreateElement();
		}

		// permet de donner à la picturebox la priorité du scolling
		private void pictureBox1_MouseHover(object sender, EventArgs e)
		{
			pictureBox1.Focus();
		}
	}
}
