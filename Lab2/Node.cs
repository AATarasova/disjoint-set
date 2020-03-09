namespace Lab2
{
    public class Node
    {
        private int _number;
        public Node parent;

        public int Number => _number;

        public Node(int number)
        {
            _number = number;
        }
        public bool Equals(int number)
        {
            return this._number == number;
        }
    }
}