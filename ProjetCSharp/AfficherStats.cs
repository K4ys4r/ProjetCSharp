using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetCSharp
{
    public class AfficherStats
    {
        public int NombreDeJeux { get; private set; }
        public double ScoreMoyen { get; private set; }
        public SortedList<int, float> PourcentageBonneRéponses { get; set; }

        public AfficherStats(List<Joueur> liste)
        {
            NombreDeJeux = liste.Count;
            ScoreMoyen = (from q in liste select q.Score).Average();
            int nbQuestion = liste[0].NombreQuestions;
            for (int i = 1; i < nbQuestion+1; i++)
            {
                float pourcentageQuestion = liste.Where(j => j.Erreurs.Contains(i)).Count()/NombreDeJeux;
                PourcentageBonneRéponses.Add(i, pourcentageQuestion);
            }
        }
    }
}
