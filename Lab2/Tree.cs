namespace Lab2
{
    public class Tree
    {
        public readonly Node root;

        public Tree(Node node)
        {
            this.root = node;
            this.root.parent = null;
        }
        
        public Tree (int number) : this(new Node(number)){}
        public static Node Find(Node node)
        {
            if (node.parent == null)
                return node;
                
            var newParent = Find(node.parent);
            node.parent = newParent;
                
            return newParent;
        }
        
        public void Union(Tree component)
        {
            this.root.parent = component.root;
        }
    }
}