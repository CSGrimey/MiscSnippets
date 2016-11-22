using System;

namespace MiscSnippets.Code.DataStructures {
    public class BinaryTree<T> {
        public BinaryTreeNode<T> Root { get; set; } = null;

        public virtual void Clear() {
            Root = null;
        }

        // In a preorder traversal of the BST would begin by calling this method, 
        // passing in the BST's root.
        public void PreorderTraversal(BinaryTreeNode<T> current) {
            if (current != null) {
                Console.WriteLine(current.Data);

                Console.WriteLine(current.Left);
                Console.WriteLine(current.Right);
            }
        }

        public void InorderTraversal(BinaryTreeNode<T> current) {
            if (current != null) {
                InorderTraversal(current.Left);

                Console.WriteLine(current.Data);

                InorderTraversal(current.Right);
            }
        }
    }
}