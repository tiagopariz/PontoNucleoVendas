using System;
using PontoNucleoVendas.Domain.Interfaces;

namespace PontoNucleoVendas.Domain.Entities
{
    public abstract class Entity : IEntity
    {
        protected Entity(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}