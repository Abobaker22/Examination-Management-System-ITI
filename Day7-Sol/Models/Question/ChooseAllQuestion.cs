using Day7_Sol.Models.Answers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day7_Sol.Models.Questions
{
    public class ChooseAllQuestion:Question
    {
        public AnswerList CorrectAnswers { get; set; }
        
        public ChooseAllQuestion(string header, string body, int marks, AnswerList answers, AnswerList correctanswers) 
            : base(header, body, marks)
        {
            Answers = answers;
            CorrectAnswers = correctanswers;
        }
        public override bool CheckAnswer(Answer studentAnswer)
        {
            throw new NotSupportedException("Use the Multiple Answer Version where you pass AnsweList");
        }
        public bool CheckAnswer(AnswerList studentAnswers)
        {
            if (studentAnswers.answers.Count != CorrectAnswers.answers.Count)
                return false;

            // Use a HashSet for O(1) lookups instead of a nested loop.
            var correctSet = new HashSet<Answer>(CorrectAnswers.answers);

            // Ensure every student answer is in the correctAnswer set.
            foreach (var answer in studentAnswers.answers)
            {
                if (!correctSet.Contains(answer))
                    return false;
            }

            return true;
        }


        public override void Display()
        {
            Console.WriteLine(Body);
            foreach (var answer in Answers.answers)
                Console.WriteLine(answer);
        }
    }
}
