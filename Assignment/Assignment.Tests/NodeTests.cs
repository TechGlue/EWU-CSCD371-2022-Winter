using Assignment;

namespace Assignments.Tests;

[TestClass]
public class NodeTests
{
    
    [TestMethod]
    public void Constructor_ValidParameters_NodeIsNotNull()
    {
        //Arrange
        Node<int> headNode = new(42);
        //Assert
        Assert.IsNotNull(headNode);
    }

    [TestMethod]
    public void Constructor_ValidParameters_NodePointsToItselfOnCreation()
    {
        //Arrange
        Node<int> headNode = new(42);
        //Assert
        Assert.AreEqual(headNode, headNode.Next);
    }

    [TestMethod]
    [DataRow(42)]
    [DataRow(23)]
    public void Constructor_ValidParameters_NodeSuccessfullyStoresValue(int value)
    {
        //Arrange
        Node<int> headNode = new(value);
        //Assert
        Assert.AreEqual(headNode.Value, value);
    }

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
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Append_DuplicateNodeValues_ThrowsException()
    {
        //Arrange
        Node<int> headNode = new(42);

        //Assert
        headNode.Append(22);
        headNode.Append(21);
        headNode.Append(22);
    }

    [TestMethod]
    public void Append_ValidParameters_SuccessfullyInsertsNodeKeepsOrder()
    {
        //Arrange
        Node<int> headNode = new(42);

        //Act
        headNode.Append(22);
        headNode.Append(21);
        
        //Assert
        Assert.AreEqual(22, headNode.Next.Next.Value);
        Assert.AreEqual(21, headNode.Next.Value);
    }

    [TestMethod]
    public void Append_ValidParameters_LastNodePointsToHeadNode()
    {
        //Arrange
        Node<int> headNode = new(42);

        //Act
        headNode.Append(22);
        headNode.Append(21);

        //Assert
        Assert.AreEqual(headNode, headNode.Next.Next.Next);
        Assert.AreEqual(22, headNode.Next.Next.Value);
    }
    
    [TestMethod]
    public void Exists_ValidParameters_ChecksHeadReturnsTrue()
    {
        //Arrange
        Node<int> headNode = new(42);
        //Assert
        Assert.IsTrue(headNode.Exists(42));
    }

    [TestMethod]
    public void Exists_ValidParameters_ReturnsTrueAllValuesExists()
    {
        //Arrange
        Node<int> headNode = new(42);

        //Act
        headNode.Append(22);
        headNode.Append(21);
        headNode.Append(20);
        headNode.Append(19);
        headNode.Append(18);

        //Assert
        Assert.IsTrue(headNode.Exists(19));
        Assert.IsTrue(headNode.Exists(18));
        Assert.IsTrue(headNode.Exists(21));
        Assert.IsTrue(headNode.Exists(22));
        Assert.IsTrue(headNode.Exists(20));
    }

    [TestMethod]
    public void Exists_ValidParameters_ReturnsFalseValuesDoNotExists()
    {
        //Arrange
        Node<int> headNode = new(42);

        //Act
        headNode.Append(22);
        headNode.Append(21);
        headNode.Append(20);
        headNode.Append(19);
        headNode.Append(18);

        //Assert
        Assert.IsFalse(headNode.Exists(999));
        Assert.IsFalse(headNode.Exists(888));
        Assert.IsFalse(headNode.Exists(777));
        Assert.IsFalse(headNode.Exists(666));
    }

}