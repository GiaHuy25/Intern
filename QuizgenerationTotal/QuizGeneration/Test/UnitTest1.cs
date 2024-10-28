using QuizGeneration.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    //public enum questionType
    //{
    //    single = 1,
    //    multiple = 2,
    //    fillintheblank = 3,
    //    ordering = 4
    //}
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void QuestionContent_IsNotNullOrEmpty() //Kiểm tra nội dung câu hỏi không được rỗng.
        {
            var question = new QuestionSys
            {
                Qus_Id = 1,
                Content = "HTML là gì?"
            };

            var isEmpty = string.IsNullOrEmpty(question.Content);

            Assert.IsFalse(isEmpty);
        }

        [TestMethod]
        public void AnswerContent_IsNotNullOrEmpty() //Kiểm tra nội dung câu trả lời không rỗng
        {
            var answer = new AnswerOption
            {
                Answer_Id = "A1",
                Content = "Paris"
            };

            var isEmpty = string.IsNullOrEmpty(answer.Content);

            Assert.IsFalse(isEmpty);
        }

        [TestMethod]
        public void CheckCorrectAnswer_ReturnsTrue() //Kiểm tra câu trả lời đúng.
        {
            var answer = new AnswerOption
            {
                Answer_Id = "A2",
                Content = "True",
                Result_option = 1
            };

            var isCorrect = answer.Result_option == 1;

            Assert.IsTrue(isCorrect);
        }

        [TestMethod]
        public void CheckWrongAnswer_ReturnsFalse() //Kiểm tra câu trả lời sai.
        {
            var answer = new AnswerOption
            {
                Answer_Id = "A3",
                Content = "False",
                Result_option = 0
            };

            var isCorrect = answer.Result_option == 1;

            Assert.IsFalse(isCorrect);
        }

        [TestMethod]
        public void CategoryName_IsNotNullOrEmpty() //Kiểm tra tên danh mục không được rỗng.
        {
            var category = new Category
            {
                Cate_Id = 1,
                Name = "Programming"
            };

            var isEmpty = string.IsNullOrEmpty(category.Name);

            Assert.IsFalse(isEmpty);
        }

        [TestMethod]
        public void UserName_IsNotNullOrEmpty() //Kiểm tra tên người dùng không được rỗng.
        {
            var user = new User
            {
                User_Id = 1,
                Name = "John Doe"
            };

            var isEmpty = string.IsNullOrEmpty(user.Name);

            Assert.IsFalse(isEmpty);
        }

        [TestMethod]
        public void QuizQuestion_Score_IsValid() //Kiểm tra điểm số của câu hỏi trong quiz phải hợp lệ (lớn hơn 0).
        {
            var quizQuestion = new QuizQuestion
            {
                Quiz_question_Id = 1,
                Qus_Id = 1,
                Quiz_Id = 1,
                Score = 5
            };

            var isValidScore = quizQuestion.Score > 0;

            Assert.IsTrue(isValidScore);
        }
        [TestMethod]
        public void CheckAnswer_OneCorrectAnswer_ReturnsTrue() // chỉ cần chọn 1 trong số những đáp án đúng
        {
            var question = new QuestionSys
            {
                Qus_Id = 1,
                Content = "Chọn một số nguyên tố",
                TrueAnswer = new List<string> { "2", "3", "5" },
                QuestionType = new QuestionType { Type_Id = 1, Name = "Single" }
            };
            var result = question.CheckAnswer(new List<string> { "2" });
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CheckAnswer_CorrectAnswer_ReturnsTrue() //Kiểm tra câu trả lời đúng thì trả về true.
        {
            var question = new QuestionSys
            {
                Qus_Id = 1,
                Content = "Chọn ba số nguyên tố đầu tiên",
                TrueAnswer = new List<string> { "2", "3", "5" },
                QuestionType = new QuestionType { Type_Id = 2, Name = "Multiple" }
            };

            var result = question.CheckAnswer(new List<string> { "2", "3", "5" });

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckAnswer_FillInTheBlank() // điền vào chỗ trống
        {
            // Arrange
            var question = new QuestionSys
            {
                Qus_Id = 1,
                Content = "Điền vào chỗ trống: __ là thủ đô của Pháp. __ là thủ đô của Đức.",
                QuestionType = new QuestionType { Type_Id = 4, Name = "FillInTheBlank" },
                CorrectAnswersForBlanks = new List<List<string>>
                {
                    new List<string> { "Paris" }, 
                    new List<string> { "Berlin" }
                }
            };

            var result = question.CheckAnswer(new List<string> { "Paris", "Berlin" }); 

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CheckAnswer_FillInTheBlank_Multiple() // điền vào chỗ trống một ô có 2 lựa chọn đúng
        {
            var question = new QuestionSys
            {
                Qus_Id = 1,
                Content = "Điền vào chỗ trống: __ là thủ đô của Pháp. __ là thủ đô của Đức.",
                QuestionType = new QuestionType { Type_Id = 4, Name = "FillInTheBlank" },
                CorrectAnswersForBlanks = new List<List<string>>
                {
                    new List<string> { "Paris" }, 
                    new List<string> { "Berlin", "Bonn" } 
                }
            };
            var result = question.CheckAnswer(new List<string> { "Paris", "Berlin" }); 

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CheckAnswer_OrderingCorrect_ReturnsTrue() // sắp xếp 
        {
            // Arrange
            var question = new QuestionSys
            {
                Qus_Id = 1,
                QuestionType = new QuestionType { Type_Id = 5, Name = "Ordering" },
                TrueAnswer = new List<string> { "2", "3", "5" }
            };

            // Act
            var result = question.CheckAnswer(new List<string> { "2", "3", "5" });

            // Assert
            Assert.IsTrue(result);
        }
    }
}
