using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.WebUI.Dtos.CategoryDtos;
using System.Text;
/*

Json serileştirme(Serialize):Bir objeyi json metin yapısına dönüştürme işlemidir

Json desirilize(Deserialize):json metnini objeye dönüştürme işlemidir
 
 
 */
namespace SignalR.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
		public CategoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
        {
            //Api ile iletişimi sağlayacak client oluşturuldu 
            var client = _httpClientFactory.CreateClient();
            //istek yapılacak api'nin cevap alındı
            var responseMessage = await client.GetAsync("https://localhost:44331/api/Category");
            if(responseMessage.IsSuccessStatusCode)
            {
                //gelen cevabın içerisindeki içerik string olarak okundu  
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            createCategoryDto.Status = true;

            //client oluşturuldu 
            var client = _httpClientFactory.CreateClient();
            //jsondata se
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:44331/api/Category", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44331/api/Category/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();  
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            //api ile iletişimi geçecek client oluşturuldu 
            var client = _httpClientFactory.CreateClient();
            //güncellenecek kategori id adresine göre api deki get metodu ile getirildi
            var responseMessage = await client.GetAsync($"https://localhost:44331/api/Category/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                //api'nin cevabındaki içerik alındı
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }

            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:44331/api/Category",content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
