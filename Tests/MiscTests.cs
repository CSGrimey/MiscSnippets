using MiscSnippets.Code.Exercises;
using NUnit.Framework;
using System;

namespace MiscSnippets.Tests {
    [TestFixture]
    class MiscTests {
        private readonly MiscExercises exercises = new MiscExercises();

        [Test]
        public void ShouldCreateMultiplicationTableString() {
            string expectedResult = $"1234{Environment.NewLine}2468{Environment.NewLine}36912{Environment.NewLine}481216{Environment.NewLine}";

            Assert.AreEqual(expectedResult, exercises.MultiplicationTable(5));
        }

        [Test]
        public void ShouldReverseString() {
            const string expectedResult = "madA m'I ,madaM";

            Assert.AreEqual(expectedResult, exercises.StringReversal("Madam, I'm Adam"));
        }

        [Test]
        public void ShouldOnlyPrintOddNumbers() {
            const string expectedResult = "1,3,5,7,9,11,13,15,";

            Assert.AreEqual(expectedResult, exercises.PrintOddNumbers(16));
        }

        [Test]
        public void ShouldReturnLargestValueInIntArray() {
            int[] input = { 2, 1, 4, 5, 2, 1, 0, 9, 2, 4 };

            Assert.AreEqual(9, exercises.LargestValueInIntArrayLinq(input));
        }
    }
}