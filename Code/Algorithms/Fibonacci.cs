namespace MiscSnippets.Code.Algorithms {
    class Fibonacci {
        public int FibonacciIterative(int input) {
            int a = 0;
            int b = 1;

            for (int index = 0; index < input; index++) {
                int temp = a;
                a = b;
                b = temp + b;
            }

            return a;
        }

        public int FibonacciRecursive(int index, int input, int a, int b) {
            if (index == input) return input;
            else {
                int temp = a;
                a = b;
                b = temp + b;

                return FibonacciRecursive(index - 1, input, a, b);
            }
        }
    }
}