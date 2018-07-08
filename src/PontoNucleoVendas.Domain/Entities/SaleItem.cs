using System;

namespace PontoNucleoVendas.Domain.Entities
{
    public class SaleItem : Entity
    {
        public SaleItem(Guid id,
                        int productId,
                        decimal quantity,
                        decimal price) : 
            base(id)
        {
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }
        
        public int ProductId { get; set; }
        public decimal Quantity { get; }
        public decimal Price { get; }
    }
}