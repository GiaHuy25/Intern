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
        public QuestionType QuestionType { get; set; }
        public int Cate_Id { get; set; }
        public int Level_Id { get; set; }
        public int? Tag_Id { get; set; }

        // Thêm các thuộc tính phụ thuộc
        public List<List<string>> CorrectAnswersForBlanks { get; set; } = new List<List<string>>();
        public List<string> TrueAnswerIds { get; set; } = new List<string>();

        public bool CheckAnswer(List<string> answerIds)
        {
            if (QuestionType != null && QuestionType.Name == "Single")
            {
                // Chỉ cần một đáp án đúng
                foreach (var answer in answerIds)
                {
                    if (TrueAnswerIds.Contains(answer))
                    {
                        return true;
                    }
                }
                return false;
            }
            else if (QuestionType != null && QuestionType.Name == "Multiple")
            {
                // Tất cả các đáp án phải đúng
                if (TrueAnswerIds.Count != answerIds.Count)
                    return false;

                foreach (var id in TrueAnswerIds)
                {
                    if (!answerIds.Contains(id))
                        return false;
                }
                return true;
            }

            else if (QuestionType != null && QuestionType.Name == "FillInTheBlank")
            {
                if (CorrectAnswersForBlanks.Count != answerIds.Count)
                    return false;

                for (int i = 0; i < CorrectAnswersForBlanks.Count; i++)
                {
                    var correctAnswersForPosition = CorrectAnswersForBlanks[i]; 
                    var answerForPosition = answerIds[i]; 
                    if (!correctAnswersForPosition.Contains(answerForPosition))
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
