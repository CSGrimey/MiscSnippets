using MiscSnippets.Code;
using NUnit.Framework;
using System.Collections.Generic;

namespace MiscSnippets.Tests {
    [TestFixture]
    public class LinkedListsTests {
        LinkedListsExercises exercises = new LinkedListsExercises();

        [Test]
        public void OnePointOneTest() {
            var unsortedList = new List<string> {
                "This",
                "is",
                "not",
                "the",
                "best",
                "test",
                "in",
                "the",
                "world",
                ".",
                "This",
                "is",
                "just",
                "a",
                "tribute",
                "."
            };

            var expectedResult = new List<string> {
                "This",
                "is",
                "not",
                "the",
                "best",
                "test",
                "in",
                "world",
                ".",
                "just",
                "a",
                "tribute"
            };

            Assert.AreEqual(expectedResult, exercises.TwoPointOne(unsortedList));
        }
    }
}