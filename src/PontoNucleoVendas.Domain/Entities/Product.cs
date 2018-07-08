using System;

namespace PontoNucleoVendas.Domain.Entities
{
    public class Product  : Entity
    {
        public Product(Guid id,
                       int productId,
                       string name) : 
            base(id)
        {
            ProductId = productId;
            Name = name;
        }
        
        public int ProductId { get; }        
        public string Name { get; }
    }
}