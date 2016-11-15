namespace MiscSnippets.Code.DataStructures {
    public class Node<T> {
        private NodeList<T> neighbours;

        public T Data { get; set; }

        protected NodeList<T> Neighbours {
            get { return neighbours; }
            set { neighbours = value; }
        }

        public Node() { }

        public Node(T data) : this(data, null) { }

        public Node(T data, NodeList<T> neighbours) {
            Data = data;

            this.neighbours = neighbours;
        }
    }
}