namespace GenericsHomework.Tests;

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
        headNode.AppendLast(22);
        headNode.AppendLast(21);
        headNode.AppendLast(20);
        headNode.AppendLast(19);
        headNode.AppendLast(18);

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
        headNode.AppendLast(22);
        headNode.AppendLast(21);
        headNode.AppendLast(20);
        headNode.AppendLast(19);
        headNode.AppendLast(18);

        //Assert
        Assert.IsFalse(headNode.Exists(999));
        Assert.IsFalse(headNode.Exists(888));
        Assert.IsFalse(headNode.Exists(777));
        Assert.IsFalse(headNode.Exists(666));
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
    [ExpectedException(typeof(ArgumentException))]
    public void AppendLast_DuplicateNodeValues_ThrowsException()
    {
        //Arrange
        Node<int> headNode = new(42);

        //Act
        headNode.AppendLast(22);
        headNode.AppendLast(21);
        headNode.AppendLast(22);
    }


    [TestMethod]
    public void AppendLast_ValidParameters_SuccessfullyInsertsNode()
    {
        //Arrange
        Node<int> headNode = new(42);

        //Act
        headNode.AppendLast(24);
        headNode.AppendLast(43);

        //Assert
        Assert.AreEqual(24, headNode.Next.Value);
        Assert.AreEqual(43, headNode.Next.Next.Value);
        //Check if last node will point back to head.
        Assert.AreEqual(42, headNode.Next.Next.Next.Value);
    }

    [TestMethod]
    public void ToString_ValuesAsAString_SuccessfullyReturnsMatching()
    {
        //Arrange
        Node<string> testNode = new("42");

        //Assert
        Assert.AreEqual("42", testNode.ToString());
    }

    [TestMethod]
    public void ToString_MultipleValidValues_SuccessfullyReturnsMatching()
    {
        //Arrange 
        Node<int> testNode = new(42);

        //Act
        testNode.AppendLast(24);
        testNode.AppendLast(33);

        //Assert
        Assert.AreEqual("42 -> 24 -> 33", testNode.ToString());
    }


    [TestMethod]
    public void Clear_WithSingleNode_ConfirmClearedWithExists()
    {
        //Arrange
        Node<int> testNode = new(42);

        //Act
        testNode.Clear();

        //Assert
        Assert.IsTrue(testNode.Exists(42));
    }

    [TestMethod]
    public void Clear_WithMultipleNode_ConfirmClearedWithExists()
    {
        //Arrange
        Node<int> testNode = new(42);
        testNode.AppendLast(22);
        testNode.AppendLast(21);
        testNode.AppendLast(20);
        testNode.AppendLast(19);
        testNode.AppendLast(18);
        //Act
        testNode.Clear();

        //Assert
        Assert.IsTrue(testNode.Exists(42));
        Assert.IsFalse(testNode.Exists(22));
        Assert.IsFalse(testNode.Exists(21));
        Assert.IsFalse(testNode.Exists(20));
        Assert.IsFalse(testNode.Exists(19));
        Assert.IsFalse(testNode.Exists(18));
    }
}
