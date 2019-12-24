using System;
using System.Linq;

namespace ProjetCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var questions = QuestionsQuizz.GetQuestions(); // Nous appelons la methode statique GetQuestions pour stocker toutes les questions dans une liste QuestionQCM

            Console.WriteLine("Saisissez votre Nom et prenom"); // Nous demandons au joueur d'entrer son Nom et Prenom
            string nomJoueur = Console.ReadLine(); // Nous stockons le nom du joueur dans une variage nomJoueur
            var joueur = new Joueur(nomJoueur, DateTime.Now); // Nous instoncions le joueur , Nous donnons comme parametres : le nomJoueur et la date du quizz
            Console.Clear(); // Nous vidons la console

            string réponseJoueur;
            foreach (var question in questions) // Nous oarcourrons toutes les questions et les poser au joueur
            {
                Console.WriteLine(question); // l'affichage de la question
                Console.WriteLine("Veuillez choisir votre réponse parmis les options proposées ci-dessus.\nVotre reponse doit être en lettres majuscules.");
                bool formatReponse = false; // initialisation d'variable de type boolean pour traiter le format de la réponse
                while (!formatReponse)
                {
                    // Nous mettons un TryCatch pour recuperer l'exception due au format de la réponse
                    try
                    {
                        réponseJoueur = Console.ReadLine(); // La réponse du joueur
                        joueur.TesterRéponse(réponseJoueur, question); // Nous testons la réponse reponseJoueur de la question correspondante par la methode TesterJoueur
                        formatReponse = true; // Si le format est correct , nous passons le boolean à True
                        Console.Clear(); // Nous vidons l'ecran à nouveau pour poser la prochaine question
                    }
                    catch (FormatException e) // Nous interception l'exception 
                    {
                        Console.WriteLine(e.Message); // nous affichons le message de l'exception
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Green; // Changer la couleur pour afficher le resultat
            Console.WriteLine($"Votre Résultat est : {joueur.Resultat}");
            Console.ResetColor();
           
            // afficher toute les questions ou le joueur s'est trompé et afficher la bonne réponse
            foreach (var item in joueur.Erreurs)
            {
                var question = questions[item - 1];
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(question);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"La bonne réponse était : {question.RéponseQuestion}\n");
            }
            Console.ResetColor();

            // Nous enregistrons le resultats dans le fichier STAT.txt 
            StatsJeux.EnregistrerRésultatsJoueur(joueur);
            Console.ReadKey();
            Console.Clear();

            // Nous demandons au joueur si il veut voir les statisqtiques
            Console.WriteLine("Voulez-Vous voir les statistiques du jeu?(oui/non)");
            string voirStat = Console.ReadLine().ToLower(); 
            if (voirStat == "oui")
            {
                var donnéesStats = StatsJeux.GetTousStats(); // Nous recuperons tous les données statistiques du fichier STAT.txt dans une list<Joueur>
                var statJeu = new StatsJeux(donnéesStats); // Nous instancions un objet StatsJeux en lui donnant la liste comme parametre
                Console.WriteLine(statJeu); // Nous affichons toutes les statistiques
            }

            // Le joueur peut appuyer sur q pour sortir du jeu
            char touche = ' '; 
            while (char.ToLower(touche) != 'q') 
            {
                Console.WriteLine("Appuyer sur la touche Q pour quitter l’application");
                touche = Console.ReadKey().KeyChar;

            }
        }
    }
}
