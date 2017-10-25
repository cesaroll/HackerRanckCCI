namespace Trees
{

  class Node
  {
    Node left, right;
    int data;

    public Node(int data)
    {
        this.data = data;
    }

    public void insert(int value)
    {
        if(value <= data)
        {
            if(left == null)
                left = new Node(value);
            else
                left.insert(value);
        }
        else
        {
            if(right == null)
                right = new Node(value);
            else
                right.insert(value);
        }
    }

    public bool contains(int value)
    {
        if(value == data)
            return true;
        else if(value < data)
        {
            if(left == null)
                return false;
            else
                return left.contains(value);
        }
        else
        {
            if(right == null)
                return false;
            else
                return right.contains(value);

        }

    }

    public string  printInOrder()
    {
        string str = "";

        if(left != null)
            str = left.printInOrder();
        
        //Console.Write(data + " ");
        str = str + data + " ";

        if(right != null)
            str = str + right.printInOrder(); 

        return str;

    }

    public string printPreOrder()
    {
        string str = data + " ";

        if(left != null)
            str = str + left.printPreOrder();

        if(right != null)
            str = str + right.printPreOrder();

        return str;
    }

    public string printPostOrder()
    {
        string str = "";
        
        if(left != null)
            str = left.printPostOrder();

        if(right != null)
            str = str + right.printPostOrder();

        str = str + data + " ";
        return str;        

    }

  }

}
