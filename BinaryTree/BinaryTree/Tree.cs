using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class Tree
    {
        private Node root { get; set; } //Se agrega el primer nodo al arbol binario que se ha creado

        public Tree() //constructor del tree class
        {
            this.root = null; //Root Node for the tree is null when initiated... el nodo de la raiz es 0 cuando inicia
        }

        public void Add(int newValue) //metodo para agregar nodos
        {
            if (root == null) //This just checks if the root node is null.//
            {
                root = new Node(newValue); //If it is, then add the node as the new root for our binary tree.
            }
            else 
            {
                Add(newValue, root); //Si la raiz root no es null se utiliza el metodo recursivo de Add para acomodar el nuevo nodo
            }
        }

        private void Add(int newValue, Node currentNode) //Recursive method to find the correct place to add our new node. It receives the integer value of the node that will be created and a node to start the search on our binay tree.
        {
            if (newValue <= currentNode.value) //Is the newValue is smaller than the current node value?
            {
                if (currentNode.left == null) //Is the position to the left of the current node available?
                {
                    currentNode.left = new Node(newValue);//If it is add the node to the left of the current node.
                }
                else 
                {
                    Add(newValue, currentNode.left);//If it isn't move to that node and try to add the newValue again at that position by calling the Add method in a recursive way.
                }
            }

            if (newValue > currentNode.value) //Is the newValue is bigger than the current node value?
            {
                if (currentNode.right == null) //Is the position to the right of the current node available?
                {
                    currentNode.right = new Node(newValue);//If it is add the node to the right of the current node.
                }
                else
                {
                    Add(newValue, currentNode.right);//If it isn't move to that node and try to add the newValue again at that position by calling the Add method in a recursive way.
                }
            }
        }

        public void Delete(int deleteValue) //Method delete nodes in the tree
        {
            if (root == null) //If the root is null then our tree is empty
            {
                Console.WriteLine("The tree is empty");
            }
            else
            {
                root = Delete(root, deleteValue); //Call the delete function and try to delete a Node that contains the integer that is passed as a parameter
            }
        }

        private Node Delete(Node currentNode, int deleteValue) 
        {

            if (deleteValue < currentNode.value) //If the delete value is smaller than the current node value
            {
                if (currentNode.left != null) //As long as the next node to the left of the current Node isn't empty, continue
                {
                    currentNode.left = Delete(currentNode.left, deleteValue); //Since we haven't found the node we want to delete we must move to the next node and try again. In this case we move to the left. 
                }
            }
            else if (deleteValue > currentNode.value) //If the delete value is smaller than the current node value
            {
                if (currentNode.right != null) //As long as the next node to the right of the current Node isn't empty, continue
                {
                    currentNode.right = Delete(currentNode.right, deleteValue); //Since we haven't found the node we want to delete we must move to the next node and try again. In this case we move to the right.
                }
            }
            else //We have found the Node we want to delete so we have to classify it into the 3 different cases to delete nodes in Binary Trees
            {
                if (currentNode.left == null && currentNode.right == null) //Case 1: Our node is a leaf and we just easily remove it from the tree
                {
                    return null;
                }
                else if (currentNode.left == null) // Case 2: Our node has another node to it's right.
                {
                    return currentNode.right;
                }
                else if (currentNode.right == null) // Case 2: Our node has another node to it's left.
                {
                    return currentNode.left;
                }
                else //Case 3: Our node has children nodes to it's left and right. The strategy is to find the Max value on the children on the left side and use that as our new Node.
                {
                    int temp = findMax(currentNode.left, currentNode.left.value); //Find the max value of the left children of our current node.
                    currentNode.value = temp; //Replace the erased Node value with the retrieved Max value.
                    Delete(currentNode.left, temp); //Now we need to delete the node that contains the retrieved max value.
                }
            }
            return currentNode; //return the current Node if it is a leaf value and it isn't the Node you want to delete.
        }

        private int findMax(Node currentNode, int max)  //Just checks all the values of the Nodes on the received sub tree and retrieves the Max Value.
        {
            if (currentNode.value > max) //If the current node value is bigger than the max variable value.
            {
                return currentNode.value; //then make that our new max variable value
            }

            if (currentNode.right != null) //If the node to the right isn't null
            {
                max = findMax(currentNode.right, max); //Move to the next node to the right of the current node and try to find a new max value.
            }

            return max; //return the new max value
        }

        public void Search(int queryValue) // Method to search for a desired Node in the tree.
        {
            if (root == null) //If the tree root is null the tree itself is empty.
            {
                Console.WriteLine("The tree is empty");
            }         
            else 
            {
                bool searchFlag = Search(root, queryValue, false); //Call the recursive Search method that returns a boolean. 
                if (searchFlag) //If the flag is true the search was succesful
                {
                    Console.WriteLine("Number {0} was found", queryValue);
                }
                else//Else the number wasn'y found in the tree.
                {
                    Console.WriteLine("Number {0} wasn't found", queryValue);
                }
            }
        }

        private bool Search(Node currentNode, int queryValue, bool flag)
        {
            if (queryValue < currentNode.value) //If the seach value is smaller than the current node value
            {
                if (currentNode.left != null) //As long as the next node to the left of the current Node isn't empty, continue
                {
                    flag = Search(currentNode.left, queryValue, flag); //Since we haven't found the node we are searching for we must move to the next node and try again. In this case we move to the left.
                }
            }
            else if (queryValue > currentNode.value) //If the seach value is bigger than the current node value
            {
                if (currentNode.right != null) //As long as the next node to the right of the current Node isn't empty, continue
                {
                    flag = Search(currentNode.right, queryValue, flag); //Since we haven't found the node we are searching for we must move to the next node and try again. In this case we move to the right.
                }   
            }
            else //We found the desired Node, return true to raise the flag.
            {
                return true; 
            }
            return flag;//We didnn't found the desired Node, return false to not raise the flag.
        }

        public void Print()
        {
            if (root == null) //If the tree root is null the tree itself is empty.
            {
                Console.WriteLine("This tree is empty");
            }
            else
            {
                string result = Print(root, string.Empty); //Call the recursive Print method that returns a string that contains all the nodes in our tree. 
                Console.WriteLine(result);
            }
        }

        private string Print(Node currentNode, string result) 
        {
            if (currentNode.left != null) //As long as the next node to the left of the current Node isn't empty, continue
            {
                result = Print(currentNode.left, result); //Move to the next node to the left of our current node.
            }

            result += currentNode.value.ToString() + " "; //Add the value of the current node to the string.

            if (currentNode.right != null) //As long as the next node to the right of the current Node isn't empty, continue
            {
                result = Print(currentNode.right, result); //Move to the next node to the right of our current node.
            }

            return result; //return the tring once the values of the current node and it's sub tree have been added.
        }

        public void printRoot() //This just prints the root node value, helps to prove the delete function.
        {
            if (root == null)
            {
                Console.WriteLine("Tree Root is empty");
            }
            else
            {
                Console.WriteLine("Tree Root: {0}", root.value);
            }
        }
    }
}
