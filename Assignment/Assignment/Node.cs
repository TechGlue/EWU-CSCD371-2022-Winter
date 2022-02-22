using System.Collections;

namespace Assignment;
public class Node<TValue> : IEnumerable<Node<TValue>> where TValue : notnull
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
        newNode.Next = Next;
        Next = newNode;
    }

    public bool Exists(TValue value)
    {
        if (Value.Equals(value))
        {
            return true;
        }

        Node<TValue> head = this;
        Node<TValue> currentNode = Next;

        while (currentNode != head)
        {
            if (currentNode.Value.Equals(value))
            {
                return true;
            }
            currentNode = currentNode.Next;
        }

        return false;
    }

    public IEnumerator<Node<TValue>> GetEnumerator()
    {
        Node<TValue> currentNode = this;
        do
        {
            yield return currentNode;
            currentNode = currentNode.Next;
        }
        while (currentNode != this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
        //return GetEnumerator();
    }
}