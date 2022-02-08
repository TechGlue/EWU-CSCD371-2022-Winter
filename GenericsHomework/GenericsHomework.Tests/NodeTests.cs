namespace GenericsHomework.Tests;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void Constructor_ValidParameters_NodeIsNotNull()
    {
        //Arrange
        Node<int> node = new(42);
        //Assert
        Assert.IsNotNull(node);
    }
    
    //maybe find a better name that is shorter 
    [TestMethod]
    public void Constructor_ValidParameters_NodePointsToItselfOnCreation()
    {
        //Arrange
        Node<int> node = new(42);
        //Assert
        Assert.AreEqual(node, node.Next);
    }
    
    [TestMethod]
    [DataRow(42)]
    [DataRow(23)]
    public void Constructor_ValidParameters_NodeSucessfullyStoresValue(int value)
    {
        //Arrange
        Node<int> node = new(value);
        //Assert
        Assert.AreEqual(node.Value, value);
    }

}
