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