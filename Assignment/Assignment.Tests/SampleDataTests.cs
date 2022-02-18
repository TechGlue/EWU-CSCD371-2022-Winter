using Assignment;

namespace Assignments.Tests;

[TestClass]
public class SampleDataTests
{
    [TestMethod]
    public void Constructor_CollectionRead_CSVRowCountMatch()
    {
        //Arrange
        SampleData initClass = new SampleData();
        //Assert
        Assert.AreEqual(initClass.CsvRows.Count(),50);
    }

    [TestMethod]
    public void Test()
    {
        //Arrange
        

        //Act

        //Assert
    }

    [TestMethod]
    public void CSVSorter()
    {
        //Arrange
        SampleData initClass = new SampleData();
        
        //Act
        IEnumerable<string> sortedQuery = initClass.GetUniqueSortedListOfStatesGivenCsvRows();
        
        //Assert
        Assert.IsTrue(true);
    }
    
    
    
}