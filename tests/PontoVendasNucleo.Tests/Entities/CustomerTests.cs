using System;
using PontoNucleoVendas.Domain.Entities;
using Xunit;

namespace PontoVendasNucleo.Tests.Entities
{
    public class CustomerTests
    {
        [Fact]
        public void ShouldReturnCustomerWhenNewInstance()
        {
            var sut = new Customer(1, "1234556665", "John", "Rural");
            Assert.True(sut is Customer);
        }
    }
}
