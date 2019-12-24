using System;
using System.Collections.Generic;
using System.IO;

namespace ProjetCSharp
{
    static class QuestionsQuizz
    {
        private const string CHEMIN_FICHIER = @"..\..\..\QCM.txt";

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
                    QuestionQCM q = new QuestionQCM(_indQ);
                    liste.Add(q);
                    liste[_indQ - 1].TextQuestion += phrase + '\n';
                }

                if (phrase.Length > 0 && phrase[0] != 'Q' &&
                    (phrase[0] >= 65 && phrase[0] <= 90 || phrase[0] == '*')
                    )
                {
                    if (phrase[0] == '*')
                    {
                        liste[_indQ - 1].TextQuestion += phrase.Substring(1) + '\n';
                        liste[_indQ - 1].RéponseQuestion += phrase[1];
                        liste[_indQ - 1].PossibilitésRéponse += phrase[1];
                    }
                    else
                    {
                        liste[_indQ - 1].TextQuestion += phrase + '\n';
                        liste[_indQ - 1].PossibilitésRéponse += phrase[0];
                    }
                }
            }
            return liste;
        }
    }
}
