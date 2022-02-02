namespace CanHazFunny;

public class JokeService : IJokeService, IJokesOut
{
    private HttpClient HttpClient { get; } = new();
    public string GetJoke()
    {
        Uri uri = new("https://geek-jokes.sameerkumar.website/api");
        string joke = HttpClient.GetStringAsync(uri).Result;
        return joke;
    }
    public void PrintJoke(string? joke)
    {
        Console.WriteLine(joke);
    }
}

