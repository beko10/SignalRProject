using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {

        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var contacts = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.GetAll());
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateSocialMediaDto createSocialMediaDto)
        {
            var createdSocialMedia = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.Add(createdSocialMedia);
            return Ok(createdSocialMedia);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var deletedSocialMedia = _socialMediaService.GetById(id);
            _socialMediaService.Delete(deletedSocialMedia);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatedCategory(UpdateProductDto updateProductDto)
        {
            var updatedProduct = _mapper.Map<SocialMedia>(updateProductDto);
            _socialMediaService.Update(updatedProduct);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCategories(int id)
        {
            var socialMedia = _socialMediaService.GetById(id);
            return Ok(socialMedia);
        }
    }
}
