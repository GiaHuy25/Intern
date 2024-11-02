using QuizGeneration.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace Test
{
    [TestClass]
    public class Check_answer_test
    {

        [TestClass]
        public class QuestionSysTests
        {
            [TestMethod]
            public void CheckAnswer_OneCorrectAnswer_ReturnsTrue()
            {
                var question = new QuestionSys
                {
                    Qus_Id = 1,
                    Content = "Chọn một số nguyên tố",
                    QuestionType = questionType.Single,
                    AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption("A", "2", 1),    // true
                    new AnswerOption("B", "4", 0),
                    new AnswerOption("C", "3", 1),    // true
                    new AnswerOption("D", "8", 0)
                }
                };

                var result = question.CheckAnswer(new List<string> { "C" });

                Assert.IsTrue(result);
            }

            [TestMethod]
            public void CheckAnswer_CorrectAnswer_ReturnsTrue()
            {
                var question = new QuestionSys
                {
                    Qus_Id = 1,
                    Content = "Chọn ba số nguyên tố đầu tiên",
                    QuestionType = questionType.multiple,
                    AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption("A", "2", 1),    // true
                    new AnswerOption("B", "3", 1),    // true
                    new AnswerOption("C", "5", 1),    // true
                    new AnswerOption("D", "4", 0)
                }
                };

                var result = question.CheckAnswer(new List<string> { "A", "B", "C" });

                Assert.IsTrue(result);
            }

            [TestMethod]
            public void CheckAnswer_FillInTheBlank()
            {
                var question = new QuestionSys
                {
                    Qus_Id = 1,
                    Content = "Điền vào chỗ trống: __ là thủ đô của Pháp. __ là thủ đô của Đức.",
                    QuestionType = questionType.fillinblank,
                    AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption("A", "Paris", 1),      // true 1
                    new AnswerOption("B", "Berlin", 2),    // true 2
                    new AnswerOption("C", "Lyon", 0),
                    new AnswerOption("D", "Hamburg", 0)
                }
                };

                var result = question.CheckAnswer(new List<string> { "A", "B" });

                Assert.IsTrue(result);
            }

            [TestMethod]
            public void CheckAnswer_FillInTheBlank_Multiple()
            {
                var question = new QuestionSys
                {
                    Qus_Id = 1,
                    Content = "Điền vào chỗ trống: __ là thủ đô của Pháp. __ là thủ đô của Đức.",
                    QuestionType = questionType.fillinblank,
                    AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption("A", "Paris", 1),         // true 1
                    new AnswerOption("B", "Berlin", 2),        // true 2
                    new AnswerOption("C", "Bonn", 2),         // true 2 (can choice 1 in many)
                    new AnswerOption("D", "Lyon", 0)
                }
                };

                var result = question.CheckAnswer(new List<string> { "A", "C"});

                Assert.IsTrue(result);
            }

            [TestMethod]
            public void CheckAnswer_OrderingCorrect_ReturnsTrue()
            {
                var question = new QuestionSys
                {
                    Qus_Id = 1,
                    Content = "Sắp xếp các số nguyên tố theo thứ tự tăng dần",
                    QuestionType = questionType.ordering,
                    AnswerOptions = new List<AnswerOption>
                    {
                        new AnswerOption("A", "2", 1),    // true 1
                        new AnswerOption("B", "3", 2),    // true 2
                        new AnswerOption("C", "5", 3),    // true 3
                        new AnswerOption("D", "4", 0)
                    }
                };

                var result1 = question.CheckAnswer(new List<string> { "A", "B", "C" }); 
                var result2 = question.CheckAnswer(new List<string> { "B", "A", "C" }); 

                Assert.IsTrue(result1);  // Kết quả là đúng
                Assert.IsFalse(result2); // Kết quả là sai
            }

        }
    }
}
