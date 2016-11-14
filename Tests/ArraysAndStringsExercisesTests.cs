using MiscSnippets.Code;
using NUnit.Framework;

namespace MiscSnippets.Tests {
    [TestFixture]
    class ArraysAndStringsExercisesTests {
        ArrayAndStringsExercises exercises = new ArrayAndStringsExercises();

        [Test]
        public void OnePointOneTest() {
            Assert.AreEqual(true, exercises.OnePointOne("abcdefg"));
            Assert.AreEqual(false, exercises.OnePointOne("abcdefgabsced"));
        }

        [Test]
        public void OnePointThreeTest() =>
            Assert.AreEqual("gfdecba", exercises.OnePointThree("gfdgedffcba"));

        [Test]
        public void OnePointFourTest() {
            Assert.AreEqual(true, exercises.OnePointFour("spar", "rasp"));
            Assert.AreEqual(false, exercises.OnePointFour("abcdefgabsced", "spar"));
        }

        [Test]
        public void OnePointFiveTest() {
            Assert.AreEqual("This%20is%20a%20test%20string.", exercises.OnePointFive("This is a test string."));
        }
    }
}