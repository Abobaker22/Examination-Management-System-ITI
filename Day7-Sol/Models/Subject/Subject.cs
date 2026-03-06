using Day7_Sol.Models.Students;
using System;
using System.Collections.Generic;
using System.Text;
using Day7_Sol.Models.Exams;

namespace Day7_Sol.Models.Subjects
{
    public class Subject
    {
        public string Name { get; set; }
        public List<Student> EnrolledStudents { get; set; }

        public Subject(string name)
        {
            Name = name;
            EnrolledStudents = new List<Student>();
        }
        public Subject(string name, List<Student> students)
        {
            Name = name;
            EnrolledStudents = students;
        }
        public void Enroll(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            if (EnrolledStudents.Contains(student))
                throw new InvalidOperationException("Student already enrolled.");

            EnrolledStudents.Add(student);
        }
        public void NotifyStudents(Exam exam)
        {
            if (exam == null)
                throw new ArgumentNullException(nameof(exam));

            foreach (var student in EnrolledStudents)
            {
                exam.ExamStarted += student.OnExamStarted;
            }
        }

        public override string ToString()
        {
            return $"Subject: {Name} | Enrolled Students: {EnrolledStudents.Count}";
        }

        public override bool Equals(object obj)
        {
            if (obj is not Subject other)
                return false;

            return Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return Name.ToLower().GetHashCode();
        }
    }
}
