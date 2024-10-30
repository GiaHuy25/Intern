using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGeneration.Models
{
    public class QuizQuestion
    {
        public int QuizQuestionId { get; set; } 
        public QuestionSys Question { get; set; } 
        public int Score { get; set; } 

        public QuizQuestion(int quizQuestionId, QuestionSys question, int score)
        {
            QuizQuestionId = quizQuestionId;
            Question = question;
            Score = score;
        }
        public bool CheckAnswer(List<string> userAnswers)
        {
            return Question.CheckAnswer(userAnswers);
        }
    }

}
