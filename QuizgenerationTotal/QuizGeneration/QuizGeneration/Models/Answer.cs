using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGeneration.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Answer_content { get; set; }
        public Type Answer_type { get; set; }

    }
}
