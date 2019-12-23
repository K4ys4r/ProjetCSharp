using System;
using System.Collections.Generic;

namespace ProjetCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var QuestionsQuiz = new SortedList<int, List<string>>();
            SortedList<int, string> RéponsecQuestions = new SortedList<int, string>();
            Questions.ChargerQuestions(out QuestionsQuiz, out RéponsecQuestions);
            //Questions.ChargerQuestions(out var QuestionsQuiz, out var RéponsecQuestions);





            for (int i = 1; i <= RéponsecQuestions.Count; i++)
            {
                foreach ( var item in QuestionsQuiz[i])
                {
                    Console.WriteLine(item);
                }

            Console.WriteLine($"\nLa Bonne Reponse est : {RéponsecQuestions[i]}");
            }
           
        }
    }
}
