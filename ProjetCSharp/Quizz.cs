using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetCSharp
    
{
    class Quizz
    {
        private string nom;
        private string prenom;
        private DateTime dateQuizz;
        private int score;
        private int[] tabErreur;
        private string reponseTapee;
        private string laBonneReponse;
        private int nbrBonneReponse;
        private int nbrMauvaiseReponse;


        public string Nom { get;}
        public string Prenom { get;}
        public DateTime DateQuizz { get;}
        public int Score { get; }
        public int[] TabErreur { get;}

        public String ReponseTapee { get; }
        public int NbrBonneReponse { get; }
        public int NbrMauvaiseReponse { get; }

        public Quizz(string nom, string prenom)
        {
            Nom = nom;
            this.prenom = prenom;
        }

        public void GetQuestion()
        {

        }
        public void TesterQuestion()//.................................parametre
        {
            if (reponseTapee == laBonneReponse)
            {
                nbrBonneReponse++;

            }
            else
                nbrMauvaiseReponse++;
        }
        public void AfficherQuestion()//.................................parametre
        {
            
        }


    }

}
