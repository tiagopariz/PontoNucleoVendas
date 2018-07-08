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
            if (inFile.Sales != null && inFile.Sales.Count > 0)
            {
                MostExpensiveSaleId = inFile.Sales
                                        .OrderByDescending(x => x.Total())
                                        .FirstOrDefault()
                                        .SaleId;
                var sales = inFile
                                .Sales
                                .Select(x => new 
                                            { 
                                                SalesmanId = x.SalesmanId, 
                                                Total = x.Total() 
                                            })
                                .ToList();
                
                var salesPerSalesmand = sales
                                            .GroupBy(x => x.SalesmanId)
                                            .SelectMany(cl => cl.Select(
                                                csLine => new
                                                {
                                                    SalesmanId = csLine.SalesmanId,                                                
                                                    Total = cl.Sum(c => c.Total),
                                                }));

                var  worstSalesmanId = salesPerSalesmand.OrderBy(x => x.Total).FirstOrDefault().SalesmanId;

                WorstSalesman = inFile.Sellers.FirstOrDefault(x => x.Id == worstSalesmanId).Name;

                Out = $"Customers Count: {CustomersCount}\n" +
                      $"Sellers Count: {SellersCount}\n" +
                      $"Most expensive sale Id: {MostExpensiveSaleId}\n" +
                      $"The worst salesman: {WorstSalesman}";
            }
        }

        public InFile InFile { get; }
        public int CustomersCount { get; }
        public int SellersCount { get; }
        public int MostExpensiveSaleId { get; }
        public string WorstSalesman { get; }
        public string Out { get; }
    }
}