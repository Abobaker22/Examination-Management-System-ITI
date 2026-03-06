using Day7_Sol.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day7_Sol.Models.Students
{
    public class Student    
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public void OnExamStarted(object sender, ExamEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            Console.WriteLine(
                $"Notification for {Name} (ID: {Id}) → " +
                $"Exam for subject '{e.Subject.Name}' has started. " +
                $"Duration: {e.Exam.Time} minutes."
            );
        }


        public override string ToString()
        {
            return $"Student | Id: {Id} | Name: {Name}";
        }

        public override bool Equals(object obj)
        {
            if (obj is not Student other)
                return false;

            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }


    }
}
