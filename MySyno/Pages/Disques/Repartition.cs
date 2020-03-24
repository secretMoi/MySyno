using System;
using System.Collections.Generic;
using System.Linq;
using MySyno.Controls;

namespace MySyno.Pages.Disques
{
	public partial class Repartition : ThemePanel
	{
		private readonly List<string> _nom;
		private int _resultNumber;
		private string _path;

		public Repartition()
		{
			InitializeComponent();

			_nom = new List<string>();

			Ssh.SendCommand("df", ListePartitions, 0);

			_path = "/volumeUSB1/usbshare/";
			_resultNumber = 100;
			Command();
		}

		private void ListePartitions(object sender, CommandEventArgs e)
		{
			if(e.Id != 0) return;

			if (InvokeRequired) // permet de lancer cette méthode via un autre thread
			{
				Invoque(ListePartitions, sender, e);
				return;
			}

			// Choix des colonnes
			ParseCommandDf parseCommandDf = new ParseCommandDf(
				ParseCommandDf.Colonnes.Nom
			);

			// Tableau formatté en lignes/colonnes
			string[][] arrayParsed = parseCommandDf.Parse(e.Message);
			string nom;

			foreach (string[] ligne in arrayParsed)
			{
				nom = ligne[parseCommandDf.GetColumn(ParseCommandDf.Colonnes.Nom)];

				if (nom.Contains("volume"))
					flatListBox.Add(ParseCommandDf.CleanName(nom));

				_nom.Add(nom);
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
			int compteurSuffixeDoublon = 0;

			flatTextBox.Texte = _resultNumber.ToString();
            flatListBox.Titre = "   volumeUSB1";

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

		private void flatButtonEnvoyer_Click(object sender, EventArgs e)
		{
			if(flatTextBox.Texte != "")
			    _resultNumber = Convert.ToInt32(RemoveCharacter(flatTextBox.Texte));

			string titre = flatListBox.Titre.Remove(0, 3); // retire les espaces
			foreach (string nom in _nom)
			{
				if (!nom.Contains(titre)) continue; // tant qu'on ne trouve pas le nom

				_path = nom;
				Command();

				break;
			}
		}

		private void Command()
		{
			Ssh.SendCommand(
				"find " +
				_path +
				GenereTypeCommande(roundedCheckboxDossiers.State, roundedCheckboxFichiers.State) +
				" -exec du -S {} + | sort -rh | head -n " + _resultNumber,
				GereEspace,
				1
			);
		}

		private string GenereTypeCommande(bool etatDossier, bool etatFichier)
		{
			if (etatDossier || etatFichier)
			{
				if (etatDossier && !etatFichier)
					return " -type d";
				else if(!etatDossier && etatFichier)
					return " -type f";
			}

			return "";
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

        private string RemoveCharacter(string text)
        {
            return new string(text.Where(char.IsDigit).ToArray());
        }
	}
}
