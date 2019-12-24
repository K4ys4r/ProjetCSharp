using System;

namespace ProjetCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var questions = QuestionsQuizz.GetQuestions();

            Console.WriteLine("Saisissez votre Nom et prenom");
            string nomJoueur = Console.ReadLine();
            var joueur = new Joueur(nomJoueur,DateTime.Now);
            string réponseJoueur;
            foreach (var question in questions)
            {
                Console.Clear();
                Console.WriteLine(question);
                Console.WriteLine("Veuillez choisir votre réponse parmis les options proposées ci-dessus.\nVotre reponse doit être en lettres majuscules.");
                bool formatReponse = false;
                while (!formatReponse)
                {
                    try
                    {
                        réponseJoueur = Console.ReadLine();
                        joueur.TesterRéponse(réponseJoueur, question);
                        formatReponse = true;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            Console.WriteLine($"Votre Résultat est : {joueur.Resultat}");

            foreach (var item in joueur.Erreurs)
            {
                var question = questions[item - 1];
                Console.WriteLine(question);
                Console.WriteLine($"\nLa bonne réponse était : {question.RéponseQuestion}");
            }

            StatsJeux.EnregistrerRésultatsJoueur(joueur);
            var donnéesStats = StatsJeux.GetTousStats();
            AfficherStats statJeux = new AfficherStats(donnéesStats);
            foreach (var item in statJeux.PourcentageBonneRéponses)
            {
                Console.WriteLine($"Question {item.Key} : {item.Value}");
            }

        }
    }
}
