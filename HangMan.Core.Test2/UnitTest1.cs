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
    }
}
