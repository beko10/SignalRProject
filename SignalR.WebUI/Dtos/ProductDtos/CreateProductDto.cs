﻿namespace SignalR.WebUI.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Descripion { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public bool ProductStatus { get; set; }
        public int CategoryId { get; set; }
    }
}
