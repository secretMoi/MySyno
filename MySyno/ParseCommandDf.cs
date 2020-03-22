using System;
using System.Collections.Generic;

namespace MySyno
{
	class ParseCommandDf
	{
		private readonly List<int> _colonnesSelectionnees; // liste des colonnes demandées
		private readonly Dictionary<Colonnes, int> _ordreColonnes; // associe une colonne à son numéro d'ordre pour le tableau

		public enum Colonnes
		{
			Total = 1, Utilise = 2, Libre = 3, Utilisation = 4, Nom = 5
		}

		// todo mettre AddColonnes directement à l'appel
		public ParseCommandDf()
		{
			_colonnesSelectionnees= new List<int>();
			_ordreColonnes = new Dictionary<Colonnes, int>();
		}

        public ParseCommandDf(params Colonnes[] colonnes) : this()
        {
			AddColonnes(colonnes);
        }

		public void AddColonnes(params Colonnes[] colonnes)
		{
			foreach (Colonnes colonne in colonnes)
			{
				if (Enum.IsDefined(typeof(Colonnes), colonne))
				{
					_ordreColonnes.Add(colonne, _colonnesSelectionnees.Count);
					_colonnesSelectionnees.Add((int)colonne);
				}
			}
		}

		public string[][] Parse(string retourCommandeBrut)
		{
			string[] lignes = retourCommandeBrut.Split('\n'); // casse la chaine en lignes

			string[][] tableauFormatte = new string[lignes.Length - 2][];

			int compteurLigne = 0;

			foreach (string ligne in lignes)
			{
				if (compteurLigne == 0 || ligne == "")
				{
					compteurLigne++;
					continue;
				}

				// -1 pour la ligne de header qu'on retire
				tableauFormatte[compteurLigne - 1] = ParseBySpace(ligne);

				compteurLigne++;
			}

			return tableauFormatte;
		}

		private string[] ParseBySpace(string ligne)
		{
			int compteurColonne = 0; // renvoie le n° de la colonne actuel
			int idColonne; // permet d'identifier la colonne
			int idTableau = 0;

			string[] chainParsedBySpace = new string[_colonnesSelectionnees.Count];

			// split en colonne par espace
			foreach (string item in ligne.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries))
			{
				idColonne = compteurColonne % 6;

				if (ValidColumn(idColonne, Colonnes.Total))
				{
					chainParsedBySpace[idTableau] = item;
					idTableau++;
				}
				else if (ValidColumn(idColonne, Colonnes.Utilise))
				{
					chainParsedBySpace[idTableau] = item;
					idTableau++;
				}
				else if (ValidColumn(idColonne, Colonnes.Utilisation))
				{
					chainParsedBySpace[idTableau] = item;
					idTableau++;
				}
				else if (ValidColumn(idColonne, Colonnes.Nom))
				{
					chainParsedBySpace[idTableau] = item;
					idTableau++;
				}

				// si on a toutes nos colonnes on remet le compteur à 0
				if (idTableau == _colonnesSelectionnees.Count)
					idTableau = 0;
				compteurColonne++;
			}

			return chainParsedBySpace;
		}

		// si la colonne est sélectionnée et que son id correspond
		private bool ValidColumn(int id, Colonnes colonne)
		{
			return _colonnesSelectionnees.Contains(id) && id == (int) colonne;
		}

		// permet d'obtenir le n° d'ordre de la colonne
        public int GetColumn(Colonnes colonne)
        {
            return _ordreColonnes[colonne];
        }

        public static string CleanName(string name)
        {
            name = name.Substring(1);

            if (name.Contains("/usbshare"))
                name = name.Remove(name.Length - "/usbshare".Length, "/usbshare".Length);

            return name;
		}
	}
}
