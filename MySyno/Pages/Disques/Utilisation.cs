using System;
using System.Windows.Forms;
using MySyno.Controls;
using MySyno.Fenetres;

namespace MySyno.Pages.Disques
{
    public partial class Utilisation : ThemePanel
    {
        private enum Colonnes
        {
            Total = 1, Utilise = 2, Utilisation = 4, Nom = 5
        }

        public Utilisation()
        {
            InitializeComponent();

            Ssh.SendCommand("df -h", GereEspace);
        }

        private void GereEspace(object sender, CommandEventArgs e)
        {
            if (InvokeRequired) // permet de lancer cette méthode via un autre thread
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    GereEspace(sender, e);
                });
                return;
            }

            string total = null, utilise = null, pourcentage = null, nom = null; // contient les valeurs de la progressbar

            int compteurColonne = 0;
            bool headerPassed = false; // besoin de cette variable pour savoir qu'on a passé les entêtes du au monted on (1 espace dans le titre)

            e.Message = e.Message.Replace('\n', ' '); // remplace les retours à la ligne par des espaces pour n'avoir qu'une boucle

            // split en colonne par espace
            foreach (string item in e.Message.Split(new[] { " " },
                StringSplitOptions.RemoveEmptyEntries))
            {
                if (compteurColonne > 6 || headerPassed)
                {
                    if (!headerPassed) // sion vient de passer les en-têtes
                    {
                        headerPassed = true;
                        compteurColonne = 0; // reset les colonnes pour éviter le décalage
                    }

                    switch (compteurColonne % 6)
                    {
                        case (int) Colonnes.Total:
                            total = item;
                            break;
                        case (int) Colonnes.Utilise:
                            utilise = item;
                            break;
                        case (int) Colonnes.Utilisation:
                            pourcentage = item;
                            break;
                        case (int) Colonnes.Nom:
                            nom = item;
                            break;
                    }
                }

                if (total != null && utilise != null && nom != null && pourcentage != null)
                {
                    Controls.Utilisation utilisation = CreerUtilisation(compteurColonne, nom, utilise, pourcentage, total);
                    flowLayoutPanel.Controls.Add(utilisation); // ajoute le control au FlowPanel

                    total = utilise = nom = null; // reset
                }

                compteurColonne++;
            }
        }

        // Crée et renvoie un control Utilisation
        private Controls.Utilisation CreerUtilisation(int compteur, string nom, string utilise, string pourcentage, string total)
        {
            Controls.Utilisation utilisationCourante = new Controls.Utilisation();
            utilisationCourante.Name = "utilisation" + compteur;
            utilisationCourante.BorderStyle = BorderStyle.FixedSingle;

            utilisationCourante.Nom = nom;
            utilisationCourante.SetLabelEspace(utilise, total);
            utilisationCourante.Set(pourcentage);

            return utilisationCourante;
        }
    }
}
