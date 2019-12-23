using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetCSharp
{
    class AfficherStats
    {
        public int NombreDeJeux { get; private set; }
        public double ScoreMoyen { get; private set; }
        public SortedList<int,float> PourcentageBonneRéponses { get; set; }
        public AfficherStats(List<Quizz> liste)
        {
            NombreDeJeux = liste.Count;
            ScoreMoyen = (from q in liste select q.Score).Average(); 
            //TODO : calculer les Pourcentages de chacune de question et le classer en ordre croissant
        }

    }
}
