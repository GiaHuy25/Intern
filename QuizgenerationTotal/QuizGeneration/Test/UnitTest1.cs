using QuizGeneration.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckAnswer_CorrectAnswer_ReturnsTrue()
        {
            var question = new Question
            {
                Id = 1,
                TrueAnswerIds = new List<String> { "2", "3", "4" },
                content = "Select the first three prime numbers"
            };

            // Act
            var result = question.CheckAnswer(new List<String> { "2", "3", "4" });

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CheckAnswer_WrongAnswer_ReturnsFalse()
        {
            var question = new Question
            {
                Id = 1,
                TrueAnswerIds = new List<String> { "2", "3", "4" },
                content = "Select the first three prime numbers"
            };

            // Act
            var result = question.CheckAnswer(new List<String> { "4","2", "3" });

            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void AnswerContent_IsNotNullOrEmpty()
        {
            // Arrange
            var answer = new Answer
            {
                Id = 1,
                Answer_content = "Paris"
            };

            // Act
            var isEmpty = string.IsNullOrEmpty(answer.Answer_content);

            // Assert
            Assert.IsFalse(isEmpty);
        }
    }
}
