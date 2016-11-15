using System.Collections.ObjectModel;
using System.Linq;

namespace MiscSnippets.Code.DataStructures {
    public class NodeList<T> : Collection<Node<T>> {
        public NodeList() : base() { }

        public NodeList(int initialSize) {
            for (var index = 0; index < initialSize; index++)
                Items.Add(default(Node<T>));
        }

        public Node<T> FindByValue(T value) => Items.SingleOrDefault(node => node.Data.Equals(value));
    }
}