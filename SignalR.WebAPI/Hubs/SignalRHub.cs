using Microsoft.AspNetCore.SignalR;  // SignalR ile ilgili sınıfları ve arayüzleri içerir.
using SignalR.BusinessLayer.Abstract;

namespace SignalR.WebAPI.Hubs
{
    // SignalRHub sınıfı, SignalR hub'ını temsil eder.
    public class SignalRHub : Hub
    {

        public static int ClientCount = 0;

        // Özel alanlar: Kategori ve ürün servislerini temsil eder.
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;
        private readonly IMenuTableService menuTableService;

        // Konstrüktör: Bağımlılık enjeksiyonu kullanılarak servisleri alır.
        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        // Tüm istatistikleri gönderen metod
        public async Task SendStatistic()
        {
            var categoryCount = _categoryService.CategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);

            var productCount = _productService.GetProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", productCount);

            var activeCategoryCount = _categoryService.CategorySatatusTrueCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCount);

            var passiveCategoryCount = _categoryService.CategorySatatusFalseCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategoryCount);

            var avgPrice = _productService.ProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", avgPrice.ToString("0.00") + " TL");

            var expensiveProductPrice = _productService.ProducNameByMaxPrice();
            await Clients.All.SendAsync("ReceiveExpensiveProductPrice", expensiveProductPrice);

            var lowerPriceProduct = _productService.ProducNameByMinPrice();
            await Clients.All.SendAsync("ReceiveLowerPriceProduct", lowerPriceProduct);

            var priceHamburgerAvg = _productService.ProductPriceAvgByHamburger();
            await Clients.All.SendAsync("ReceivePriceHamburgerAvg", priceHamburgerAvg);


            var totalOrderCount = _orderService.TotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", totalOrderCount);


            var lastOrderPrice = _orderService.LastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", lastOrderPrice);

            var totalMoneyCaseAmount = _moneyCaseService.TotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", totalMoneyCaseAmount);

            var tableCount = _menuTableService.MenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", tableCount);
        }
        public async Task SendProgress()
        {
			var totalMoneyCaseAmount = _moneyCaseService.TotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", totalMoneyCaseAmount.ToString("0.00" + " TL"));

            var tableCount = _menuTableService.MenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", tableCount);

        }
        public async Task GetBookingList()
        {
            var values = _bookingService.GetAll();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }

        public async Task SendNotification()
        {
            var value = _notificationService.NotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByFalse", value);

            var notificcationList = _notificationService.GetAllNatificationByFalse();
            await Clients.All.SendAsync("ReceiveNotificationListByFalse", notificcationList);
        }

        public async Task SendMenuTable()
        {
            var menuTableList = _menuTableService.GetAll();
            await Clients.All.SendAsync("ReceiveMenuTableList", menuTableList);
        }

        public async Task SendMessage(string user,string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",user,message); 
        }

        public override async Task OnConnectedAsync()
        {
            ClientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", ClientCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            ClientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", ClientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}


//// Kategori sayısını tüm istemcilere gönderen metod.
//public async Task SendCategoryCount()
//{
//    // Kategori sayısını alır.
//    var value = _categoryService.CategoryCount();

//    // Tüm bağlı istemcilere kategori sayısını gönderir.
//    await Clients.All.SendAsync("ReceiveCategoryCount", value);
//}

//// Ürün sayısını tüm istemcilere gönderen metod.
//public async Task SendProductCount()
//{
//    // Ürün sayısını alır.
//    var value = _productService.GetProductCount();

//    // Tüm bağlı istemcilere ürün sayısını gönderir.
//    await Clients.All.SendAsync("ReceiveProductCount", value);
//}

//public async Task SendActiveCategoryCount()
//{
//    var value = _categoryService.CategorySatatusTrueCount();

//    await Clients.All.SendAsync("ReceiveActiveCategoryCount",value);
//}

//public async Task SendPasiveCategoryCount()
//{
//    var value = _categoryService.CategorySatatusFalseCount();

//    await Clients.All.SendAsync("ReceivePasiveCategoryCount", value);

//}