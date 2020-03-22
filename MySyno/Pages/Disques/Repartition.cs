using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySyno.Controls;

namespace MySyno.Pages.Disques
{
    public partial class Repartition : ThemePanel
    {


        public Repartition()
        {
            InitializeComponent();

            Ssh.SendCommand("df", ListePartitions, 0);

            Ssh.SendCommand("find /volumeUSB1/usbshare/Film/ -type f -exec du -S {} + | sort -rh | head -n 100", GereEspace, 1);
        }

        private void ListePartitions(object sender, CommandEventArgs e)
        {
            if(e.Id != 0) return;

            if (InvokeRequired) // permet de lancer cette méthode via un autre thread
            {
                Invoque(ListePartitions, sender, e);
                return;
            }
        }

        private void GereEspace(object sender, CommandEventArgs e)
        {
            if (e.Id != 1) return;

            if (InvokeRequired) // permet de lancer cette méthode via un autre thread
            {
                Invoque(GereEspace, sender, e);
                return;
            }

            string taille, nom; // contient les valeurs de la progressbar

            Dictionary<string, float> data = new Dictionary<string, float>();

            string[] lines = e.Message.Split('\n');

            int index;
            string result;

            string suffixeDoublon;
            int compteurSuffixeDoublon = 0;

            foreach (string line in lines)
            {
                if (line == "") continue;

                index = line.IndexOf('\t'); // sépare la chaine entre la taille et le chemin
                taille = line.Substring(0, index); // récupère la taille

                nom = line.Substring(index + 1, line.Length - index - 1).Trim(); // récupère le chemin et retire les espaces en trop
                nom = CleanName(nom); // retire le chemin et l'extention

                if (data.ContainsKey(nom)) // si un fichier ayant le même nom existe déjà (vu que l'on a retiré le chemin)
                {
                    while (data.ContainsKey(nom)) // si plusieurs doublons
                    {
                        compteurSuffixeDoublon++;
                        nom = nom + " (" + compteurSuffixeDoublon + ")";
                    }
                        
                    compteurSuffixeDoublon = 0; // remets le compteur à 0 pour le prochain nom
                }

                data.Add(nom, Convert.ToSingle(taille));
            }

            graphicRepartition.CreateElement(data); // envoie les données au générateur de graphique
        }

        private static string CleanName(string name)
        {
            string cleanedName;

            // retire le chemin
            int pos = name.LastIndexOf("/", StringComparison.Ordinal) + 1;
            cleanedName = name.Substring(pos, name.Length - pos);

            // retire l'extension
            pos = cleanedName.LastIndexOf(".", StringComparison.Ordinal);
            if (pos >= 0)
                cleanedName = cleanedName.Substring(0, pos);

            return cleanedName;
        }
    }
}
