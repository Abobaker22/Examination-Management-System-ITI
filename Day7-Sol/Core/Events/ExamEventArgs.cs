using Day7_Sol.Models.Exams;
using Day7_Sol.Models.Subjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day7_Sol.Core.Events
{
    public class ExamEventArgs
    {
        public Subject Subject { get; }
        public Exam Exam { get; }
        public ExamEventArgs(Subject subject, Exam exam)
        {
            Subject = subject;
            Exam = exam;
        }
    }
}
