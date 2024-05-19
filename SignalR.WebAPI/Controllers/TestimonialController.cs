using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {


        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var contacts = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.GetAll());
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateTestimonialDto createTestimonialDto)
        {
            var createdTestimonial = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.Add(createdTestimonial);
            return Ok(createdTestimonial);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var deletedSocialMedia = _testimonialService.GetById(id);
            _testimonialService.Delete(deletedSocialMedia);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatedCategory(UpdateTestimonialDto updateTestimonialDto)
        {
            var updatedTestimonial = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.Update(updatedTestimonial);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCategories(int id)
        {
            var testimonial = _testimonialService.GetById(id);
            return Ok(testimonial);
        }
    }
}
