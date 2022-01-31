using System;

namespace CanHazFunny;

public class Jester
{
    private IJokeService? _jokeService;
    private IJokesOut? _jokesOut;
    
    public Jester(IJokeService? jokeService, IJokesOut? jokesOut)
    {
        if (jokeService is null && jokesOut is null)
        {
            throw new ArgumentNullException();
        }

        _jokeService = jokeService;
        _jokesOut = jokesOut;
    }

    public void TellJoke()
    {
        string? joke = _jokeService?.GetJoke();

        while (joke != null && !joke.Contains("Chuck Norris"))
        {
            joke = _jokeService?.GetJoke();
        }
        
        _jokesOut?.PrintJoke(joke);
    }
}