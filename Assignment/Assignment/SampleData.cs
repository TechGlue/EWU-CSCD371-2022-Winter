﻿using System.Net;

namespace Assignment;
public class SampleData : ISampleData
{
    // 1.
    public IEnumerable<string> CsvRows => File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "People.csv")
        .Skip(1);

    // 2.decide whether we should make this nullable while we may not need to 
    //Since we know that the file will not make it null idkdksk double check. 
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        return CsvRows
            .Select(x => x.Split(',')[6])
            .Distinct()
            .OrderBy(x => x);
    }

    // 3.
    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {
        IEnumerable<string> states = GetUniqueSortedListOfStatesGivenCsvRows();
        return string.Join(", ", states);
    }

    // 4.
    public IEnumerable<IPerson> People => CsvRows
        .Select(x => x.Split(","))
        .OrderBy(x => x[6]).ThenBy(x => x[5]).ThenBy(x => x[7])
        .Select(person => new Person(person[1], person[2], new Address(person[4], person[5], person[6], person[7]), person[3]));

    // 5.
    public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter) => People
        .Where(x => filter(x.EmailAddress))
        .Select(x => (x.FirstName, x.LastName));

    // 6.
    public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people) => people
        .Select(x => x.Address.State)
        .Distinct()
        .Aggregate((states, newState) => states + ", " + newState);
}
