using System;
using System.Text;

namespace MiscSnippets.Code.Exercises {
    class MiscExercises {
        public string MultiplicationTable(int max) {
            StringBuilder tableStringBuilder = new StringBuilder();

            for (int i = 1; i < max; i++) {
                for (int j = 1; j < max; j++) {
                    int multipliedResult = i * j;

                    tableStringBuilder.Append(multipliedResult);
                }

                tableStringBuilder.Append(Environment.NewLine);
            }

            return tableStringBuilder.ToString();
        }
    }
}