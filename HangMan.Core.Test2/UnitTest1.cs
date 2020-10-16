
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
            Assert.AreEqual(true, hangman.ValidateUserInput('a'));
        }
        [TestMethod]
        public void TestValidateUserChar2()
        {
            Hangman.Core.WordGameCore hangman = new Hangman.Core.WordGameCore("Applepie");
            Assert.AreEqual(false, hangman.ValidateUserInput('1'));
        }
        
        [TestMethod]
        public void ReturnCurrentGuessAsString()
        {
            Hangman.Core.WordGameCore hangman = new Hangman.Core.WordGameCore("Applepie");
            //string aStr = hangman.CreateCurrentGuessAsString();
            hangman.AddCorreclyGuessed("A");
            Assert.AreEqual("A-------", hangman.CreateCurrentGuessAsString());
        }

        [TestMethod]
        public void ReturnCurrentGuessAsStringFail()
        {
            Hangman.Core.WordGameCore hangman = new Hangman.Core.WordGameCore("Applepie");
            //string aStr = hangman.CreateCurrentGuessAsString();
            hangman.AddCorreclyGuessed("B");
            Assert.AreEqual("--------", hangman.CreateCurrentGuessAsString());
        }
    }
}
