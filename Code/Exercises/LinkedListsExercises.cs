using System.Collections.Generic;
using System.Linq;

namespace MiscSnippets.Code {
    public class LinkedListsExercises {
        // Write code to remove duplicates from an unsorted linked list.
        // How would you solve this problem if a temporary buffer is not allowed?
        public List<T> TwoPointOne<T>(List<T> unsortedList) =>
            unsortedList.GroupBy(e => e).Select(ge => ge.First()).ToList();
    }
}