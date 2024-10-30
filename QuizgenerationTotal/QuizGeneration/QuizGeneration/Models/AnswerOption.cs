using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGeneration.Models
{
    public class AnswerOption
    {
        public string AnswerId { get; set; }
        public int AnswerType { get; set; }
        public int QusId { get; set; }
        public string Content { get; set; }
        public int ResultOption { get; set; } // Giá trị khác 0 là đáp án đúng

        public AnswerOption(string answerId, string content, int resultOption)
        {
            AnswerId = answerId;
            Content = content;
            ResultOption = resultOption;
        }

    }
}
