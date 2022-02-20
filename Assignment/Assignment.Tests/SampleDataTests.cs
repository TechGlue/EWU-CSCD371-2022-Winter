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
    
    //maybe remove this test the idk if it's really worth since first and last can be right but the rest is broke.
    [TestMethod]
    public void Constructor_CollectionRead_AssertCSVProperlyReadEntries()
    {
        //Arrange
        SampleData initClass = new SampleData();
        string firstEntry = "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577";
        string lastEntry = "50,Claudell,Leathe,cleathe1d@columbia.edu,30262 Steensland Way,Newport News,VA,87930";

        //Assert
        Assert.AreEqual<string>(initClass.CsvRows.First(), firstEntry);
        Assert.AreEqual<string>(initClass.CsvRows.Last(), lastEntry);
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_ValidParamters_ReturnsProperSizeOfCollection()
    {
        //Arrange
        SampleData initClass = new SampleData();
        
        //Act
        IEnumerable<string> sortedQuery = initClass.GetUniqueSortedListOfStatesGivenCsvRows();
        
        //Assert
        Assert.AreEqual(27, sortedQuery.Count());
        Assert.AreNotEqual(50, sortedQuery.Count());
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_ValidParameters_ChecksIfCollectionIsSorted()
    {
        //TODO:No idea how we would check if a collection is sorted using only linq
        //TODO: Created this method as a place holder. 
        
        //Arrange
        SampleData initClass = new SampleData();
        bool isSorted = true;
        IEnumerable<string> sortedQuery = initClass.GetUniqueSortedListOfStatesGivenCsvRows();
        string prevString = "";
        var enumerable = sortedQuery.ToList();

        //Act
        foreach (string state in enumerable)
        {
            if (enumerable.First().Equals(state, StringComparison.Ordinal))
            {
                //do nothing
                prevString = state;
            }
            else
            {
                if (String.Compare(prevString, state, StringComparison.Ordinal) > 0)
                {
                    isSorted = false;
                }
                
            }
            if (isSorted == false)
                break;
        }

        //Assert
        Assert.IsTrue(isSorted);
    }

    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_WithCSV_ReturnsCommaSeperatedStatesList()
    {
        //Arrange
        SampleData initClass = new SampleData();
        string expectedString = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";
        string actualString = initClass.GetAggregateSortedListOfStatesUsingCsvRows();
        //Assert
        Assert.AreEqual(expectedString.Length, actualString.Length);
        Assert.AreEqual(expectedString, actualString);
    }
}