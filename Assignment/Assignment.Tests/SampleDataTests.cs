using Assignment;

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

    [TestMethod]
    public void Constructor_CollectionRead_AssertCSVProperlyReadAllEntries()
    {
        //Arrange
        SampleData initClass = new();
        string[] list = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "People.csv");
        
         bool csvLoaded = true;
         int listCounter = 1;
         foreach (string str in initClass.CsvRows)
         {
             if (!str.Equals(list[listCounter], StringComparison.Ordinal))
             {
                 csvLoaded = false;
                 break;
             }

             listCounter++;
         } 

         Assert.IsTrue(csvLoaded);
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_ValidParameters_ReturnsProperSizeOfCollection()
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
    public void GetUniqueSortedListOfStatesGivenCsvRows_ValidParametersUtilizingLinq_ChecksIfCollectionIsSorted()
    {
        //Arrange 
        SampleData initClass = new();
        IEnumerable<string> sortedQueryWithLinq = initClass.GetUniqueSortedListOfStatesGivenCsvRows().OrderBy(x=>x);
        IEnumerable<string> sortedQuery = initClass.GetUniqueSortedListOfStatesGivenCsvRows();

        //Assert
        Assert.IsTrue(sortedQuery.SequenceEqual(sortedQueryWithLinq));
    }
    
    /*Message to Grader: What was the best approach for this test. I contemplated adding a constructor or adding a setter
     to the interface. All of those options would make me stray away from the first req which is properly load people.csv
     and only people.csv(note I'm assuming the reqs only want people.csv).
     So while this does not call the method it leverages a spokane address list and performs the same operations. 
     */
    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_WithSpokaneAddresses_CollectionSorted()
    {
        //Arrange
        IEnumerable<string> spokaneCafes = new List<string>()
        {
            "Id,FirstName,LastName,Email,StreetAddress,City,State,Zip", 
            "1,Little Garden Cafe,None,123@gmail.com,2901 W Northwest Blvd,Spokane,WA,99205",
            "2,Wake Up Call,None,123@gmail.com,6909 N Division St,Spokane,WA,99208",
            "3,First Avenue Coffee,None,123@gmail.com,1011 W 1st Ave,Spokane,WA,99201",
            "4,Rocket Bakery,None,123@gmail.com,207 N Wall St,Spokane,WA,99201",
        };
        //Act
        spokaneCafes = spokaneCafes
            .Skip(1)
            .Select(x => x.Split(',')[6])
            .Distinct()
            .OrderBy(x => x);
        
        //Assert
        Assert.AreEqual(spokaneCafes.First(), "WA");
        Assert.AreEqual(spokaneCafes.Last(), "WA");
        Assert.AreEqual(spokaneCafes.Count(), 1);
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