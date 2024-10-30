using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGeneration.Models
{
    public class QuestionSys
    {
        public int Qus_Id { get; set; }
        public string Content { get; set; }
        public questionType QuestionType { get; set; }
        public int Cate_Id { get; set; }
        public int Level_Id { get; set; }
        public int? Tag_Id { get; set; }

        public List<AnswerOption> AnswerOptions { get; set; } = new List<AnswerOption>();

        public bool CheckAnswer(List<string> answerIds)
        {
            List<AnswerOption> correctAnswers = AnswerOptions
                .Where(a => a.ResultOption != 0)
                .OrderBy(a => a.ResultOption)
                .ToList();

            if (QuestionType == questionType.Single)
            {
                return answerIds.Any(answerId => correctAnswers.Any(ca => ca.AnswerId == answerId));
            }

            else if (QuestionType == questionType.multiple)
            {
                if (correctAnswers.Count != answerIds.Count)
                {
                    return false;
                }

                return correctAnswers.All(correctAnswer => answerIds.Contains(correctAnswer.AnswerId));
            }

            else if (QuestionType == questionType.ordering)
            {
                int totalPositions = correctAnswers.Max(a => a.ResultOption);

                if (answerIds.Count != totalPositions)
                {
                    return false;
                }

                for (int position = 1; position <= totalPositions; position++)
                {
                    var correctOptionsForPosition = correctAnswers
                        .Where(a => a.ResultOption == position)
                        .Select(a => a.AnswerId)
                        .ToList();

                    if (position > answerIds.Count || !correctOptionsForPosition.Contains(answerIds[position - 1]))
                    {
                        return false;
                    }
                }

                return true; 
            }

            else if (QuestionType == questionType.fillinblank)
            {
                int totalPositions = correctAnswers.Max(a => a.ResultOption);

                if (answerIds.Count != totalPositions)
                {
                    return false;
                }

                for (int position = 1; position <= totalPositions; position++)
                {
                    var correctOptionsForPosition = correctAnswers
                        .Where(a => a.ResultOption == position)
                        .Select(a => a.AnswerId)
                        .ToList();

                    if (position > answerIds.Count || !correctOptionsForPosition.Contains(answerIds[position - 1]))
                    {
                        return false;
                    }
                }

                return true; 
            }

            return false;
        }
    }
}

