namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        //Figure out the relative path for now manually change it
        public IEnumerable<string> CsvRows => File.ReadAllLines("/Users/luis/EWU-CSCD371-2022-Winter/Assignment/Assignment/People.csv")
            .Skip(1);
        

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            throw new NotImplementedException();
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            throw new NotImplementedException();
        }

        // 4.
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            throw new NotImplementedException();
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {
            throw new NotImplementedException();
        }
    }
}
