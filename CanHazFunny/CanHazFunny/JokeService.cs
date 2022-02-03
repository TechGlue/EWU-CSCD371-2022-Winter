namespace CanHazFunny;

public class JokeService : IJokeService, IJokesOut
{
    private HttpClient HttpClient { get; } = new();
    public string GetJoke()
    {
        //extra credit
        Uri uri = new("https://geek-jokes.sameerkumar.website/api?format=json");
        string joke = HttpClient.GetStringAsync(uri).Result;
        joke = System.Text.Json.JsonDocument.Parse(joke).RootElement.GetProperty("joke").ToString();
        return joke;
    }
    public void PrintJoke(string? joke)
    {
        Console.WriteLine(joke);
    }
}

