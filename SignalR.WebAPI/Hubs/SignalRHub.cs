﻿using Microsoft.AspNetCore.SignalR;  // SignalR ile ilgili sınıfları ve arayüzleri içerir.
using SignalR.BusinessLayer.Abstract;  // İş katmanındaki soyut sınıfları içerir.

namespace SignalR.WebAPI.Hubs
{
    // SignalRHub sınıfı, SignalR hub'ını temsil eder.
    public class SignalRHub : Hub
    {
        // Özel alanlar: Kategori ve ürün servislerini temsil eder.
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;

        // Konstrüktör: Bağımlılık enjeksiyonu kullanılarak servisleri alır.
        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
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