using System;
using System.Collections.Generic;
using System.IO;

namespace ProjetCSharp
{
    static class QuestionsQuizz // Classe Statique
    {
        private const string CHEMIN_FICHIER = @"..\..\..\QCM.txt";  // Nous declarons le chemin du fichier comme une constante privée

        /// <summary>
        /// Methode statique GetQuestions : qui lit le fichier QCM.txt et renvoie une liste<QuestionQCM>
        /// chaque instance de <QuestionQCM> contient la question,la reponse, les possibilités de réponse et le numéro  de la question 
        /// </summary>
        /// <returns></returns>
        public static List<QuestionQCM> GetQuestions()
        {
            var liste = new List<QuestionQCM>();
            var donnéesFichier = File.ReadAllLines(CHEMIN_FICHIER);
            int _indQ = 0; // Compteur Question initialisé a 0

            for (int i = 0; i < donnéesFichier.Length; i++) // Parcourir les lignes du fichier QCM.txt 
            {
                string phrase = donnéesFichier[i]; // Chaque phrase correspond a la ligne du fichier 

                if (phrase.Contains("Question")) // Si la phrase contient le mot Question on instancie l'objet QuestionQCM 
                {
                    _indQ++;
                    QuestionQCM q = new QuestionQCM(_indQ);         //on instancie l'objet QuestionQCM
                    liste.Add(q);                                   //on le rajoute dans la liste<QuestionQCM> 
                    liste[_indQ - 1].TextQuestion += phrase + '\n'; // textQuestion correspond au texte de la question
                }

                if (phrase.Length > 0 && phrase[0] != 'Q' &&
                    (phrase[0] >= 65 && phrase[0] <= 90 || phrase[0] == '*')
                    ) // Nous testons si la phrase ne contiens pas le mot "Question" :
                {
                    if (phrase[0] == '*') // Si la phrase contient '*' ,c'est une bonne réponse
                    {
                        liste[_indQ - 1].TextQuestion += phrase.Substring(1) + '\n'; // nous rajouttons la phase sans l'*' dans le TextQuestion
                        liste[_indQ - 1].RéponseQuestion += phrase[1];              //on rajoute la lettre qui suit l'*' dans RéponseQuestion
                        liste[_indQ - 1].PossibilitésRéponse += phrase[1];          //on rajoute la lettre qui suit l'*' dans PossibilitéRéponse 
                    }
                    else // Le cas inverse ,
                    {
                        liste[_indQ - 1].TextQuestion += phrase + '\n'; //nous rajouttons la phase  dans le TextQuestion
                        liste[_indQ - 1].PossibilitésRéponse += phrase[0]; //on rajoute la premiere lettre dans PossibilitéRéponse
                    }
                }
            }
            return liste; // on retourne la liste qui contient toutes les questions et leurs propriétés
        }
    }
}
