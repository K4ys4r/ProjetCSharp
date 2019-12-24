
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetCSharp
{
    public class Joueur
    {
        #region Propriétés
        public string Nom { get; private set; } //Propriétés Nom du joueur 
        public DateTime DateQuizz { get; private set; } //Propriétés Date du quizz
        public int Score { get; set; }//Propriétés Score du joueur 
        public List<int> Erreurs { get; private set; } //Propriétés liste des erreurs ( Numéro des questions )
        public int NombreQuestions { get; private set; } //Propriétés nombre de question totl du quizz
        public string Resultat
        {
            get
            {
                return $"{Score}/{NombreQuestions}"; // C'est une propriété nous renvoyant une information (pas affectable )
            }
        }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Le constructeur de l'instance joueur ( dans Main ) pour affecter les propriété du joueur 
        /// </summary>
        /// <param Nom du joueur="nom"></param>
        /// <param Date du quizz="date"></param>
        public Joueur(string nom, DateTime date)
        {
            Nom = nom;
            DateQuizz = date;
            Erreurs = new List<int>(); // initialisation de la liste erreur
            NombreQuestions = 0; // initialisation du nombre de questions
        }
        /// <summary>
        /// Constructeur utilisé par la classe StatsJeux ( Le joueur est instancié )lors de la lecture du fichier STAT.txt
        /// </summary>
        /// <param ligne resumant les informations du joueur et ses statistiques ="stat"></param>
        public Joueur(string stat)
        {
            string[] infoJoueur = stat.Split('\t'); //Recuperation des informations par colonne 
            var _date = infoJoueur[0].Split('-').Select(int.Parse).ToArray();// recupération de l'année -  Mois - jour de la date et les mettre dans un tableau _date[]
            DateQuizz = new DateTime(_date[0], _date[1], _date[2]);
            Nom = infoJoueur[1];
            var _score = infoJoueur[2].Split('/').Select(int.Parse).ToArray();// recuperation du score et le nombre de questions
            Score = _score[0];
            NombreQuestions = _score[1];
            Erreurs = infoJoueur[3].Split(',').Select(int.Parse).ToList(); // nous recuperons les erreurs dans une liste<int>
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Methode qui permets de tester la reponse du joueur en prenant en compte la reponse et la question(i) ; question (i) est une instance de QuestionQCM
        /// </summary>
        /// <param La reponse du joueur="reponse"></param>
        /// <param une instance de QuestionQCM ="question"></param>
        public void TesterRéponse(string reponse, QuestionQCM question)
        {
            if (reponse.Length == 0) // si le joueur ne répond pas à la question , nous levons une exception 
            {
                throw new FormatException("Le format de la réponse est incorrecte vous devez choisir des lettres parmis celles qui sont proposées");
            }
            for (int i = 0; i < reponse.Length; i++) // si la réponse n'est pas dans les possibilité de réponse , nous levons une exception
            {
                if (!question.PossibilitésRéponse.Contains(reponse[i]))
                {
                    throw new FormatException("Le format de la réponse est incorrecte vous devez choisir des lettres parmis celles qui sont proposées");
                }
            }
            if (string.Concat(reponse.OrderBy(c => c)) == question.RéponseQuestion) // si la réponse est correcte , nous incrémontons son score et le nombre des questions
            {
                NombreQuestions++;
                Score++;
            }
            else // Le cas inverse : Nous rajoutons le numéro de la question dans la liste des erreurs et on incrémonte le nombre des questions
            {
                NombreQuestions++;
                Erreurs.Add(question.Numéro);
            }
        }
        /// <summary>
        /// une surcharge de la methode Tostring pour afficher les informations du joueurs pour l'enregistrement des statistiques
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string _erreurs = string.Join(",", Erreurs.Select(n => n.ToString()).ToArray());
            return string.Format("{0}\t{1}\t{2}\t{3}",
                DateQuizz.ToString("yyyy-MM-d"),
                Nom,
                Resultat,
                _erreurs);
        }
        #endregion 
    }
}
