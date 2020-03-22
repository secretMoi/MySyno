using System;
using System.Collections.Generic;

namespace MySyno
{
    class ParseCommandDf
    {
        private List<Colonnes> _colonnesSelectionnees;

        public enum Colonnes
        {
            Total = 1, Utilise = 2, Libre = 3, Utilisation = 4, Nom = 5
        }

        public ParseCommandDf()
        {
            _colonnesSelectionnees= new List<Colonnes>();
        }

        public void AddColonnes(params Colonnes[] colonnes)
        {
            foreach (Colonnes colonne in colonnes)
            {
                if(Enum.IsDefined(typeof(Colonnes), colonne))
                    _colonnesSelectionnees.Add(colonne);
            }
        }

        /*public List<string[]> Parse()
        {
            
        }*/
    }
}
