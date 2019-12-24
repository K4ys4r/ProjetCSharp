using System;
using System.Collections.Generic;
using System.IO;

namespace ProjetCSharp
{
    static class QuestionsQuizz
    {
        private const string CHEMIN_FICHIER = @"../../../QCM1.txt";

        public static List<QuestionQCM> GetQuestions()
        {
            var liste = new List<QuestionQCM>();
            var donnéesFichier = File.ReadAllLines(CHEMIN_FICHIER);
            int _indQ = 0;
            string réponseQuestion = string.Empty;
            string optionRéponse = string.Empty;
            string questionText = string.Empty;


            for (int i = 0; i < donnéesFichier.Length; i++)
            {
                string phrase = donnéesFichier[i];

                if (phrase.Contains("Question"))
                {
                    _indQ++;
                    questionText += phrase + '\n';
                    réponseQuestion = string.Empty;
                    optionRéponse = string.Empty;
                }

                if (phrase.Length > 0 && phrase[0] != 'Q' &&
                    (phrase[0] >= 65 && phrase[0] <= 90 || phrase[0] == '*')
                    )
                {
                    if (phrase[0] == '*')
                    {
                        réponseQuestion += phrase[1];
                        optionRéponse += phrase[1];
                        questionText += phrase.Substring(1) + '\n';
                    }
                    else
                    {
                        optionRéponse += phrase[0];
                        questionText += phrase + '\n';
                    }
                }

                if (donnéesFichier[i] == string.Empty)
                {
                    QuestionQCM q = new QuestionQCM(questionText, réponseQuestion, optionRéponse, _indQ);
                    liste.Add(q);
                }

            }
            return liste;
        }
    }
}
