using System;
using PontoNucleoVendas.Domain.Entities;
using Xunit;

namespace PontoNucleoVendas.Tests.Entities
{
    public class CustomerTests
    {
        [Fact]
        public void ShouldReturnCustomerWhenNewInstance()
        {
            var sut = new Customer(Guid.NewGuid(), "1234556665", "John", "Rural");
            Assert.True(sut is Customer);
        }
    }
}
