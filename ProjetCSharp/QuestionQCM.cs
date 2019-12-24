using System;
namespace ProjetCSharp
{
    public class QuestionQCM
    {
        public int Numéro { get; private set; } // Propriété: Numéro de la question 
        public string TextQuestion { get; private set; } // Propriété: le texte de la question 
        public string PossibilitésRéponse { get; private set; } // Propriété : Possibilité de Réponse ,A-B-C-D-AB-AC-AD-BA-BC-BD-CA-CB-CD-DA-DB-DC-ABC-DCD
        public string RéponseQuestion { get; private set; }
        /// <summary>
        /// Constructeur QCM
        /// </summary>
        /// <param La question="question"></param>
        /// <param les reponses possibles="réponse"></param>
        /// <param possibilité de réponse="option"></param>
        /// <param Numéro de la question="n"></param>
        public QuestionQCM(string question,string réponse,string option,int n)
        {
            Numéro = n;
            TextQuestion = question;
            RéponseQuestion = réponse;
            PossibilitésRéponse = option;
        }
        /// <summary>
        /// Afficher la question
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return TextQuestion;
        }
    }
}
