using System;
using System.Linq;

namespace ProjetCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var questions = QuestionsQuizz.GetQuestions();

            Console.WriteLine("Saisissez votre Nom et prenom");
            string nomJoueur = Console.ReadLine();
            var joueur = new Joueur(nomJoueur, DateTime.Now);
            Console.Clear();
            string réponseJoueur;
            foreach (var question in questions)
            {
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
                        Console.Clear();
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Votre Résultat est : {joueur.Resultat}");
            Console.ResetColor();

            foreach (var item in joueur.Erreurs)
            {
                var question = questions[item - 1];
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(question);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"La bonne réponse était : {question.RéponseQuestion}\n");
            }
            Console.ResetColor();

            StatsJeux.EnregistrerRésultatsJoueur(joueur);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Voulez-Vous voir les statistiques du jeu?(oui/non)");
            string voirStat = Console.ReadLine().ToLower();
            if (voirStat == "oui")
            {
                var donnéesStats = StatsJeux.GetTousStats();
                var statJeu = new StatsJeux(donnéesStats);
                Console.WriteLine(statJeu);
            }
            char touche = 'a';
            while (char.ToLower(touche) != 'q')
            {
                Console.WriteLine("Appuyer sur la touche Q pour quitter l’application");
                touche = Console.ReadKey().KeyChar;

            }
        }
    }
}
