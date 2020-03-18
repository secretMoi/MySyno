using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using MySyno.Controls;
using MySyno.Core;
using MySyno.Core.Figures;

namespace MySyno.Fenetres
{
    public partial class UtilisationDisque : FormSsh
    {
        private enum Colonnes
        {
            FileSystem = 0, Total = 1, Utilise = 2, Nom = 5
        }

        public UtilisationDisque()
        {
            InitializeComponent();

            Ssh.Connect();
            Ssh.SendCommand("df -h", GereEspace);
        }

        private void GereEspace(object sender, CommandEventArgs e)
        {
            // permet de lancer cette méthode via un autre thread
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    GereEspace(sender, e);
                });
                return;
            }

            string total = null, utilise = null, nom = null; // contient les valeurs de la progressbar
            

            int compteurColonne = 0;
            bool headerPassed = false;

            e.Message = e.Message.Replace('\n', ' ');

            // split par colonne
            foreach (string item in e.Message.Split(new[] { " " },
                StringSplitOptions.RemoveEmptyEntries))
            {
                if (compteurColonne > 6 || headerPassed)
                {
                    if (!headerPassed)
                    {
                        headerPassed = true;
                        compteurColonne = 0;
                    }

                    switch (compteurColonne % 6)
                    {
                        case (int) Colonnes.Total:
                            total = item;
                            break;
                        case (int) Colonnes.Utilise:
                            utilise = item;
                            break;
                        case (int) Colonnes.Nom:
                            nom = item;
                            break;
                    }
                }
                
                if (total != null && utilise != null && nom != null)
                {
                    Utilisation utilisation = CreerUtilisation(compteurColonne, nom, utilise, total);
                    this.Controls.Add(utilisation);
                    total = utilise = nom = null; // reset
                }
                
                compteurColonne++;
            }
        }

        private Utilisation CreerUtilisation(int compteur, string nom, string utilise, string total)
        {
            Utilisation utilisationCourante = new Utilisation();
            utilisationCourante.Name = "utilisation" + compteur;
            Couple positionCourante = new Couple(10, utilisationCourante.Size.Height * (compteur - 5) / 6);
            utilisationCourante.SetPosition(positionCourante);
            utilisationCourante.Nom = nom;
            utilisationCourante.SetEspace(utilise, total);

            return utilisationCourante;
        }
    }
}
