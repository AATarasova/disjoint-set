using System;
using System.Linq;

namespace Lab2
{
    public class DisjointSet
    {
        private Node[] nodes;
        private Tree[] setSystem;
        private int[][] unionOrder;
        private int _nodeNumber;

        public DisjointSet(int[][] inputData)
        {
            _nodeNumber = inputData[0][0];
            setSystem = new Tree[_nodeNumber];
            nodes = new Node[_nodeNumber];
            unionOrder = new int[_nodeNumber - 1][];
            for (var i = 0; i < _nodeNumber; i++)
            {
                nodes[i]    = new Node(i);
                setSystem[i] = new Tree(nodes[i]);
            }
            for (var i = 0; i < _nodeNumber - 1; i++){ 
                unionOrder[i] = inputData[i + 1];
            }
        }

        public static int[][] InputDataFormatted()
        {
            int[][] formatted;
            var read = Console.ReadLine();
            var splittedInput = read.Split(' ');
            formatted = new int[int.Parse(splittedInput[0])][];
            formatted[0] = new int[]{int.Parse(splittedInput[0])};
            
            if (splittedInput.Length > 1)
            {
                for (var i = 1; i < formatted[0][0] * 2 - 1; i++)
                {
                    if (i % 2 == 0)
                    {
                        formatted[i / 2][1] = int.Parse(splittedInput[i]);
                    }
                    else
                    {
                        formatted[i / 2 + 1] = new int[2];
                        formatted[i / 2 + 1][0] = int.Parse(splittedInput[i]);
                    }
                }
            }
            else
            {
                for (var i = 1; i < formatted[0][0]; i++)
                {
                    var splittedInputString = Console.ReadLine().Split(' ');
                    formatted[i] = new int[]{int.Parse(splittedInputString[0]), int.Parse(splittedInputString[1])};
                }
            }
            
            return formatted;
        }

        private void UnionTwoTrees(int orderIndex)
        {
            var firstTreeNum  = Tree.Find(nodes[unionOrder[orderIndex][0]]).Number;
            var secondTreeNum = Tree.Find(nodes[unionOrder[orderIndex][1]]).Number;
            setSystem[secondTreeNum].Union(setSystem[firstTreeNum]);
            setSystem[secondTreeNum] = null;
        }

        public void Realisation()
        {
            for (var i = 0; i < _nodeNumber - 1; i++)
            {
                UnionTwoTrees(i);
                
                Console.WriteLine((Tree.Find(nodes[0]) == Tree.Find(nodes[_nodeNumber-1]) ? "YES" : "NO"));
            }
        }
        
    }
}