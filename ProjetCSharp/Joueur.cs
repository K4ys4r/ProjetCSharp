
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetCSharp
{
    public class Joueur
    {
        public string Nom { get; private set; } //Propriétés Nom du joueur 
        public DateTime DateQuizz { get; private set; } //Propriétés Date du quizz
        public int Score { get; set; }//Propriétés Score du joueur 
        public List<int> Erreurs { get; private set; } //Propriétés liste des erreurs ( indices des questions )
        public int NombreQuestions { get; private set; } //Propriétés nombre de question
        public string Resultat
        {
            get
            {
                return $"{Score}/{NombreQuestions}"; // C'est une propriété nous renvoyant une information
            }
        }
        /// <summary>
        /// Le constructeur est appelé lors du debut du quizz
        /// </summary>
        /// <param Nom du joueur="nom"></param>
        /// <param Date du quizz="date"></param>
        public Joueur(string nom, DateTime date)
        {
            Nom = nom;
            DateQuizz = date;
            Erreurs = new List<int>();
            NombreQuestions = 0;
        }
        /// <summary>
        /// Constructeur appelé lors des affichage des statistiques des joueurs
        /// </summary>
        /// <param ligne resumant les informations du joueur et ses statistiques ="stat"></param>
        public Joueur(string stat)
        {
            string[] infoJoueur = stat.Split('\t');
            var _date = infoJoueur[0].Split('-').Select(int.Parse).ToArray();
            DateQuizz = new DateTime(_date[0], _date[1], _date[2]);
            Nom = infoJoueur[1];
            var _score = infoJoueur[2].Split('/').Select(int.Parse).ToArray();
            Score = _score[0];
            NombreQuestions = _score[1];
            Erreurs = infoJoueur[3].Split(',').Select(int.Parse).ToList();
        }
        /// <summary>
        /// Methode prenant en parametre les reponses du joueur 
        /// </summary>
        /// <param La reponse du joueur="reponse"></param>
        /// <param Liste des questions ="question"></param>
        public void TesterRéponse(string reponse, QuestionQCM question)
        {
            if (reponse.Length == 0)
            {
                throw new FormatException("Le format de la réponse est incorrecte vous devez choisir des lettres parmis celles qui sont proposées");
            }
            for (int i = 0; i < reponse.Length; i++)
            {
                if (!question.PossibilitésRéponse.Contains(reponse[i]))
                {
                    throw new FormatException("Le format de la réponse est incorrecte vous devez choisir des lettres parmis celles qui sont proposées");
                }
            }
            if (string.Concat(reponse.OrderBy(c => c)) == question.RéponseQuestion)
            {
                NombreQuestions++;
                Score++;
            }
            else
            {
                NombreQuestions++;
                Erreurs.Add(question.Numéro);
            }
        }
        /// <summary>
        /// Affichage des statistiques du joueur
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
    }
}
