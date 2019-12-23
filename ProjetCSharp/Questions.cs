using System;
using System.Collections.Generic;
using System.IO;
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
        public static SortedList<int, List<string>> ChargerQuestions()
        {
            var _questions = new SortedList<int, List<string>>();
            var _bonnesReponses = new SortedList<int, List<string>>();
            var donnéesFichier = File.ReadAllLines(CHEMIN_FICHIER);

            for (int i = 0; i < donnéesFichier.Length; i++)
            {

                string phrase = donnéesFichier[i];
                string reponseQuestion=string.Empty;
                List<string> listeQuestion = new List<string>();

                if (phrase.Contains("Question"))
                {
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
                        reponseQuestion+=phrase[1];

                        Console.WriteLine(phrase);
                        Console.WriteLine(phrase.Remove(0,1));

                    }
                    else
                    {
                        listeQuestion.Add(phrase);
                    }

                }



            }

            return _questions;
        }




    }
}
