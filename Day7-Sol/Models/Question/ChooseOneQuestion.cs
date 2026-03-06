using Day7_Sol.Models.Answers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day7_Sol.Models.Questions
{
    public class ChooseOneQuestion : Question
    {
        public ChooseOneQuestion(string header, string body, int marks, AnswerList answers, Answer correct) 
            : base(header, body, marks)
        {
            Answers = answers;
            CorrectAnswer = correct;
        }
        public override bool CheckAnswer(Answer studentAnswer)
        {
            return studentAnswer.Equals(CorrectAnswer);
        }

        public override void Display()
        {
            Console.WriteLine(Body);
            foreach (var ans in Answers.answers)
                Console.WriteLine(ans);
        }
    }
}
