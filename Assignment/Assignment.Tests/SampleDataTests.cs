using Assignment;

namespace Assignments.Tests;

[TestClass]
public class SampleDataTests
{
    [TestMethod]
    public void Constructor_NoParams_CSVFileReadRows()
    {
        //Arrange
        SampleData initClass = new SampleData();
        //Assert
        Assert.AreEqual(initClass.CsvRows.Count(),50);
    }
    
    
    
}