using System;
using System.Linq;
using System.Windows.Forms;
using MySyno.Core;
using MySyno.Core.Figures;

namespace MySyno.Controls
{
    public partial class Utilisation : UserControl
    {
        private string _nom;
        private int _utilises, _total;

        public Utilisation()
        {
            InitializeComponent();
        }

        private double ConvertStorage(string chaine)
        {
            char suffix = chaine[chaine.Length - 1];
            int multiplicateur = 1;

            switch (suffix)
            {
                case 'K':
                    multiplicateur = 1;
                    break;
                case 'M':
                    multiplicateur = 1024;
                    break;
                case 'G':
                    multiplicateur = 1024 * 1024;
                    break;
                case 'T':
                    multiplicateur = 1024 * 1024 * 1024;
                    break;
            }


            string[] nombres;
            double nombre;
            if (chaine.Contains('.'))
            {
                nombres = chaine.Split('.');
                nombre = Convert.ToDouble(nombres[0]) * multiplicateur +
                             Convert.ToDouble(RemoveCharacter(nombres[1])) * multiplicateur / 1024;
            }
            else
            {
                nombre = Convert.ToDouble(RemoveCharacter(chaine)) * multiplicateur;
            }

            return nombre;
        }

        private string RemoveCharacter(string text)
        {
            return new string(text.Where(char.IsDigit).ToArray());
        }

        public void SetEspace(string utilises, string total)
        {
            labelEspace.Text = utilises + @" utilisés sur " + total;
            
            double utilisesTemp = ConvertStorage(utilises);
            double totalTemp = ConvertStorage(total);

            while (totalTemp > Math.Pow(10, 9))
            {
                utilisesTemp /= 1000;
                totalTemp /= 1000;
            }

            _total = (int) totalTemp;
            _utilises = (int) utilisesTemp;

            SetProgress(_total, _utilises);
        }

        public void SetProgress(int maximum, int valeur)
        {
            progressBar.Maximum = maximum;
            progressBar.Step = maximum / 100;
            progressBar.Value = valeur;
        }

        public string Nom
        {
            get => _nom;
            set
            {
                _nom = value;
                labelNom.Text = value;
            } 
        }

        public void SetPosition(Couple position)
        {
            Location = position.ToPoint();
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public ProgressBar ProgressBar { get; private set; }

        public string Espace { get; set; }
    }
}
