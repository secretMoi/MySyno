using System.Windows.Forms;
using MySyno.Controls;

namespace MySyno.Pages.Disques
{
    public partial class Utilisation : ThemePanel
    {
        public Utilisation()
        {
            InitializeComponent();

            Ssh.SendCommand("df -h", GereEspace);
        }

        private void GereEspace(object sender, CommandEventArgs e)
        {
            if (InvokeRequired) // permet de lancer cette méthode via un autre thread
            {
                Invoque(GereEspace, sender, e);
                return;
            }

            ParseCommandDf parseCommandDf = new ParseCommandDf(
                ParseCommandDf.Colonnes.Total,
                ParseCommandDf.Colonnes.Utilise,
                ParseCommandDf.Colonnes.Utilisation,
                ParseCommandDf.Colonnes.Nom
            );

            string[][] arrayParsed = parseCommandDf.Parse(e.Message);
            int compteur = 0;
            foreach (string[] ligne in arrayParsed)
            {
                Controls.Utilisation utilisation = CreerUtilisation(
                    compteur,
                    ligne [parseCommandDf.GetColumn(ParseCommandDf.Colonnes.Nom)],
                    ligne[parseCommandDf.GetColumn(ParseCommandDf.Colonnes.Utilise)],
                    ligne[parseCommandDf.GetColumn(ParseCommandDf.Colonnes.Utilisation)],
                    ligne[parseCommandDf.GetColumn(ParseCommandDf.Colonnes.Total)]
                    );
                flowLayoutPanel.Controls.Add(utilisation); // ajoute le control au FlowPanel
                compteur++;
            }
        }

        // Crée et renvoie un control Utilisation
        private Controls.Utilisation CreerUtilisation(int compteur, string nom, string utilise, string pourcentage, string total)
        {
            Controls.Utilisation utilisationCourante = new Controls.Utilisation();
            utilisationCourante.Name = "Utilisation" + compteur;
            utilisationCourante.BorderStyle = BorderStyle.FixedSingle;

            utilisationCourante.Nom = nom;
            utilisationCourante.SetLabelEspace(utilise, total);
            utilisationCourante.Set(pourcentage);

            return utilisationCourante;
        }
    }
}
