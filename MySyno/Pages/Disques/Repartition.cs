using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySyno.Controls;
using MySyno.Core.Figures;

namespace MySyno.Pages.Disques
{
    public partial class Repartition : ThemePanel
    {
        public Repartition()
        {
            InitializeComponent();

            Ssh.SendCommand("find /volumeUSB1/usbshare/Film/ -type f -exec du -S {} + | sort -rh | head -n 100", GereEspace);
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

            string taille = null, nom = null; // contient les valeurs de la progressbar

            Dictionary<string, float> data = new Dictionary<string, float>();

            string[] lines = e.Message.Split('\n');

            int index;
            string result;

            string suffixeDoublon;
            int compteurSuffixeDoublon = 0;

            foreach (string line in lines)
            {
                if (line == "") continue;

                index = line.IndexOf('\t');
                taille = line.Substring(0, index);

                nom = line.Substring(index + 1, line.Length - index - 1).Trim();
                nom = CleanName(nom);

                if (data.ContainsKey(nom))
                {
                    while (data.ContainsKey(nom))
                    {
                        compteurSuffixeDoublon++;
                        nom = nom + " (" + compteurSuffixeDoublon + ")";
                    }
                        
                    compteurSuffixeDoublon = 0;
                }

                data.Add(nom, Convert.ToSingle(taille));
            }

            graphicRepartition.CreateElement(data);
        }

        private static string CleanName(string name)
        {
            string cleanedName;

            int pos = name.LastIndexOf("/") + 1;
            cleanedName = name.Substring(pos, name.Length - pos);


            pos = cleanedName.LastIndexOf(".");
            if (pos >= 0)
                cleanedName = cleanedName.Substring(0, pos);

            return cleanedName;
        }
    }
}
