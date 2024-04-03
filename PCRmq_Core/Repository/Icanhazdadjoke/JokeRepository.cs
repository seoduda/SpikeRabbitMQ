using PCRmq_Core.Entities.Icanhazdadjoke;
using PCRmq_Core.Entities.Solucx;
using RestSharp;
using System.Text.Json;

namespace PCRmq_Core.Repository.Icanhazdadjoke
{
    public class JokeRepository : IDisposable
    {
        internal async Task<DadJoke> GetRandomJokeAsync()
        {
            var options = new RestClientOptions("https://icanhazdadjoke.com")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/", Method.Get);
            request.AddHeader("Accept", "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content;
                return JsonSerializer.Deserialize<DadJoke>(json);
            }
        
            return null;
            
        }

        void IDisposable.Dispose()
        {
            
        }
    }
}