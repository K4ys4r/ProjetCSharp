using System;
namespace ProjetCSharp
{
    public class QuestionQCM
    {
        public int Numéro { get; private set; }
        public string TextQuestion { get; private set; }
        public string PossibilitésRéponse { get; private set; }
        public string RéponseQuestion { get; private set; }

        public QuestionQCM(string question,string réponse,string option,int n)
        {
            Numéro = n;
            TextQuestion = question;
            RéponseQuestion = réponse;
            PossibilitésRéponse = option;
        }

        public override string ToString()
        {
            return TextQuestion;
        }
    }
}
