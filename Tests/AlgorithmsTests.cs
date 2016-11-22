using MiscSnippets.Code.Algorithms;
using NUnit.Framework;

namespace MiscSnippets.Tests {
    [TestFixture]
    class AlgorithmsTests {
        Search search = new Search();

        [Test]
        public void ShouldFindValueViaBinarySearch() {
            int[] values = { 1, 3, 4, 6, 8, 9, 11, 121, 123 };

            Assert.AreEqual(2, search.BinarySearchIterative(values, 4));
            Assert.AreEqual(7, search.BinarySearchIterative(values, 121));
            Assert.AreEqual(4, search.BinarySearchIterative(values, 8));
            Assert.AreEqual(Search.ValueNotFound, search.BinarySearchIterative(values, 7));
        }
    }
}