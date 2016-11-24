using System;

namespace MiscSnippets.Code.Algorithms {
    public class Search {
        public static int ValueNotFound { get; } = -1;

        public int BinarySearchIterative(int[] input, int value) {
            if (input.Length == 0) return ValueNotFound;
            else if (input.Length == 1) {
                if (input[0] == value) return 0;
                else return ValueNotFound;
            } else {
                int start = 0;
                int end = input.Length - 1;

                while (true) {
                    int currentIndex = (start + end) / 2;

                    int currentValue = input[currentIndex];

                    if (start > end) return ValueNotFound;
                    else if (value < currentValue) end = currentIndex - 1;
                    else if (value > currentValue) start = currentIndex + 1;
                    else return currentIndex;
                }
            }
        }
    }
}