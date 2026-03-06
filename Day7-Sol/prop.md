ExaminationSystem
├── Models
│   │──Answers
│   │   ├── Answer.cs
│   │   └── AnswerList.cs
│   │ 
│   └──Questions
│       ├── Question.cs
│       ├── TrueFalseQuestion.cs
│       ├── ChooseOneQuestion.cs
│       └── ChooseAllQuestion.cs
│
├── Exams
│   ├── Exam.cs
│   ├── PracticeExam.cs
│   └── FinalExam.cs
│
├── Subjects
│   └── Subject.cs
│
├── Students
│   └── Student.cs
│
├── Collections
│   ├── QuestionList.cs
│   └── Repository.cs
│
├── Infrastructure
│   ├── ExamEventArgs.cs
│   ├── ExamStartedHandler.cs
│   └── ExamMode.cs
│
└── Program.cs