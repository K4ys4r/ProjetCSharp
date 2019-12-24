using System;
namespace ProjetCSharp
{
    public class QuestionQCM
    {
        public int Numéro { get; private set; } // Propriété: Numéro de la question 
        public string TextQuestion { get; set; } // Propriété: le texte de la question 
        public string PossibilitésRéponse { get;  set; } // Propriété : Possibilité de Réponse ,A-B-C-D-AB-AC-AD-BA-BC-BD-CA-CB-CD-DA-DB-DC-ABC-DCD mis à jour par la classe QuestionsQuizz
        public string RéponseQuestion { get; set; } //Propriété :La bonne réponse de la question mis à jour par la classe QuestionsQuizz
        /// <summary>
        /// Constructeur qui prend en parametre le parametre de la question
        /// </summary>
        /// <param Numéro de la question="n"></param>
        public QuestionQCM(int n)
        {
            Numéro = n; // Nous affectons de la question à n.
            TextQuestion = string.Empty; 
            RéponseQuestion = string.Empty;
            PossibilitésRéponse = string.Empty;
        }
        /// <summary>
        /// Surcharge de la methode ToString qui renvoie la question
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return TextQuestion;
        }
    }
}
