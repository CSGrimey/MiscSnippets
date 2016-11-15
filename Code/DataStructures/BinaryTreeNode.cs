namespace MiscSnippets.Code.DataStructures {
    public class BinaryTreeNode<T> : Node<T> {
        public BinaryTreeNode<T> Left {
            get {
                if (Neighbours == null) return null;
                else return (BinaryTreeNode<T>)Neighbours[0];
            }
            set {
                if (Neighbours == null) Neighbours = new NodeList<T>(2);

                Neighbours[0] = value;
            }
        }

        public BinaryTreeNode<T> Right {
            get {
                if (Neighbours == null) return null;
                else return (BinaryTreeNode<T>)Neighbours[1];
            }
            set {
                if (Neighbours == null) Neighbours = new NodeList<T>(2);

                Neighbours[1] = value;
            }
        }

        public BinaryTreeNode() : base() { }

        public BinaryTreeNode(T data) : base(data, null) { }

        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right) {
            Data = data;

            Neighbours = new NodeList<T>(2) {
                left,
                right
            };
        }
    }
}