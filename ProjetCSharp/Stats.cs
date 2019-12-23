using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjetCSharp
{
    class Stats
    {
        const string CHEMIN_FICHIER = @"..\STATS.txt";
        private Quizz statJoueur;

        public Stats(Quizz joueur)
        {
           statJoueur = joueur;
        }

        public void EnregistrerRésultatsJoueur()
        {
            StreamWriter fichierSortie = null;
            try
            {
                fichierSortie = new StreamWriter(CHEMIN_FICHIER, true);
                string _erreurs = string.Join(",", statJoueur.Erreurs.Select(n => n.ToString()).ToArray());
                fichierSortie.WriteLine(string.Format("{0}\t{1}\t{2}/{3}\t{4}", statJoueur.DateQuizz.ToString("yyyy-MM-d"),statJoueur.Nom, statJoueur.Score,statJoueur.NombreQuestions, _erreurs));
            }
            finally
            {
                if (fichierSortie != null)
                {
                    fichierSortie.Close();
                }
            }
        }

        public List<Quizz> GetTousStats()
        {
            var liste = new List<Quizz>();
            var donnéesFichier = File.ReadAllLines(CHEMIN_FICHIER);
            for (int i = 1; i < donnéesFichier.Length; i++)
            {
                liste.Add(new Quizz(donnéesFichier[i]));
            }
            return liste;

        }
    }
}
