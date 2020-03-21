﻿using System.Drawing;

namespace MySyno.Core.Figures
{
    class Texte : Figure
    {
        private readonly Font _font;
        private readonly string _texte;

        public Texte(string texte, Couple position, Color remplissage, float taille = 12.5f, string police = "Yu Gothic UI") :
            base(position, position, remplissage)
        {
            _texte = texte;
            _font = new Font(police, taille);
        }

        public override void Genere()
        {
            Graphique.DrawString(_texte, _font, Remplissage, position.Xf, position.Yf);
        }
    }
}