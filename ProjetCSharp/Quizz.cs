using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ProjetCSharp

{
    class Quizz
    {

        #region propriétés

        private SortedList<int, List<string>> _questions;
        private SortedList<int, string> _reponsesQuestions;
        private SortedList<int, string> _optionsRéponses;
        public string Nom { get; private set; }
        public DateTime DateQuizz { get; private set; }
        public int Score { get; private set; }
        public List<int> Erreurs { get; private set; }
        public int NombreQuestions { get; set; }
        #endregion

        #region Constructeurs
        public Quizz(string stat)
        {
            string[] infoJoueur = stat.Split('\t');
            DateQuizz = DateTime.Parse(infoJoueur[0]);
            Nom = infoJoueur[1];
            var _score =infoJoueur[2].Split('/').Select(int.Parse).ToArray();
            Score = _score[0];
            Erreurs = infoJoueur[3].Split(',').Select(int.Parse).ToList();
        }

        public Quizz(string nom, SortedList<int, List<string>> questions, SortedList<int, string> reponses, SortedList<int, string> options)
        {
            _questions = questions;
            _reponsesQuestions = reponses;
            _optionsRéponses = options;
            NombreQuestions = _optionsRéponses.Count;
            Erreurs = new List<int>();
            Nom = nom;
            DateQuizz = DateTime.Now;

        }
        #endregion

        #region Methodes

        public string AfficherQuestion(int i)
        {
            string question = string.Empty;
            foreach (var item in _questions[i])
            {
                question+=item;
                question += '\n';
            }
            return question;
        }
        public void TesterQuestion(string reponse, int i)
        {
            for (int j = 0; j < reponse.Length; j++)
            {
                    if (!_optionsRéponses[i].Contains(reponse[j]))
                    {
                        throw new FormatException("Le format de la réponse est incorrecte vous devez choisir des lettres parmis celles qui sont proposées");
                    }
            }
            if (reponse == _reponsesQuestions[i])
            {
                Score++;
            }
            else
            {
                Erreurs.Add(i);
            }
        }
        #endregion

    }

}
