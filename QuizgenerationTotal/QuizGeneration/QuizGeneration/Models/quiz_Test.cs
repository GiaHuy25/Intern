using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGeneration.Models
{
    public class QuizTest
    {
        public int Quiz_Id { get; set; }
        public string Name { get; set; }
        public List<QuestionSys> QuestionSys { get; set; }
    }
}
