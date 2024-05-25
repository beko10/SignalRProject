using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.WebUI.Dtos.SliderDtos;

namespace SignalR.WebUI.Controllers
{
    public class SliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44331/api/Slider");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
