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

                if (phrase.Contains("Question"))
                {
                    var listQuestion = new List<string>();
                    listQuestion.Add(phrase);
                    reponseQuestion = string.Empty;
                }


                if (phrase.Length > 0 && phrase[0] != 'Q' &&
                    (phrase[0] >= 65 && phrase[0] <= 90 || phrase[0] == '*')
                    )
                {
                    if (phrase[0] == '*')
                    {
                        reponseQuestion+=phrase[1];
                    }
                }



                //if (phrase.Contains("*"))
                //{
                //    listQuestion.Add(phrase);
                //}
                //if (phrase.Length>0)
                //{

                //Console.WriteLine(phrase[0]);
                //}
            }

            return _questions;
        }


        //public static List<l> GetRelevésMensuels()
        //{
        //    var liste = new List<RelevéMensuel>();
        //    var donnéesFichier = File.ReadAllLines(_CHEMIN_Fichier);
        //    for (int i = 1; i < donnéesFichier.Length; i++)
        //    {
        //        liste.Add(new RelevéMensuel(donnéesFichier[i]));
        //    }
        //    return liste;
        //}


    }
}
