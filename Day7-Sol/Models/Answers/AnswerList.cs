using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Day7_Sol.Models.Answers
{
    public class AnswerList
    {
        public List<Answer> answers { get; set; } // i should replace the list with array
        public int Count { get; set; } // i don't need it , i will only need it when i replace the list with array

        public AnswerList()
        {
            answers = new List<Answer>();
            Count = 0;
        }
        public Answer GetById(int _id)
        {
            foreach(Answer answer in answers)
            {
                if (answer.Id == _id)
                    return answer;
            }
            throw new KeyNotFoundException($"Answer with id:{_id} not found");
        }
    
        public void Add(Answer answer)
        {
            answers.Add(answer);
            Count++;
        }

        // Indexer
        public Answer this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException("Invalid answer index.");
                return answers[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException("Invalid answer index.");
                answers[index] = value;
            }
        }
    }
}
