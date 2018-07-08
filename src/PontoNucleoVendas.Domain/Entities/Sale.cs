using System;
using System.Collections.Generic;
using System.Linq;

namespace PontoNucleoVendas.Domain.Entities
{
    public class Sale : Entity
    {
        private IList<SaleItem> _saleItems;

        public Sale(Guid id,
                    int salesmanId) : 
            base(id)
        {
            SalesmanId = salesmanId;            
            _saleItems = new List<SaleItem>();
        }

        public int SalesmanId { get; }

        public IReadOnlyCollection<SaleItem> SaleItems => _saleItems.ToArray();

        public void AddSaleItem(SaleItem saleItem)
        {
            _saleItems.Add(saleItem);
        }
    }
}