using System;

namespace BinaryTree
{
    class Program
    {

        public static Tree Oak = new Tree();
        static void Main(string[] args)
        {
            //First node to be added to the Tree/Oak become the root//
            Oak.Add(5);
            Oak.Add(3);
            Oak.Add(2);
            Oak.Add(4);
            Oak.Add(4);
            Oak.Add(1);
            Oak.Add(7);
            Oak.Add(8);
            Oak.Add(9);
            Oak.Print();
            Oak.printRoot();
            Oak.Search(9);
            Oak.Delete(5);

            //After deleting root 5//
            Oak.Add(500);
            Oak.Delete(-100);
            Oak.Print();
            Oak.printRoot();
            Oak.Search(5);
            Oak.Search(500);
        }
    }
}
