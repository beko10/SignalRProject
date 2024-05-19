using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.DtoLayer.ProductDtos;
using SignalR.WebUI.Dtos.ProductDtos;
using System.Text;
using SignalR.WebUI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace SignalR.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            // HttpClientFactory'den yeni bir HttpClient örneği oluştur.
            var client = _httpClientFactory.CreateClient();

            // API'den ürünlerin listesini asenkron olarak al.
            var responseMessage = await client.GetAsync("https://localhost:44331/api/Product/ProductWitCategory");

            // Eğer HTTP isteği başarılıysa (200 OK)
            if (responseMessage.IsSuccessStatusCode)
            {
                // HTTP yanıt içeriğini bir string olarak oku.
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                // JSON verisini ResultProductDto tipinde bir liste olarak deserileştir.
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);

                // Deserileştirilmiş veriyi View'e gönder.
                return View(values);
            }

            // Eğer HTTP isteği başarısızsa, boş bir View döndür.
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Createproduct()
        {
            // HttpClientFactory kullanarak yeni bir HTTP istemcisi oluştur
            var client = _httpClientFactory.CreateClient();

            // 'Category' API'sine GET isteği gönder ve yanıtı al
            var responseMessage = await client.GetAsync("https://localhost:44331/api/Category");

            // Yanıttan gelen içeriği oku ve bir string olarak al
            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            // JSON verisini ResultCategoryDto tipinde bir liste olarak deserialize et
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            // ResultCategoryDto listesini SelectListItem listesine dönüştür
            // Bu, dropdown menüde kullanılmak üzere kategori seçeneklerini hazırlar
            var categorySelectList = categories.Select(c => new SelectListItem
            {
                Text = c.CategoryName, // SelectListItem'in görünen metni için kategori adını kullan
                Value = c.CategoryID.ToString() // SelectListItem'in değeri için kategori ID'sini kullan
            }).ToList();

            // Hazırlanan SelectListItem listesini ViewBag ile View'a geçir
            // Bu sayede View içerisinde dropdown menü olarak kullanılabilir
            ViewBag.categoriesSelect = categorySelectList;

            // Hazırlanan View'ı döndür
            return View();
        }



        [HttpPost]
        // 'CreateProduct' POST isteği için asenkron action metodu. Formdan gelen verilerle yeni bir ürün oluşturur.
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            createProductDto.ProductStatus = true;
            // HttpClientFactory'den yeni bir HttpClient örneği oluştur.
            var client = _httpClientFactory.CreateClient();

            // Gelen 'createProductDto' nesnesini JSON formatına serileştir.
            var jsonData = JsonConvert.SerializeObject(createProductDto);

            // Serileştirilmiş JSON verisini içeren bir StringContent nesnesi oluştur.
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Serileştirilmiş veriyi içeren POST isteğini API'ye gönder.
            var responseMessage = await client.PostAsync("https://localhost:44331/api/Product", content);

            // Eğer HTTP isteği başarılıysa (200 OK)
            if (responseMessage.IsSuccessStatusCode)
            {
                // Kullanıcıyı 'Index' action metoduna yönlendir.
                return RedirectToAction("Index");
            }

            // Eğer HTTP isteği başarısızsa, aynı View'ı tekrar göster.
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            // HttpClientFactory'den yeni bir HttpClient örneği oluştur.
            var client = _httpClientFactory.CreateClient();

            // Belirtilen 'id' ile API üzerinden DELETE isteği gönder.
            var responseMessage = await client.DeleteAsync($"https://localhost:44331/api/Product/{id}");

            // Eğer HTTP isteği başarılıysa (200 OK)
            if (responseMessage.IsSuccessStatusCode)
            {
                // Kullanıcıyı 'Index' action metoduna yönlendir.
                return RedirectToAction("Index");
            }

            // Eğer HTTP isteği başarısızsa, aynı View'ı tekrar göster.
            return View();
        }

        [HttpGet]
        // 'UpdateProduct' GET isteği için asenkron action metodu. Belirtilen ID'ye sahip ürünü güncellemek için formu getirir.
        public async Task<IActionResult> UpdateProduct(int id)
        {

            // HttpClientFactory kullanarak yeni bir HTTP istemcisi oluştur
            var categoryclient = _httpClientFactory.CreateClient();

            // 'Category' API'sine GET isteği gönder ve yanıtı al
            var responseMessageCategory = await categoryclient.GetAsync("https://localhost:44331/api/Category");

            // Yanıttan gelen içeriği oku ve bir string olarak al
            var jsonDataCategory = await responseMessageCategory.Content.ReadAsStringAsync();

            // JSON verisini ResultCategoryDto tipinde bir liste olarak deserialize et
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonDataCategory);

            // ResultCategoryDto listesini SelectListItem listesine dönüştür
            // Bu, dropdown menüde kullanılmak üzere kategori seçeneklerini hazırlar
            var categorySelectList = categories.Select(c => new SelectListItem
            {
                Text = c.CategoryName, // SelectListItem'in görünen metni için kategori adını kullan
                Value = c.CategoryID.ToString() // SelectListItem'in değeri için kategori ID'sini kullan
            }).ToList();

            // Hazırlanan SelectListItem listesini ViewBag ile View'a geçir
            // Bu sayede View içerisinde dropdown menü olarak kullanılabilir
            ViewBag.categoriesSelect = categorySelectList;


            // HttpClientFactory'den yeni bir HttpClient örneği oluştur.
            var client = _httpClientFactory.CreateClient();

            // Belirtilen ID ile API üzerinden ürün bilgilerini asenkron olarak al.
            var responseMessage = await client.GetAsync($"https://localhost:44331/api/Product/{id}");

            // Eğer HTTP isteği başarılıysa (200 OK)
            if (responseMessage.IsSuccessStatusCode)
            {
                // HTTP yanıt içeriğini bir string olarak oku.
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                // JSON verisini 'UpdateProductDto' tipinde bir nesneye deserileştir.
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);

                // Deserileştirilmiş veriyi View'e gönder.
                return View(values);
            }

            // Eğer HTTP isteği başarısızsa, boş bir View döndür.
            return View();
        }

        [HttpPost]
        // 'UpdateProduct' POST isteği için asenkron action metodu. Formdan gelen verilerle ürünü günceller.
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            updateProductDto.ProductStatus=true;

            // HttpClientFactory'den yeni bir HttpClient örneği oluştur.
            var client = _httpClientFactory.CreateClient();

            // Gelen 'updateProductDto' nesnesini JSON formatına serileştir.
            var jsonData = JsonConvert.SerializeObject(updateProductDto);

            // Serileştirilmiş JSON verisini içeren bir StringContent nesnesi oluştur.
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Serileştirilmiş veriyi içeren PUT isteğini API'ye gönder.
            var responseMessage = await client.PutAsync("https://localhost:44331/api/Product", content);

            // Eğer HTTP isteği başarılıysa (200 OK)
            if (responseMessage.IsSuccessStatusCode)
            {
                // Kullanıcıyı 'Index' action metoduna yönlendir.
                return RedirectToAction("Index");
            }

            // Eğer HTTP isteği başarısızsa, aynı View'ı tekrar göster.
            return View(updateProductDto);
        }


    }
}
