using System;
using PontoNucleoVendas.Domain.Interfaces;

namespace PontoNucleoVendas.Domain.Entities
{
    public abstract class Entity : IEntity
    {
        protected Entity(Guid id)
        {
            Id = id == Guid.Empty 
                    ? Guid.NewGuid() 
                    : id;
        }

        public Guid Id { get; set; }
    }
}