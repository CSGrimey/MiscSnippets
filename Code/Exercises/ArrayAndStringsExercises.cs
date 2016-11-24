using System.Collections.Generic;
using System.Linq;

namespace MiscSnippets.Code {
    public class ArrayAndStringsExercises {
        // Implement an algorithm to determine if a string has all unique characters. 
        // What if you can not use additional data structures?
        public bool OnePointOne(string text) {
            IEnumerable<char> uniqueCharacters = text.ToCharArray().Distinct();

            return text == string.Join(string.Empty, uniqueCharacters);
        }

        // Design an algorithm and write code to remove the duplicate characters in a string
        // without using any additional buffer. 
        // NOTE: One or two additional variables are fine.
        // An extra copy of the array is not.
        public string OnePointThree(string text) => 
            string.Join(string.Empty, text.ToCharArray().GroupBy(c => c).Select(gc => gc.Key));

        // Write a method to decide if two strings are anagrams or not.
        public bool OnePointFour(string textOne, string textTwo) {
            List<char> uniqueCharactersFromTextOne = textOne.ToCharArray().Distinct().ToList();
            List<char> uniqueCharactersFromTextTwo = textTwo.ToCharArray().Distinct().ToList();

            if (uniqueCharactersFromTextOne.Count != uniqueCharactersFromTextTwo.Count) return false;

            return uniqueCharactersFromTextOne.Select(uc => uniqueCharactersFromTextTwo.Contains(uc)).All(result => result);
        }

        // Write a method to replace all spaces in a string with ‘c’.
        public string OnePointFive(string text) => text.Replace(" ", "%20");
    }
}