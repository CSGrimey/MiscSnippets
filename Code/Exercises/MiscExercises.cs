using System;
using System.Text;

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
    }
}