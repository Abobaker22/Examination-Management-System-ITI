using Day7_Sol.Models.Answers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day7_Sol.Models.Questions
{
    public abstract class Question
    {
        public string Header { get; protected set; }
        public string Body { get; protected set; }
        public int Marks { get; protected set; }

        public AnswerList Answers { get; protected set; }
        public Answer CorrectAnswer { get; protected set; }

        protected Question(string header, string body, int marks)
        {
            if (string.IsNullOrWhiteSpace(header))
                throw new ArgumentException("Header invalid");

            if (string.IsNullOrWhiteSpace(body))
                throw new ArgumentException("Body invalid");

            if (marks <= 0)
                throw new ArgumentException("Marks must be > 0");

            Header = header;
            Body = body;
            Marks = marks;
        }
        public abstract void Display();
        public abstract bool CheckAnswer(Answer studentAnswer);
        public override string ToString()
        {
            return $"Question Detais\nHeader{Header}\n, Body{Body}\n, Marks{Marks}\n, Answers{Answers}\n, CorrectAnswer{CorrectAnswer}\n";
        }
        public override bool Equals(object? obj)
        {
            if(obj is Question Q)
            {
                if(Header == Q.Header && Body == Q.Body)
                    return true ;
                else 
                    return false ;
            }
            return false ;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Header,Body);
        }
    }
}
