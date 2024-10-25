using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGeneration.Models
{
    public class UserAnswer
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string Answer_Id { get; set; }
        public int Quiz_question_Id { get; set; }
    }
}
