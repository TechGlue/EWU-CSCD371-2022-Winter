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

    private void RemoveCurrentNodeReference(TValue value)
    {
        //Adapted from https://www.alphacodingskills.com/cs/ds/cs-delete-all-nodes-of-the-circular-singly-linked-list.php
        Node<TValue> nextNode = Next;
        Node<TValue> lastNode = this;
        while (nextNode != this)
        {
            if (nextNode.Value.Equals(value))
            {
                lastNode.Next = nextNode.Next;
                break;
            }
            lastNode = nextNode;
            nextNode = nextNode.Next;
        }
    }
    public void Clear()
    {
        // Removing all references to and from this node will have the rest picked up by garbage collectionor added to the finalization queue
        // Per the book:
        // "the garbage collector determines what to clean up based on whether any references remain"
        // "maintaining a reference to an object will delay the garbage collector from reusing the memory consumed by the object"
        // Therefore, only doing "Next = this;" for the clear method won't suffice
        Node<TValue> nextNode = Next;
        while (nextNode != this)
        {
            RemoveCurrentNodeReference(nextNode.Value);
            if (nextNode.Next.Equals(this))
            {
                break;
            }
            nextNode = nextNode.Next;
        }
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
