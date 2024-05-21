using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var products = _mapper.Map<List<ResultProductDto>>(_productService.GetAll());
            return Ok(products);
        }

        [HttpGet("ProductWitCategory")]
        public IActionResult ProductWithCategoryList()
        {
            var productsWithCategories = _mapper.Map<List<ResultProductWithCategoryDto>>(_productService.GetProductWithCategory());
            return Ok(productsWithCategories);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var createdProduct = _mapper.Map<Product>(createProductDto);
            _productService.Add(createdProduct);
            return Ok(createdProduct);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var deletedProduct = _productService.GetById(id);
            _productService.Delete(deletedProduct);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatedProduct(UpdateProductDto updateProductDto)
        {
            var updatedProduct = _mapper.Map<Product>(updateProductDto);
            _productService.Update(updatedProduct);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetById(id);
            return Ok(product);
        }

        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            var productCount = _productService.GetProductCount();
            return Ok(productCount);    
        }

        [HttpGet("ProductCountByCategoryName")]
        public IActionResult ProductCountByCategoryName(string categoryName)
        {
            var result = _productService.ProductCountByCategoryName(categoryName);
            return Ok(result);
        }
        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            var productsPriceAvg = _productService.ProductPriceAvg();
            return Ok(productsPriceAvg);
        }
        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductNameByMaxPrice()
        {
            var productNameByMaxPrice =  _productService.ProducNameByMaxPrice();
            return Ok(productNameByMaxPrice);   
        }

        [HttpGet("ProductNameByMinPrice")]
        public IActionResult ProductNameByMinPrice()
        {
            var productNameByMinPrice =  _productService.ProducNameByMaxPrice();
            return Ok(productNameByMinPrice);
        }

        [HttpGet("ProductPriceAvgByHamburger")]
        public IActionResult ProductPriceAvgByHamburger()
        {
            var productAvgByHamburgerPrice = _productService.ProductPriceAvgByHamburger();
            return Ok(productAvgByHamburgerPrice);
        }
    }
}
