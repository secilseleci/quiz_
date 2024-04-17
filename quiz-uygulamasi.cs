using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace udemydersleri
{
    class Question

    {
        public Question(string text, string[] choices, string answer)
        {
            this.Text = text;
            this.Choices = choices;
            this.Answer = answer;
        }
        public string Text { get; set; }
        public string[] Choices { get; set; }
        public string Answer { get; set; }
        public bool CheckAnswer(string answer)
        { return this.Answer.ToLower() == answer.ToLower(); }
    }
    class Quiz
    {
        public Quiz(Question[] questions)
        {
            this.Questions = questions;
            this.QuestionIndex = 0;
            this.Score = 0;
        }
        private Question[] Questions { get; set; }
        private int QuestionIndex { get; set; }
        private int Score { get; set; }

        private Question GetQuestion() 
        {
            return this.Questions[this.QuestionIndex];
        }

        public void DisplayQuestion()
        {
            
            var question=this.GetQuestion();
            this.DisplayProgress();
            Console.WriteLine($"Soru{this.QuestionIndex+1}: {question.Text}");

            foreach (var c in question.Choices)
             {
                 Console.WriteLine($"-{c}");
             }

                Console.WriteLine("cevap: ");
                var cevap=Console.ReadLine();
                this.Guess(cevap);
        }

        private void Guess(string cevap)
        {
            
            var question = this.GetQuestion();

            if (question.CheckAnswer(cevap))
                this.Score += 1;
                this.QuestionIndex++;

            if (this.Questions.Length==this.QuestionIndex)
            {
                this.DisplayScore();
            }
            else
               
                this.DisplayQuestion();
            
        }
        private void DisplayScore()
        {
            Console.WriteLine($"Score: {this.Score}");
        }
        private void DisplayProgress()
        {
            int totalQuestions=this.Questions.Length;
            int questionNumber = this.QuestionIndex + 1;
            if(questionNumber <= totalQuestions)
            Console.WriteLine(questionNumber+ "/"+totalQuestions);
        }
    }
    public class Quiz_uygulamasi
    {
        static void Main(string[] args)
        {

            Question q1 = new Question
            ("En iyi programlama dili hangisidir?", new string[]{"Java", "C#", "Python", "Javascript" }, "C#");
            Question q2 = new Question
            ("Hangisi bir programlama dili değildir?", new string[] { "Java", "C#", "Python", "CSS3" }, "CSS3");
            Question q3 = new Question
            ("En iyi frontend frameworkü hangisidir?", new string[] { "React", "Blazor", "Javascript", "Angular" }, "Blazor");

            var questions=new Question[] {q1,q2,q3 };
            var quiz = new Quiz(questions);
            quiz.DisplayQuestion();


        }
    }
}
