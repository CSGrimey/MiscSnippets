namespace MiscSnippets.Code.Algorithms {
    public class Search {
        public static int ValueNotFound { get; } = -1;

        public int BinarySearchIterative(int[] input, int value) {
            if (input.Length == 0) return ValueNotFound;
            else if (input.Length == 1) {
                if (input[0] == value) return 0;
                else return ValueNotFound;
            } else {
                int currentIndex = input.Length / 2;

                while (true) {
                    int currentValue = input[currentIndex];

                    if (currentValue > value) currentIndex = currentIndex / 2;
                    else if (currentValue < value) currentIndex += (input.Length - currentIndex) / 2;
                    else {
                        if (currentValue == value) return currentIndex;
                        else return ValueNotFound;
                    }
                }
            }
        }
    }
}