namespace MiscSnippets.Code.DataStructures {
    public class BinaryTree<T> {
        public BinaryTreeNode<T> Root { get; set; } = null;

        public virtual void Clear() {
            Root = null;
        }
    }
}