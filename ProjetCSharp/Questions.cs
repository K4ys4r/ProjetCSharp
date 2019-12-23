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

        //static public SortedList<int, List<string>> QuestionsQuiz { get; set; }
        //static public SortedList<int, string> RéponsesQuestions { get; set; }
        /// <summary>
        /// Recupération des questions dans une liste
        /// </summary>
        /// <returns></returns>
        public static void ChargerQuestions(out SortedList<int, List<string>> QuestionsQuiz, out SortedList<int, string> RéponsesQuestions, out SortedList<int, string> OptionsRéponses)
        {
            QuestionsQuiz = new SortedList<int, List<string>>();
            RéponsesQuestions = new SortedList<int, string>();
            OptionsRéponses = new SortedList<int, string>();
            List<string> listeQuestion = new List<string>();
            int _indQ = 0;
            string reponseQuestion = string.Empty;
            string optionReponse = string.Empty;
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
                        OptionsRéponses.Add(_indQ, optionReponse);
                    }
                    _indQ++;
                    listeQuestion = new List<string>();
                    listeQuestion.Add(phrase);
                    reponseQuestion = string.Empty;
                    optionReponse = string.Empty;
                }

                if (phrase.Length > 0 && phrase[0] != 'Q' &&
                    (phrase[0] >= 65 && phrase[0] <= 90 || phrase[0] == '*')
                    )
                {
                    if (phrase[0] == '*')
                    {
                        reponseQuestion += phrase[1];
                        optionReponse += phrase[1];
                        listeQuestion.Add(phrase.Remove(0, 1));
                    }
                    else
                    {
                        optionReponse += phrase[0];
                        listeQuestion.Add(phrase);
                    }
                }

            }
            OptionsRéponses.Add(_indQ, optionReponse);
            QuestionsQuiz.Add(_indQ, listeQuestion);
            RéponsesQuestions.Add(_indQ, reponseQuestion);
        }
        //static public void AfficherQuestion(int i)
        //{
        //    foreach (var item in QuestionsQuiz[i])
        //    {
        //        Console.WriteLine(item);
        //    }

        //}
    }
}
