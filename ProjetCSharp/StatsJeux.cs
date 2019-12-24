using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjetCSharp
{
    public class StatsJeux
    {
        const string CHEMIN_FICHIER = @"..\..\..\STATS.txt";

        public int NombreDeJeux { get; private set; }
        public double ScoreMoyen { get; private set; }
        public SortedList<int, float> PourcentageBonneRéponses { get; set; }

        public StatsJeux(List<Joueur> liste)
        {
            NombreDeJeux = liste.Count;
            ScoreMoyen = (from q in liste select q.Score).Average();
            int nbQuestion = liste[0].NombreQuestions;
            PourcentageBonneRéponses = new SortedList<int, float>();
            for (int i = 1; i < nbQuestion + 1; i++)
            {
                float pourcentageErreurQuestion = 100 - (liste.Where(j => j.Erreurs.Contains(i)).Count() / (float)NombreDeJeux) * 100;
                PourcentageBonneRéponses.Add(i, pourcentageErreurQuestion);
            }
        }

        public static void EnregistrerRésultatsJoueur(Joueur joueur)
        {
            StreamWriter fichierSortie = null;
            try
            {
                if (!File.Exists(CHEMIN_FICHIER))
                {
                    fichierSortie = new StreamWriter(CHEMIN_FICHIER, true);
                    fichierSortie.WriteLine($"Date\tNom\tScore\tErreurs");
                }
                else
                {
                    fichierSortie = new StreamWriter(CHEMIN_FICHIER, true);
                }
                fichierSortie.WriteLine(joueur);
            }
            finally
            {
                if (fichierSortie != null)
                {
                    fichierSortie.Close();
                }
            }
        }

        public static List<Joueur> GetTousStats()
        {
            var liste = new List<Joueur>();
            var donnéesFichier = File.ReadAllLines(CHEMIN_FICHIER);
            for (int i = 1; i < donnéesFichier.Length; i++)
            {
                liste.Add(new Joueur(donnéesFichier[i]));
            }
            return liste;
        }

        public override string ToString()
        {
            string messageStats = $"Nombre total de jeux : {NombreDeJeux}\n";
            messageStats += $"Score moyen : {ScoreMoyen.ToString("0.00")}\n";
            messageStats += "Pourrcentage de bonnes réponses en ordre croissant:\n";
            var statOrderCroissant = PourcentageBonneRéponses.OrderBy(r => r.Value);
            foreach (var item in statOrderCroissant)
            {
                messageStats += $"Question {item.Key} : {item.Value.ToString("0.00")}\n";
            }
            return messageStats;
        }
    }
}
