using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var contacts = _mapper.Map<List<ResultContactDto>>(_contactService.GetAll());
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            var createdContact = _mapper.Map<Contact>(createContactDto);
            _contactService.Add(createdContact);
            return Ok(createdContact);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var deletedContacts = _contactService.GetById(id);
            _contactService.Delete(deletedContacts);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatedCategory(UpdateContactDto updateContactDto)
        {
            var updatedContacts = _mapper.Map<Contact>(updateContactDto);
            _contactService.Update(updatedContacts);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCategories(int id)
        {
            var contact = _contactService.GetById(id);
            return Ok(contact);
        }
    }
}
