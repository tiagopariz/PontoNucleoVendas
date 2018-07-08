using System;

namespace PontoNucleoVendas.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(Guid id,
                        string cnpj,
                        string name,
                        string businessArea) : 
            base(id)
        {
            Cnpj = cnpj;
            Name = name;
            BusinessArea = businessArea;
        }

        public string Cnpj { get; }
        public string Name { get; }
        public string BusinessArea { get; }
    }
}