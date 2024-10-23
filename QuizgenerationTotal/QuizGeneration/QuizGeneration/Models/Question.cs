using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGeneration.Models
{
    public class Question
    {
        public int Id { get; set; }
        public List<String> TrueAnswerIds { get; set; }
        public Type type { get; set; }
        public int level {  get; set; }
        public string content   { get; set; }
        public Category Category { get; set; }
        public bool CheckAnswer(List<String> selectedAnswerIds)
        {
            return TrueAnswerIds.SequenceEqual(selectedAnswerIds);
        }
    }
}
