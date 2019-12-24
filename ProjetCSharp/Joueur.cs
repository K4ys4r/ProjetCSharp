
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetCSharp
{
    public class Joueur
    {
        public string Nom { get; private set; }
        public DateTime DateQuizz { get; private set; }
        public int Score { get; set; }
        public List<int> Erreurs { get; private set; }
        public int NombreQuestions { get; private set; }
        public string Resultat
        {
            get
            {
                return $"{Score}/{NombreQuestions}";
            }
        }

        public Joueur(string nom, DateTime date)
        {
            Nom = nom;
            DateQuizz = date;
            Erreurs = new List<int>();
            NombreQuestions = 0;
        }

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
