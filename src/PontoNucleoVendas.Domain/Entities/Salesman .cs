using System;

namespace PontoNucleoVendas.Domain.Entities
{
    public class Salesman  : Entity
    {
        public Salesman(Guid id, 
                        string cpf,
                        string name,
                        decimal salary) : 
            base(id)
        {
            Cpf = cpf;
            Name = name;
            Salary = salary;
        }

        public string Cpf { get; }
        public string Name { get; }
        public decimal Salary { get; }
    }
}