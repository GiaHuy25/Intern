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

        public List<List<string>> CorrectAnswersForBlanks { get; set; } = new List<List<string>>();
        public List<string> TrueAnswer { get; set; } = new List<string>();

        public bool CheckAnswer(List<string> Answer)
        {
            if (QuestionType != null && QuestionType.Type_Id == 1) // Chỉ cần một đáp án đúng
            {
               
                foreach (var answer in Answer)
                {
                    if (TrueAnswer.Contains(answer))
                    {
                        return true;
                    }
                }
                return false;
            }
            else if (QuestionType != null && (QuestionType.Type_Id == 2 || QuestionType.Type_Id == 5)) // Tất cả đáp án phải đúng
            {
                if (TrueAnswer.Count != Answer.Count)
                    return false;

                // Nếu là "Ordering", yêu cầu đúng thứ tự
                if (QuestionType.Type_Id == 5)
                {
                    for (int i = 0; i < TrueAnswer.Count; i++)
                    {
                        if (TrueAnswer[i] != Answer[i])
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else // Nếu là "Multiple", không yêu cầu đúng thứ tự
                {
                    foreach (var trueanswer in TrueAnswer)
                    {
                        if (!Answer.Contains(trueanswer))
                            return false;
                    }
                    return true;
                }
            }
            else if (QuestionType != null && QuestionType.Type_Id == 4)// điền vào chỗ trống
            {
                if (CorrectAnswersForBlanks.Count != Answer.Count)
                    return false;

                for (int i = 0; i < CorrectAnswersForBlanks.Count; i++)
                {
                    var correctAnswersForPosition = CorrectAnswersForBlanks[i]; 
                    var answerForPosition = Answer[i]; 
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
