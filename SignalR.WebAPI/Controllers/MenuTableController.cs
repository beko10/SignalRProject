using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTableController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
		private readonly IMapper _mapper;

		public MenuTableController(IMenuTableService menuTableService, IMapper mapper)
		{
			_menuTableService = menuTableService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult MenuTableList()
		{
			var values = _menuTableService.GetAll();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
		{
			var addedMenuTable = _mapper.Map<MenuTable>(createMenuTableDto);	
			_menuTableService.Add(addedMenuTable);
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var values = _menuTableService.GetById(id);
			_menuTableService.Delete(values);
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			var updatedMenuTable = _mapper.Map<MenuTable>(updateMenuTableDto);
			_menuTableService.Update(updatedMenuTable);
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult GetMenuTable(int id)
		{
			var value = _menuTableService.GetById(id);
			return Ok(value);
		}

		[HttpGet("MenuTableCount")]
        public ActionResult MenuTableCount()
        {
            return Ok(_menuTableService.MenuTableCount());  
        }
    }
}
