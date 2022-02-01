using System;
namespace CanHazFunny;
public class Jester
{
    private IJokeService? _jokeService;
    private IJokesOut? _jokesOut;
    
    public Jester(IJokeService? jokeService, IJokesOut? jokesOut)
    {
        _jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
        _jokesOut = jokesOut ?? throw new ArgumentNullException(nameof(jokesOut)); 
    }
    public void TellJoke()
    {
        string? joke = _jokeService?.GetJoke();

        while (joke != null && joke.Contains("Chuck Norris", StringComparison.OrdinalIgnoreCase))
        {
            joke = _jokeService?.GetJoke();
        }
        
        _jokesOut?.PrintJoke(joke);
    }
}