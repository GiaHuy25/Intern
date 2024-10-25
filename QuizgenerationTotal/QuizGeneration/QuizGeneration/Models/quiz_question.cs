using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGeneration.Models
{
    public class QuizQuestion
    {
        public int Quiz_question_Id { get; set; }
        public int Quiz_Id { get; set; }
        public int Qus_Id { get; set; }
        public int Score { get; set; }
    }
}
