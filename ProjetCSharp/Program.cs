using System;
using System.Collections.Generic;

namespace ProjetCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Questions.ChargerQuestions(out SortedList<int, List<string>> QuestionsQuiz, out SortedList<int, string> RéponsecQuestions);
            //foreach (var item in RéponsecQuestions)
            //{
            //    Console.WriteLine($"{item.Key } : {item.Value}");

            //}
            for (int i = 1; i <= RéponsecQuestions.Count; i++)
            {
                foreach ( var item in QuestionsQuiz[i])
                {
                    Console.WriteLine(item);
                }

            }
            //Console.WriteLine($"\nLa Bonne Reponse est : {RéponsecQuestions[1]}");
           
        }
    }
}
