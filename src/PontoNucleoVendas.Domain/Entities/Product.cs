using System;

namespace PontoNucleoVendas.Domain.Entities
{
    public class Product  : Entity
    {
        public Product(int id, 
                       string name) : 
            base(id)
        {
            Name = name;
        }
        
        public string Name { get; }
    }
}