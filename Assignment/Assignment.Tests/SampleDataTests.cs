using Assignment;
using System.Linq;

namespace Assignments.Tests;

[TestClass]
public class SampleDataTests
{
    [TestMethod]
    public void Constructor_CollectionRead_CSVRowCountMatch()
    {
        //Arrange
        SampleData initClass = new();
        //Assert
        Assert.AreEqual(initClass.CsvRows.Count(), 50);
    }

    //maybe remove this test the idk if it's really worth since first and last can be right but the rest is broke.
    [TestMethod]
    public void Constructor_CollectionRead_AssertCSVProperlyReadEntries()
    {
        //Arrange
        SampleData initClass = new();
        string firstEntry = "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577";
        string lastEntry = "50,Claudell,Leathe,cleathe1d@columbia.edu,30262 Steensland Way,Newport News,VA,87930";

        //Assert
        Assert.AreEqual(initClass.CsvRows.First(), firstEntry);
        Assert.AreEqual(initClass.CsvRows.Last(), lastEntry);
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_ValidParamters_ReturnsProperSizeOfCollection()
    {
        //Arrange
        SampleData initClass = new();

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
        SampleData initClass = new();
        bool isSorted = true;
        IEnumerable<string> sortedQuery = initClass.GetUniqueSortedListOfStatesGivenCsvRows();
        string prevString = "";
        List<string>? enumerable = sortedQuery.ToList();

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
                if (string.Compare(prevString, state, StringComparison.Ordinal) > 0)
                {
                    isSorted = false;
                }
            }
            if (isSorted == false)
            {
                break;
            }
        }

        //Assert
        Assert.IsTrue(isSorted);
    }

    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_WithCSV_ReturnsCommaSeperatedStatesList()
    {
        //Arrange
        SampleData initClass = new();
        string expectedString = "AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV";
        string actualString = initClass.GetAggregateSortedListOfStatesUsingCsvRows();
        //Assert
        Assert.AreEqual(expectedString.Length, actualString.Length);
        Assert.AreEqual(expectedString, actualString);
    }

    [TestMethod]
    public void People_Ordered_Matches()
    {
        //Arrange
        SampleData initClass = new();

        //Act
        IEnumerable<IPerson> people = initClass.People;

        //Assert
        Assert.AreEqual(50, people.Count());

        Assert.AreEqual("Arthur Myles", $"{people.First().FirstName} {people.First().LastName}");
        Assert.AreEqual("Amelia Toal", $"{people.Last().FirstName} {people.Last().LastName}");
    }

    [TestMethod]
    public void FilterByEmailAddress_GivenExactEmail_MatchesName()
    {
        //Arrange
        SampleData initClass = new();
        Predicate<string> filter = (string email) => email == "pjenyns0@state.gov";

        //Act
        IEnumerable<(string FirstName, string LastName)> filteredData = initClass.FilterByEmailAddress(filter);


        //Assert
        Assert.AreEqual(1, filteredData.Count());
        Assert.AreEqual<(string FirstName, string LastName)>(("Priscilla", "Jenyns"), filteredData.First());
    }

    [TestMethod]
    public void FilterByEmailAddress_GivenContains_ReturnsManyMatching()
    {
        //Arrange
        SampleData initClass = new();
        Predicate<string> filter = (string email) => email.Contains(".gov");

        //Act
        IEnumerable<(string FirstName, string LastName)> filteredData = initClass.FilterByEmailAddress(filter);


        //Assert
        Assert.AreEqual(5, filteredData.Count());
        Assert.AreEqual<(string FirstName, string LastName)>(("Arthur", "Myles"), filteredData.First());
        Assert.AreEqual<(string FirstName, string LastName)>(("Amelia", "Toal"), filteredData.Last());
    }

    
    [TestMethod]
    public void GetAggregateListOfStatesGivenPeopleCollection_GivenPeople_ReturnsListOfStates()
    {
        //Arrange
        SampleData initClass = new();

        //Act
        IEnumerable<IPerson> people = initClass.People;
        string list = initClass.GetAggregateListOfStatesGivenPeopleCollection(people);

        //Assert
        Assert.AreEqual("AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV", list);
    }

    [TestMethod]
    public void GetAggregateListOfStatesGivenPeopleCollection_GivenPeopleAndSortedListOfStates_ReturnsListOfStates()
    {
        //Arrange
        SampleData initClass = new();

        //Act
        IEnumerable<IPerson> people = initClass.People;
        string list = initClass.GetAggregateListOfStatesGivenPeopleCollection(people);
        string actualString = initClass.GetAggregateSortedListOfStatesUsingCsvRows();
        
        //Assert
        Assert.AreEqual(actualString, list);
        Assert.AreEqual(actualString.Length, list.Length);
    }
}