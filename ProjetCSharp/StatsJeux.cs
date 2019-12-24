using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjetCSharp
{
    public class StatsJeux

    {
        private const string CHEMIN_FICHIER = @"..\..\..\STATS.txt"; // Nous declarons le chemin du fichier comme une constante privée
        #region Propriétés
        public int NombreDeJeux { get; private set; } // Proprité : Le nombre de jeux
        public double ScoreMoyen { get; private set; } // Proprité : Le score moyen
        public SortedList<int, float> PourcentageBonneRéponses { get; private set; } // Proprité : c'est une liste qui contient le numéro de la question et son pourcentage de bonnes réponse
        #endregion

        #region Constructeur 
        /// <summary>
        /// Construceur qui prend en parametre la liste des joueurs et qui va affecter les propriétés de la classe StatsJeux
        /// </summary>
        /// <param liste des joueurs List<Joueur></Joueur>="liste"></param>
        public StatsJeux(List<Joueur> liste)
        {
            NombreDeJeux = liste.Count; //Nous recuperons les joueurs qui étaient enregistrés
            ScoreMoyen = (from q in liste select q.Score).Average(); // recupération des scores de la liste en calculer la moyenne 
            int nbQuestion = liste[0].NombreQuestions; //Nous récuperrons le nombre de question
            PourcentageBonneRéponses = new SortedList<int, float>(); // Nous instancions la Sortedlist pourcentage PourcentageBonneRéponses 
            for (int i = 1; i < nbQuestion + 1; i++)
            {
                // Pour un numéro de question donnée , nous récuperrons le nombre de joueurs qui y ont répondu faux et nous divisons le nombre total de joueurs et nous multiplions par 100 => Pourcentage Erreur
                // PourcentageBonneRéponses = (100 - Pourcentage Erreur)
                float pourcentageErreurQuestion = 100 - (liste.Where(j => j.Erreurs.Contains(i)).Count() / (float)NombreDeJeux) * 100;
                PourcentageBonneRéponses.Add(i, pourcentageErreurQuestion); // Nous rajoutons le pourcentage dans la liste Pourcentage Erreur PourcentageBonneRéponses
            }
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Methode statique qui prend en parametre l'instance Joueur et enregistre les données dans le fichier STAT.txt
        /// </summary>
        /// <param Objet Joueur="joueur"></param>
        public static void EnregistrerRésultatsJoueur(Joueur joueur)
        {
            StreamWriter fichierSortie = null;
            try
            {
                if (!File.Exists(CHEMIN_FICHIER))
                {
                    fichierSortie = new StreamWriter(CHEMIN_FICHIER, true);
                    fichierSortie.WriteLine($"Date\tNom\tScore\tErreurs"); // Si le fichier STAT.txt n'existe pas , nous le créons et nous ecrivons l'entete 
                }
                else
                {
                    fichierSortie = new StreamWriter(CHEMIN_FICHIER, true); // si le fichier existe , nous rajoutons des statistiques dedans
                }
                fichierSortie.WriteLine(joueur); // Nous ecrivons dans le fichier ce que la méthode ToString de Joueur renvoie
            }
            finally // En cas d'incidents , nous liberons le fichier.
            {
                if (fichierSortie != null)
                {
                    fichierSortie.Close();
                }
            }
        }
        /// <summary>
        /// Methode statique : qui permets de lire les statistiques qui sont enregistrées dans STAT.txt
        /// et instancie pour chaque récupérée un objet Joueur
        /// </summary>
        /// <returns>Liste de joueur List<Joueur> </returns>
        public static List<Joueur>  GetTousStats()
        {
            var liste = new List<Joueur>();
            var donnéesFichier = File.ReadAllLines(CHEMIN_FICHIER);
            for (int i = 1; i < donnéesFichier.Length; i++)
            {
                var joueur = new Joueur(donnéesFichier[i]); // Nous instancions le joueur
                liste.Add(joueur);                           // Nous rajoutons dans la liste
            }
            return liste; // Renvoie la liste totale des joueurs
        }
        /// <summary>
        /// Methode ToString nous permets de retourner les statistiques 
        /// </summary>
        /// <returns></returns>
        public override string ToString() 
        {
            string messageStats = $"Nombre total de jeux : {NombreDeJeux}\n"; 
            messageStats += $"Score moyen : {ScoreMoyen.ToString("0.00")}\n";
            messageStats += "Pourrcentage de bonnes réponses en ordre croissant:\n";
            var statOrderCroissant = PourcentageBonneRéponses.OrderBy(r => r.Value); // Classer des questions selon un ordre croissant des pourcentages
            foreach (var item in statOrderCroissant) 
            {
                messageStats += $"Question {item.Key} : {item.Value.ToString("0.00")} %\n"; 
            }
            return messageStats; // retourne le message qui contient : Nombre de jeux,Score moyen , Classement des questions
        }
        #endregion
    }
}
