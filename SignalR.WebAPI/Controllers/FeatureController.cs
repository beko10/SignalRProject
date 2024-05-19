using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult CategoryList()
        {
            var contacts = _mapper.Map<List<ResultFeatureDto>>(_featureService.GetAll());
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateFeatureDto createFeatureDto)
        {
            var createdFeature = _mapper.Map<Feature>(createFeatureDto);
            _featureService.Add(createdFeature);
            return Ok(createdFeature);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var deletedContacts = _featureService.GetById(id);
            _featureService.Delete(deletedContacts);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatedCategory(UpdateFeatureDto updateFeatureDto)
        {
            var updatedFeature = _mapper.Map<Feature>(updateFeatureDto);
            _featureService.Update(updatedFeature);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCategories(int id)
        {
            var feature = _featureService.GetById(id);
            return Ok(feature);
        }

    }

       
    
}
