using System.Drawing;

namespace MySyno.Core.Figures
{
    public class Rectangle : Figure
    {
        public Rectangle(Couple position, Couple dimension, Color? remplissage = null, Color? contour = null, int largeurContour = 10) :
            base(position, dimension, remplissage, contour, largeurContour)
        {
            
        }

        public Rectangle(Graphics graphique, Couple position, Couple dimension, Color? remplissage = null, Color? contour = null, int largeurContour = 10) :
            base(position, dimension, remplissage, contour, largeurContour)
        {
            Graphique = graphique;
        }

        public override void Genere()
        {
            Graphique.FillRectangle(Remplissage, position.Xf, position.Yf, 
                dimension.Xf, dimension.Yf);
            
            Graphique.DrawRectangle(Contour,
                position.Xf, position.Yf, 
                dimension.Xf, dimension.Yf); // dessine le rectangle dans l'image
        }
    }
}