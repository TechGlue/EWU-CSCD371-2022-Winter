using System;
using System.Net.Http;
namespace CanHazFunny
{
    public class JokeService:IJokeService, IJokesOut
    {
        private HttpClient HttpClient { get; } = new();
        public string GetJoke()
        {
            string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
            return joke;
        }
        public void PrintJoke(string? joke)
        {
            Console.WriteLine(joke);
        }
    }
}
