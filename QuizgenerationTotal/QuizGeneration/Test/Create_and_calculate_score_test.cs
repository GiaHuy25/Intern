using QuizGeneration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Create_and_calculate_score_test
    {
        [TestClass]
        public class QuizTestTests
        {
            [TestMethod]
            public void Test_BuildQuizTest_CreatesQuizWithCorrectQuestionsAndScores()
            {
                // Arrange
                int quizTestId = 1;
                string quizName = "Sample Quiz";
                List<QuestionSys> questions = new List<QuestionSys>
            {
                new QuestionSys { Qus_Id = 1, Content = "Question 1", QuestionType = questionType.Single },
                new QuestionSys { Qus_Id = 2, Content = "Question 2", QuestionType = questionType.multiple },
                new QuestionSys { Qus_Id = 3, Content = "Question 3", QuestionType = questionType.ordering }
            };
                int defaultScore = 10;

                // Act
                QuizTest quizTest = QuizTest.BuildQuizTest(quizTestId, quizName, questions, defaultScore);

                // Assert
                Assert.AreEqual(quizTestId, quizTest.QuizTestId);
                Assert.AreEqual(quizName, quizTest.Name);
                Assert.AreEqual(3, quizTest.Questions.Count); // Kiểm tra số lượng câu hỏi

                // Kiểm tra nội dung và điểm số của từng câu hỏi
                for (int i = 0; i < questions.Count; i++)
                {
                    Assert.AreEqual(questions[i].Content, quizTest.Questions[i].Question.Content);
                    Assert.AreEqual(defaultScore, quizTest.Questions[i].Score);
                }
            }

            [TestMethod]
            public void Test_CalculateScore_ReturnsCorrectScore()
            {
                int quizTestId = 1;
                string quizName = "Math Quiz";
                int defaultScore = 10;

                // Tạo các câu hỏi cho bài kiểm tra
                List<QuestionSys> questions = new List<QuestionSys>
            {
                new QuestionSys { Qus_Id = 1, Content = "Question 1", QuestionType = questionType.Single },
                new QuestionSys { Qus_Id = 2, Content = "Question 2", QuestionType = questionType.multiple },
                new QuestionSys { Qus_Id = 3, Content = "Question 3", QuestionType = questionType.ordering }
            };

                // Tạo bài kiểm tra
                QuizTest quizTest = QuizTest.BuildQuizTest(quizTestId, quizName, questions, defaultScore);

                // Thiết lập các đáp án đúng cho mỗi câu hỏi trong QuestionSys
                questions[0].AnswerOptions = new List<AnswerOption>
            {
                new AnswerOption("A", "Correct Answer", 1), // Đáp án đúng cho câu hỏi 1
                new AnswerOption("B", "Wrong Answer", 0)
            };

                questions[1].AnswerOptions = new List<AnswerOption>
            {
                new AnswerOption("A", "Correct Answer 1", 1),
                new AnswerOption("B", "Correct Answer 2", 1),
                new AnswerOption("C", "Wrong Answer", 0)
            };

                questions[2].AnswerOptions = new List<AnswerOption>
            {
                new AnswerOption("A", "Step 1", 1),
                new AnswerOption("B", "Step 2", 2),
                new AnswerOption("C", "Step 3", 3),
                new AnswerOption("D", "Wrong Step", 0)
            };

                // Câu trả lời của người dùng
                Dictionary<int, List<string>> userAnswers = new Dictionary<int, List<string>>
            {
                { 1, new List<string> { "A" } },               // Đúng cho câu hỏi 1
                { 2, new List<string> { "A", "B" } },          // Đúng cho câu hỏi 2
                { 3, new List<string> { "A", "B", "C" } }      // Đúng cho câu hỏi 3
            };

                int totalScore = quizTest.CalculateScore(userAnswers);

                int expectedScore = defaultScore * 3; // Vì tất cả các câu hỏi đều đúng, tổng điểm = 10 * 3
                Assert.AreEqual(expectedScore, totalScore);
            }

            [TestMethod]
            public void Test_CalculateScore_ReturnsPartialScore()
            {
                int quizTestId = 2;
                string quizName = "Science Quiz";
                int defaultScore = 10;

                // Tạo các câu hỏi cho bài kiểm tra
                List<QuestionSys> questions = new List<QuestionSys>
            {
                new QuestionSys { Qus_Id = 1, Content = "Question 1", QuestionType = questionType.Single },
                new QuestionSys { Qus_Id = 2, Content = "Question 2", QuestionType = questionType.multiple }
            };

                // Tạo bài kiểm tra
                QuizTest quizTest = QuizTest.BuildQuizTest(quizTestId, quizName, questions, defaultScore);

                // Thiết lập các đáp án đúng cho mỗi câu hỏi trong QuestionSys
                questions[0].AnswerOptions = new List<AnswerOption>
            {
                new AnswerOption("A", "Correct Answer", 1), // Đáp án đúng cho câu hỏi 1
                new AnswerOption("B", "Wrong Answer", 0)
            };

                questions[1].AnswerOptions = new List<AnswerOption>
            {
                new AnswerOption("A", "Correct Answer 1", 1),
                new AnswerOption("B", "Correct Answer 2", 1),
                new AnswerOption("C", "Wrong Answer", 0)
            };

                Dictionary<int, List<string>> userAnswers = new Dictionary<int, List<string>>
            {
                { 1, new List<string> { "A" } },               // Đúng cho câu hỏi 1
                { 2, new List<string> { "A", "C" } }           // Sai cho câu hỏi 2
            };

                int totalScore = quizTest.CalculateScore(userAnswers);

                int expectedScore = defaultScore * 1; // Vì chỉ đúng câu hỏi 1, tổng điểm = 10 * 1
                Assert.AreEqual(expectedScore, totalScore);
            }
        }
    }
}
