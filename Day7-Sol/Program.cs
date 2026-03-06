using Day7_Sol.Models.Answers;
using Day7_Sol.Models.Exams;
using Day7_Sol.Models.Questions;
using Day7_Sol.Models.Students;
using Day7_Sol.Models.Subjects;
using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("===== Examination Management System =====\n");

            // 1️⃣ Create Subject
            Subject subject = new Subject("Object Oriented Programming");

            // 2️⃣ Create Students
            Student s1 = new Student(1, "Ahmed");
            Student s2 = new Student(2, "Mona");
            Student s3 = new Student(3, "Omar");

            subject.Enroll(s1);
            subject.Enroll(s2);
            subject.Enroll(s3);

            // 3️⃣ Create QuestionList (with logging)
            QuestionList practiceQuestions = new QuestionList("PracticeExamLog.txt");
            QuestionList finalQuestions = new QuestionList("FinalExamLog.txt");

            // =============================
            // 4️⃣ Create Questions
            // =============================

            // True/False Question
            var tfAnswers = new AnswerList();
            tfAnswers.Add(new Answer(1, "True"));
            tfAnswers.Add(new Answer(2, "False"));

            Question q1 = new TrueFalseQuestion(
                "Q1",
                "C# supports OOP.",
                5,
                true
            );

            // Choose One Question
            var chooseOneAnswers = new AnswerList();
            chooseOneAnswers.Add(new Answer(1, "Encapsulation"));
            chooseOneAnswers.Add(new Answer(2, "Abstraction"));
            chooseOneAnswers.Add(new Answer(3, "Compilation"));

            Question q2 = new ChooseOneQuestion(
                "Q2",
                "Which is an OOP principle?",
                10,
                chooseOneAnswers,
                chooseOneAnswers.GetById(1)
            );

            // Add questions to both exams
            practiceQuestions.Add(q1);
            practiceQuestions.Add(q2);

            finalQuestions.Add(q1);
            finalQuestions.Add(q2);

            // 5️⃣ Create Exams
            Exam practiceExam = new PracticeExam(
                60,
                practiceQuestions.Count,
                practiceQuestions.ToArray(),
                subject
            );

            Exam finalExam = new FinalExam(
                90,
                finalQuestions.Count,
                finalQuestions.ToArray(),
                subject
            );

            // Subscribe students to both exams
            subject.NotifyStudents(practiceExam);
            subject.NotifyStudents(finalExam);

            // 6️⃣ Ask User
            Console.WriteLine("Select Exam Type:");
            Console.WriteLine("1 - Practice");
            Console.WriteLine("2 - Final");

            Console.Write("Enter choice:(1 || 2) ");
            string choice = Console.ReadLine();

            Exam selectedExam = null;

            switch (choice)
            {
                case "1":
                    selectedExam = practiceExam;
                    break;
                case "2":
                    selectedExam = finalExam;
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    return;
            }

            // 7️⃣ Start Lifecycle
            selectedExam.Start();   // Mode → Starting → Trigger Event
            selectedExam.ShowExam();
            selectedExam.Finish();

            Console.WriteLine("\n===== Exam Process Completed =====");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}