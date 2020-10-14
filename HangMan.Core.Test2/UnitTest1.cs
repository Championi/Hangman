using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangMan.Core.Test2
{
    [TestClass]
    public class UnitTest1
    {
      
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
        
        [TestMethod]
        public void ReturnCurrentGuessAsString()
        {
            Hangman.Core.WordGameCore hangman = new Hangman.Core.WordGameCore("Applepie");
            //string aStr = hangman.CreateCurrentGuessAsString();
            hangman.correctlyGuessed += "A";
            Assert.AreEqual("A-------", hangman.CreateCurrentGuessAsString());
        }
    }
}
