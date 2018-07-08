using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PontoNucleoVendas.Domain.Entities
{
    public class InFile : Entity
    {
        private IList<string> _lines;
        private IList<Salesman> _sellers;
        private IList<Customer> _customers;
        private IList<Product> _products;
        private IList<Sale> _sales;

        public InFile(Guid id,
                      string sourcePath,
                      string content) : 
            base(id)
        {
            SourcePath = sourcePath;
            Content = content;
            _lines =  new List<string>();
            _sellers =  new List<Salesman>();
            _customers =  new List<Customer>();
            _products =  new List<Product>();
            _sales =  new List<Sale>();

            foreach(var line in content.Split(new string[] { Environment.NewLine }, 
                                              StringSplitOptions.RemoveEmptyEntries))
            {
                AddLine(line);
                switch (line.Substring(0, 3))
                {
                    case "001":
                        AddSellers(line);
                        break;
                    case "002":
                        AddCustomers(line);
                        break;
                    case "003":
                        AddSales(line);
                        break;
                    default:
                        break;
                }
            }            
        }

        public string SourcePath { get; }
        public string Content { get; }
        public IReadOnlyCollection<string> Lines => _lines.ToArray();
        public IReadOnlyCollection<Customer> Customers => _customers.ToArray();
        public IReadOnlyCollection<Salesman> Sellers => _sellers.ToArray();
        public IReadOnlyCollection<Product> Products => _products.ToArray();
        public IReadOnlyCollection<Sale> Sales => _sales.ToArray();

        public void AddLine(string line)
        {
            _lines.Add(line);
        }
        
        public void AddSalesman(Salesman salesman)
        {
            _sellers.Add(salesman);
        }
        
        public void AddSellers(string line)
        {
            var sellers = new List<Salesman>();
            var sellersInLIne = line.Replace(" 001", ";001").Split(';');

            foreach (var salesmanItem in sellersInLIne)
            {
                var data = salesmanItem.Split('ç');
                var salesman = new Salesman(Guid.NewGuid(),
                                            data[1],
                                            data[2],
                                            Convert.ToDecimal(data[3], new CultureInfo("en-US")));
                sellers.Add(salesman);
            }

            AddSellers(sellers);
        }
        
        public void AddSellers(List<Salesman> sellers)
        {
            foreach (var salesman in sellers)
            {
                _sellers.Add(salesman);
            }            
        }
        
        
        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }
        
        public void AddCustomers(string line)
        {
            var customers = new List<Customer>();
            var customersInLine = line.Replace(" 002", ";002").Split(';');

            foreach (var customerItem in customersInLine)
            {
                var data = customerItem.Split('ç');
                var customer = new Customer(Guid.NewGuid(),
                                            data[1],
                                            data[2],
                                            data[3]);
                customers.Add(customer);
            }

            AddCustomers(customers);
        }
        
        public void AddCustomers(List<Customer> customers)
        {
            foreach (var customer in customers)
            {
                _customers.Add(customer);
            }            
        }
        
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
        
        public void AddSale(Sale sale)
        {
            _sales.Add(sale);
        }
        
        public void AddSales(string line)
        {
            var sales = new List<Sale>();
            var salesInLine = line.Replace(" 003", ";003").Split(';');

            foreach (var saleInLine in salesInLine)
            {
                var data = saleInLine.Split('ç');
                var salesmanId = Sellers.FirstOrDefault(x => x.Name == data[3]).Id;
                var sale = new Sale(Guid.NewGuid(),
                                    Convert.ToInt32(data[1], new CultureInfo("en-US")),
                                    salesmanId);

                var saleItemsCollection = data[2]
                                            .Replace("[", "")
                                            .Replace("]", "")
                                            .Split(',');

                foreach (var saleItemInLine in saleItemsCollection)
                {
                    var saleItemData = saleItemInLine.Split('-');
                    var saleItem = new SaleItem(Guid.NewGuid(),
                                                Convert.ToInt32(saleItemData[0], new CultureInfo("en-US")),
                                                Convert.ToDecimal(saleItemData[1], new CultureInfo("en-US")),
                                                Convert.ToDecimal(saleItemData[2], new CultureInfo("en-US")));
                    sale.AddSaleItem(saleItem);
                }

                sales.Add(sale);
            }

            AddSales(sales);
        }
        
        public void AddSales(List<Sale> sales)
        {
            foreach (var sale in sales)
            {                
                _sales.Add(sale);
            }
        }
    }
}