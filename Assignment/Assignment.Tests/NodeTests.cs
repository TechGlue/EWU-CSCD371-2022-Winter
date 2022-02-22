namespace Assignments.Tests;

[TestClass]
public class NodeTests
{
    //credit to tuesdays lecture 
    [TestMethod]
    public void Foreach_Iterate_Sucess()
    {
        Assignment.Node<int> head = new(1);
        head.Append(2);
        head.Append(3);

        bool insideIterator = false;
        // TODO: unused variable "item"
        foreach (Assignment.Node<int> item in head)
        {
            insideIterator = true;
        }

        Assert.IsTrue(insideIterator);
    }

}