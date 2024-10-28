using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGeneration.Models
{
    public class AnswerOption
    {
        public string Answer_Id { get; set; }
        public string Content { get; set; }
        public string Answer_Type { get; set; }
        public int Qus_Id { get; set; }
        public int Result_option { get; set; } 

    }
}
