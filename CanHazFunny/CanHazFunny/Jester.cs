namespace CanHazFunny;
public class Jester
{
    private IJokeService? _JokeService;
    private IJokesOut? _JokesOut;

    public Jester(IJokeService? jokeService, IJokesOut? jokesOut)
    {
        _JokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
        _JokesOut = jokesOut ?? throw new ArgumentNullException(nameof(jokesOut));
    }
    public void TellJoke()
    {
        string? joke = _JokeService?.GetJoke();

        while (joke != null && joke.Contains("Chuck Norris", StringComparison.OrdinalIgnoreCase))
        {
            joke = _JokeService?.GetJoke();
        }

        _JokesOut?.PrintJoke(joke);
    }
}