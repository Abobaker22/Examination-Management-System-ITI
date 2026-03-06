using Day7_Sol.Core.Enums;
using Day7_Sol.Core.Events;
using Day7_Sol.Models.Answers;
using Day7_Sol.Models.Questions;
using Day7_Sol.Models.Subjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Day7_Sol.Models.Exams;

public abstract class Exam : ICloneable, IComparable<Exam>
{
    public int Time { get; set; }
    public int NumberOfQuestions { get; set; }
    public Question[] Questions { get; set; }
    public Dictionary<Question, Answer> QuestionAnswerDictionary { get; set; }
    public Subject Subject { get; set; }
    public ExamMode Mode { get; set; }

    public int ExamTotalMarks { get; set; }
    public int StudExamMarks { get; set; }

    public event ExamStartedHandler ExamStarted;
    protected Exam(int time, int numberOfQue, Question[] questions,Subject subject)
    {
        Time = time;
        NumberOfQuestions = numberOfQue;
        Questions = questions;
        Subject = subject;
        Mode = ExamMode.Queued;
        QuestionAnswerDictionary = new Dictionary<Question, Answer>();
    }
    public override string ToString()
    {
        return $"Time: {Time}, NumberOfQuestions: {NumberOfQuestions}, Questions: {Questions}," +
            $" QuestionAnswerDictionary: {QuestionAnswerDictionary}, Subject: {Subject}, Mode: {Mode}";
    }
    public override bool Equals(object? obj)
    {
        if (obj == null || !(obj is Exam)) return false;

        Exam other = (Exam)obj;
        if (Time == other.Time && NumberOfQuestions == other.NumberOfQuestions && Subject == other.Subject && Questions == other.Questions)
            return true;
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(NumberOfQuestions, Time);
    }

    public int CompareTo(Exam? other)
    {
        if (other == null) return 1;
        if (other == this ) return 0;

        if(Time !=  other.Time) 
            return Time > other.Time ? 1 : -1;
        if(NumberOfQuestions != other.NumberOfQuestions)
            return NumberOfQuestions > other.NumberOfQuestions ? 1 : -1;
        
        return 0;
    }

    public object Clone()
    {
        // Time , NumberOfQuestions, Mode
        Exam clonedExam =  (Exam)this.MemberwiseClone();
        if(Questions != null)
        {
            clonedExam.Questions = (Question[])Questions.Clone();
        }
        if (this.QuestionAnswerDictionary != null)
        {
            clonedExam.QuestionAnswerDictionary = new Dictionary<Question, Answer>(this.QuestionAnswerDictionary);
        }
        // i don't need to clone the subject because it's actually made to be shared among exams

        return clonedExam;
    }

    public abstract void ShowExam();
    public virtual void Start()
    {
        Mode = ExamMode.Starting;
        Console.WriteLine("Exam Started");
        OnExamStarted();
    }

    protected virtual void OnExamStarted()
    {
        ExamStarted?.Invoke(this, new ExamEventArgs(Subject, this));
    }

    public virtual void Finish()
    {
        Mode = ExamMode.Finished;
        Console.WriteLine("Exam Finished");
        CorrectExam();
    }
    public void CorrectExam()
    {
        if (Mode != ExamMode.Finished)
            throw new Exception($"The Exam Hasn't finished to get it's Correctness");
        
        ExamTotalMarks = 0;
        StudExamMarks = 0;

        foreach(Question question in Questions)
        {
            if(question == null)   continue;
            ExamTotalMarks += question.Marks;

            if(QuestionAnswerDictionary.TryGetValue(question,out Answer? StdAns))
            {
                if(question.CheckAnswer(StdAns))
                    StudExamMarks += question.Marks;
            }
        }
        Console.WriteLine($"\nFinal Grade: {ExamTotalMarks} / {StudExamMarks}");

    }
    
}
