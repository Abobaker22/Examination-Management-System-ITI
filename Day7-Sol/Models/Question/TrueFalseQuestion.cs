using Day7_Sol.Models.Answers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day7_Sol.Models.Questions
{
    public class TrueFalseQuestion : Question
    {

        public TrueFalseQuestion(string header, string body, int marks, bool correct)
            :base(header, body, marks)
        {
            Answers = new();
            Answers.Add(new Answer(1, "True"));
            Answers.Add(new Answer(2, "False"));

            CorrectAnswer = correct ? Answers.GetById(1) : Answers.GetById(2);
        }
        public override bool CheckAnswer(Answer studentAnswer)
        {
            return studentAnswer.Equals(CorrectAnswer);
        }

        public override void Display()
        {
            Console.WriteLine(Body);
            foreach(var ans in Answers.answers)
                Console.WriteLine(ans);
        }
    }
}
