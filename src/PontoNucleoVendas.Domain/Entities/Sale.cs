using System;
using System.Collections.Generic;
using System.Linq;

namespace PontoNucleoVendas.Domain.Entities
{
    public class Sale : Entity
    {
        private IList<SaleItem> _saleItems;

        public Sale(Guid id,
                    int saleId,
                    Guid salesmanId) : 
            base(id)
        {
            SaleId = saleId;
            SalesmanId = salesmanId;            
            _saleItems = new List<SaleItem>();
        }

        public Guid SalesmanId { get; }
        public int SaleId { get; }

        public IReadOnlyCollection<SaleItem> SaleItems => _saleItems.ToArray();

        public void AddSaleItem(SaleItem saleItem)
        {
            _saleItems.Add(saleItem);
        }

        public decimal Total()
        {
            return _saleItems.Sum(x => x.Price * x.Quantity);
        }
    }
}