using System;
using BoggleScore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoggleScorer_Tests
{
    [TestClass]
    public class Word_Tests
    {
        [DataTestMethod]
        [DataRow("hello", 21)]
        [DataRow("test", 6)]
        [DataRow("swerves", 57)]
        [DataRow("yellow", 35)]
        [DataRow("persistent", 80)]
        public void Word_CalculateScore_ShouldReturnCorrectScore(string word, int score)
        {
            //Arrange
            IWord wordScore = new Word(word);
            //Act
            var expected = score;
            var actual = wordScore.CalculateScore();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(" ", 0)]
        [DataRow("", 0)]
        public void Word_CalculateScore_ScoreShouldBeZero(string word, int score)
        {
            //Arrange
            IWord wordScore = new Word(word);
            //Act
            var expected = score;
            var actual = wordScore.CalculateScore();
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
