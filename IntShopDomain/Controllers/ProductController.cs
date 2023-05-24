using IntShopDomain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;



namespace Domain.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/Domain/Product")]
    public class ClientsController : ControllerBase
    {
        private readonly string? _dalUrl;
        private readonly HttpClient _client;

        public ClientsController(IConfiguration conf)
        {
            _dalUrl = conf.GetValue<string>("DalUrl");
            _client = new HttpClient();
        }

        [HttpGet]
        public async Task<ActionResult<Product[]>> GetClients()
        {
            var response = await _client.GetAsync($"{_dalUrl}/Client");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Product[]>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? Array.Empty<Product>();
        }
    }
}
