using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class Node
    {
        public int value { get; set; }
        public Node left{ get; set; }
        public Node right { get; set; }

        public Node(int value) {
            this.value = value;
            this.left = null;
            this.right = null;
        }
    }
}
