using Day7_Sol.Models.Questions;
using Day7_Sol.Models.Subjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day7_Sol.Models.Exams
{
    internal class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQue, Question[] ques, Subject subject) : base(time, numberOfQue, ques, subject)
        {
            
        }
        public override void ShowExam()
        {
            Console.WriteLine("=== Final Exam ===");

            foreach (var question in Questions)
            {
                question.Display();

                Console.Write("Your Answer Id: ");
                int id = int.Parse(Console.ReadLine());

                var answer = question.Answers.GetById(id);

                QuestionAnswerDictionary[question] = answer;
            }
        }
        public override void Finish()
        {
            base.Finish();
            Console.WriteLine("\n--- Review ---");

            foreach (var entry in QuestionAnswerDictionary)
            {
                Console.WriteLine($"Question: {entry.Key.Body}");
                Console.WriteLine($"Your Answer: {entry.Value}");
                Console.WriteLine();
            }
        }
    }
}
