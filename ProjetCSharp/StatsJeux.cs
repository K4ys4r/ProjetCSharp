using System;
using System.Collections.Generic;
using System.IO;

namespace ProjetCSharp
{
    static class StatsJeux
    {
        const string CHEMIN_FICHIER = @"../../../STATS.txt";

        public static void EnregistrerRésultatsJoueur(Joueur joueur)
        {
            StreamWriter fichierSortie = null;
            try
            {
                fichierSortie = new StreamWriter(CHEMIN_FICHIER, true);
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
            for (int i = 0; i < donnéesFichier.Length; i++)
            {
                liste.Add(new Joueur(donnéesFichier[i]));
            }
            return liste;
        }

    }
}
