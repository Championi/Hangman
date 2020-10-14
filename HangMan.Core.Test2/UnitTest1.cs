using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangMan.Core.Test2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldTestHangmanName()
        {
            var aTest = new Hangman.Core.HangmanTest0("A_word");
            Assert.AreEqual("A_word", aTest.GetWord());
        }
        [TestMethod]
        public void Should_Add_Two_Ints()
        {
            var aTest = new Hangman.Core.HangmanTest0();
            Assert.AreEqual(6, aTest.Add(3,3));
        }
        [TestMethod]
        public void TestValidateUserChar1()
        {
            Hangman.Core.WordGameCore hangman = new Hangman.Core.WordGameCore("Applepie"); 
            Assert.AreEqual(true, hangman.ValidateUserChar("a"));
        }
        [TestMethod]
        public void TestValidateUserChar2()
        {
            Hangman.Core.WordGameCore hangman = new Hangman.Core.WordGameCore("Applepie");
            Assert.AreEqual(false, hangman.ValidateUserChar("1"));
        }
    }
}
