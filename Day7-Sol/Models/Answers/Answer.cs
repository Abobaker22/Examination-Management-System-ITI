using System;
using System.Collections.Generic;
using System.Text;

namespace Day7_Sol.Models.Answers
{
    public class Answer : IComparable<Answer>
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Answer(int id, string text)
        {
            Id = id;
            Text = text;
        }
        public override string ToString()
        {
            return $"Answer Id :{Id}, Answer Texxt {Text}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Answer ans && ans != null)
            {
                //return ans.Id == Id ; ///they are the same
                return Id.Equals(ans.Id);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Text);
        }
        public int CompareTo(Answer? other)
        {
            if (other == null || Id > other.Id) return 1;

            if(Id == other.Id)
                return 0;
            else return -1;
        }
    }
}
