using System;
using System.Text;
using System.Linq;

namespace MiscSnippets.Code.Exercises {
    class MiscExercises {
        public string MultiplicationTable(int max) {
            StringBuilder tableStringBuilder = new StringBuilder();

            for (int i = 1; i < max; i++) {
                for (int j = 1; j < max; j++) tableStringBuilder.Append(i * j);

                tableStringBuilder.Append(Environment.NewLine);
            }

            return tableStringBuilder.ToString();
        }

        public string StringReversal(string input) {
            StringBuilder reversedInput = new StringBuilder();

            for (int i = input.Length - 1; i >= 0; i--) reversedInput.Append(input[i]);

            return reversedInput.ToString();
        }

        public string PrintOddNumbers(int input) {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i < input; i++) if (i % 2 == 1) result.Append(i.ToString() + ",");

            return result.ToString();
        }

        public int LargestValueInIntArray(int[] input) => input.OrderBy(i => i).Last();
    }
}