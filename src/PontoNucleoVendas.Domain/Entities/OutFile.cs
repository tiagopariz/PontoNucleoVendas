using System;
using System.Linq;

namespace PontoNucleoVendas.Domain.Entities
{
    public class OutFile : Entity
    {
        public OutFile(Guid id,
                       InFile inFile) : 
            base(id)
        {
            InFile = inFile;
            CustomersCount = inFile.Customers.Count;
            SellersCount = inFile.Sellers.Count;
            if (inFile.Sales == null || inFile.Sales.Count <= 0)
                return;

            var mostExpensiveSale = inFile.Sales
                                        .OrderByDescending(x => x.Total)
                                        .FirstOrDefault();

            if (mostExpensiveSale != null)
                MostExpensiveSaleId = mostExpensiveSale.SaleId;

            var sales = inFile
                .Sales
                .Select(x => new 
                { 
                    x.SalesmanId, 
                    x.Total                })
                .ToList();
                
            var salesPerSalesmand = sales
                                    .GroupBy(x => x.SalesmanId)
                                    .SelectMany(y => y.Select(
                                        line => new
                                        {
                                            line.SalesmanId,                                                
                                            Total = y.Sum(c => c.Total),
                                        }));

            var worstSalesman = salesPerSalesmand
                                    .OrderBy(x => x.Total)
                                    .FirstOrDefault();

            if (worstSalesman != null)
            {
                var worstSalesmanId = worstSalesman.SalesmanId;
                var salesman = inFile.Sellers.FirstOrDefault(x => x.Id == worstSalesmanId);
                if (salesman != null)
                    WorstSalesman = salesman.Name;
            }

            Out = $"Customers Count: {CustomersCount}\n" +
                  $"Sellers Count: {SellersCount}\n" +
                  $"Most expensive sale Id: {MostExpensiveSaleId}\n" +
                  $"The worst salesman: {WorstSalesman}";
        }

        public InFile InFile { get; }
        public int CustomersCount { get; }
        public int SellersCount { get; }
        public int MostExpensiveSaleId { get; }
        public string WorstSalesman { get; }
        public string Out { get; }
    }
}