using PCRmq_Core.Entities.Icanhazdadjoke;
using PCRmq_Core.Repository.Icanhazdadjoke;

namespace PCRmq_Core.Service.Icanhazdadjoke
{
    public static class JokeService
    {

        public static async Task<DadJoke> GetRandomJokeAsync()
        {
            using JokeRepository jokeRepository = new();
            DadJoke joke = await jokeRepository.GetRandomJokeAsync();
            return joke;

        }
    }
}