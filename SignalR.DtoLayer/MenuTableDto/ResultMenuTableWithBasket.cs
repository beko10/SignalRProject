using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.MenuTableDto
{
    public class ResultMenuTableWithBasket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ResultProductDto Product { get; set; }
    }
}
