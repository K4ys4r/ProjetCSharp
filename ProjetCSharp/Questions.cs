using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjetCSharp
{
    static class Questions
    {
        // on definit le chemin du fichier
        const string CHEMIN_FICHIER = @"..\QCM.txt";


        /// <summary>
        /// Recupération des questions dans une liste
        /// </summary>
        /// <returns></returns>
        public static void ChargerQuestions(out SortedList<int, List<string>> QuestionsQuiz, out SortedList<int, string> RéponsesQuestions)
        {
            QuestionsQuiz = new SortedList<int, List<string>>();
            RéponsesQuestions = new SortedList<int, string>();
            List<string> listeQuestion = new List<string>();
            int _indQ = 0;
            string reponseQuestion = string.Empty;
            var donnéesFichier = File.ReadAllLines(CHEMIN_FICHIER);

            for (int i = 0; i < donnéesFichier.Length; i++)
            {
                string phrase = donnéesFichier[i];

                if (phrase.Contains("Question"))
                {
                    if (listeQuestion.Count() > 0)
                    {
                        QuestionsQuiz.Add(_indQ, listeQuestion);
                        RéponsesQuestions.Add(_indQ, reponseQuestion);
                    }
                    _indQ++;
                    listeQuestion = new List<string>();
                    listeQuestion.Add(phrase);
                    reponseQuestion = string.Empty;
                }

                if (phrase.Length > 0 && phrase[0] != 'Q' &&
                    (phrase[0] >= 65 && phrase[0] <= 90 || phrase[0] == '*')
                    )
                {
                    if (phrase[0] == '*')
                    {
                        reponseQuestion += phrase[1];
                        listeQuestion.Add(phrase.Remove(0, 1));
                    }
                    else
                    {
                        listeQuestion.Add(phrase);
                    }
                }

            }
            QuestionsQuiz.Add(_indQ, listeQuestion);
            RéponsesQuestions.Add(_indQ, reponseQuestion);
        }




    }
}
