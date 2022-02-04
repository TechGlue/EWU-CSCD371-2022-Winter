namespace GenericsHomework;
public class Node<TValue> where TValue : notnull
{
    public TValue Value { get; set; }
    public Node<TValue> Next { get; private set; }
    
    public Node(TValue value)
    {
        Value = value;
        Next = this;
    }

    public void Append(TValue value)
    {
        if (Exists(value))
        {
            throw new ArgumentException(message: "Value already exists in list");
        }

        Node<TValue> newNode = new(value);
        Node<TValue> cur = Next;

        while(cur.Next != this)
        {
          //increment
          cur = cur.Next;
        }

        cur.Next = newNode;
        newNode.Next = this;
    }

    public void Clear()
    {
        // TODO: does this work for the garbage collection note in the assignment?
        // removes all items from a list except the current node
        Next = this;
    }

    public bool Exists(TValue value)
    {
        //maybe not needed double check on testing
        //Checking if we can find the value in head.
        if(this.Value.Equals(value))
          return true;

        Node<TValue> head = this;
        Node<TValue> currentNode = Next;

        while(currentNode != head)
        {
            if(currentNode.Value.Equals(value))
            {
              return true;
            }
            currentNode = currentNode.Next;
        }

        return false;
    }

    public override string ToString()
    {
        //TODO: double check what's being returned here. 
        return Value.ToString();
    }
}
