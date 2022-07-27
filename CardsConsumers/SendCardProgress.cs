using CardsManagerLib.Models.Data.Dtos;
using System.Text;
using System.Text.Json;

namespace CardsConsumers
{
    public class SendCardProgress
    {
        private HttpClient _client = new HttpClient();
        string uriProgress = "https://localhost:7144/";
        public async void Send(CreateCardDto card)
        {
            var content = new StringContent(JsonSerializer.Serialize(card), Encoding.UTF8, "application/json") ;
            await _client.PostAsync(uriProgress, content);
        }
    }
}
