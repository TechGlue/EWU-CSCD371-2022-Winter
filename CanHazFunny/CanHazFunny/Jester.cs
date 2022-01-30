using System;

namespace CanHazFunny;

public class Jester
{
    public Jester(IJokeService? jokeService, IJokesOut? jokesOut)
    {
        if (jokeService is null && jokesOut is null)
        {
            throw new ArgumentNullException();
        }
    }

    public void TellJoke()
    {
        JokeService jokeService = new JokeService();
        string joke = jokeService.GetJoke();

        while (!joke.Contains("Chuck Norris"))
        {
            joke = jokeService.GetJoke();
        }
        
        jokeService.PrintJoke(joke);
    }
}