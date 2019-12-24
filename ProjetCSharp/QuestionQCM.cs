using System;
namespace ProjetCSharp
{
    public class QuestionQCM
    {
        public int Numéro { get; private set; } // Propriété: Numéro de la question 
        public string TextQuestion { get; set; } // Propriété: le texte de la question 
        public string PossibilitésRéponse { get;  set; } // Propriété : Possibilité de Réponse ,A-B-C-D-AB-AC-AD-BA-BC-BD-CA-CB-CD-DA-DB-DC-ABC-DCD
        public string RéponseQuestion { get; set; }
        /// <summary>
        /// Constructeur QCM
        /// </summary>
        /// <param La question="question"></param>
        /// <param les reponses possibles="réponse"></param>
        /// <param possibilité de réponse="option"></param>
        /// <param Numéro de la question="n"></param>
        public QuestionQCM(int n)
        {
            Numéro = n;
            TextQuestion = string.Empty;
            RéponseQuestion = string.Empty;
            PossibilitésRéponse = string.Empty;
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
