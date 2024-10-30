using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGeneration.Models
{
    public class QuizTest
    {
        public int QuizTestId { get; set; } 
        public string Name { get; set; }
        public List<QuizQuestion> Questions { get; set; } = new List<QuizQuestion>(); 

        public QuizTest(int quizTestId, string name)
        {
            QuizTestId = quizTestId;
            Name = name;
        }
        public void AddQuestion(QuizQuestion quizQuestion)
        {
            Questions.Add(quizQuestion);
        }
        public static QuizTest BuildQuizTest(int quizTestId, string quizName, List<QuestionSys> questions, int defaultScore = 1)
        {
            QuizTest quizTest = new QuizTest(quizTestId, quizName);

            int quizQuestionId = 1;
            foreach (var question in questions)
            {
                QuizQuestion quizQuestion = new QuizQuestion(quizQuestionId++, question, defaultScore);
                quizTest.Questions.Add(quizQuestion);
            }

            return quizTest;
        }

        public int CalculateScore(Dictionary<int, List<string>> userAnswers)
        {
            int totalScore = 0;

            foreach (var quizQuestion in Questions)
            {
                if (userAnswers.TryGetValue(quizQuestion.QuizQuestionId, out List<string> answers))
                {
                    if (quizQuestion.CheckAnswer(answers))
                    {
                        totalScore += quizQuestion.Score;
                    }
                }
            }

            return totalScore;
        }


    }

}
