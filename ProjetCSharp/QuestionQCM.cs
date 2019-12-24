using System;
namespace ProjetCSharp
{
    public class QuestionQCM
    {
        public int Numéro { get; private set; }
        public string TextQuestion { get; set; }
        public string PossibilitésRéponse { get; set; }
        public string RéponseQuestion { get; set; }

        public QuestionQCM(int n)
        {
            Numéro = n;
            TextQuestion = string.Empty;
            RéponseQuestion = string.Empty;
            PossibilitésRéponse = string.Empty;
        }

        public override string ToString()
        {
            return TextQuestion;
        }
    }
}
