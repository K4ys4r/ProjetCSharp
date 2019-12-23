using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int nombreQuestions;
            string reponseJoueur = string.Empty;

            var QuestionsQuiz = new SortedList<int, List<string>>();
            SortedList<int, string> RéponsecQuestions = new SortedList<int, string>();
            SortedList<int, string> OptionsRéponses = new SortedList<int, string>();
            Questions.ChargerQuestions(out QuestionsQuiz, out RéponsecQuestions,out OptionsRéponses);
            //Questions.ChargerQuestions(out var QuestionsQuiz, out var RéponsecQuestions);

            Console.WriteLine("Saisissez votre Nom et prenom");
            string nomJoueur = Console.ReadLine();
            var joueur = new Quizz(nomJoueur, QuestionsQuiz, RéponsecQuestions,OptionsRéponses);
            nombreQuestions = RéponsecQuestions.Count;

            for (int i = 1; i < nombreQuestions + 1; i++)
            {
                Console.Clear();
                joueur.AfficherQuestion(i);
                Console.WriteLine("Veuillez choisir votre réponse parmis les options proposées ci-dessus.\nVotre reponse doit être en lettres majuscules.");
                bool formatReponse = false;

                while (!formatReponse)
                {
                    try
                    {
                        reponseJoueur = Console.ReadLine();
                        joueur.TesterQuestion(reponseJoueur, i);
                        formatReponse = true;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message); ;
                    }
                }
            }

            string _erreur = string.Join(",", joueur.Erreurs.Select(n => n.ToString()).ToArray());

            //Console.WriteLine(value: $"{joueur.Nom} a un score de {joueur.Score}/{nombreQuestions}, et a fait de erreur {_erreur} ");




            //Console.WriteLine($"\nLa Bonne Reponse est : {RéponsecQuestions[1]}");


        }
    }
}
