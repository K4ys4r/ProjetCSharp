using System;
using System.Collections.Generic;
using System.Globalization;
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
        #endregion

        #region Constructeurs
        public Quizz(string nom, SortedList<int, List<string>> questions, SortedList<int, string> reponses, SortedList<int, string> options)
        {
            _questions = questions;
            _reponsesQuestions = reponses;
            _optionsRéponses = options;
            Erreurs = new List<int>();
            Nom = nom;
            DateQuizz = DateTime.Now;

        }
        #endregion

        #region Methodes

        public void AfficherQuestion(int i)
        {
            foreach (var item in _questions[i])
            {
                Console.WriteLine(item);
            }

        }
        public void TesterQuestion(string reponse, int i)//.................................parametre
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
