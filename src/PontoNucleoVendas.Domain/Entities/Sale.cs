using System;
using System.Collections.Generic;
using System.Linq;

namespace PontoNucleoVendas.Domain.Entities
{
    public class Sale : Entity
    {
        private IList<Item> _items;

        public Sale(int id,
                    int salesmanId) : 
            base(id)
        {
            SalesmanId = salesmanId;            
            _items = new List<Item>();
        }

        public int SalesmanId { get; }

        public IReadOnlyCollection<Item> Items => _items.ToArray();

        public void AddItem(Item item)
        {
            _items.Add(item);
        }
    }
}