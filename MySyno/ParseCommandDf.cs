using System;
using System.Collections.Generic;

namespace MySyno
{
	class ParseCommandDf
	{
		private readonly List<int> _colonnesSelectionnees;
		private Dictionary<Colonnes, int> _ordreColonnes;

		public enum Colonnes
		{
			Total = 1, Utilise = 2, Libre = 3, Utilisation = 4, Nom = 5
		}

		public ParseCommandDf()
		{
			_colonnesSelectionnees= new List<int>();
			_ordreColonnes = new Dictionary<Colonnes, int>();
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
			int compteurColonne = 0;
			int idColonne;
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

				if (idTableau == 4)
					idTableau = 0;
				compteurColonne++;
			}

			return chainParsedBySpace;
		}

		private bool ValidColumn(int id, Colonnes colonne)
		{
			return _colonnesSelectionnees.Contains(id) && id == (int) colonne;
		}

        public int GetColumn(Colonnes colonne)
        {
            return _ordreColonnes[colonne];
        }
	}
}
