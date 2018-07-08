using System;
using PontoNucleoVendas.Domain.Entities;
using Xunit;

namespace PontoNucleoVendas.Tests.Entities
{
    public class InFileTests
    {
        [Fact]
        public void ShouldReturn3SellersWhenParse3Sellers()
        {
            const string sourcePath = "C:\\test.dat";
            var content = "001�1234567891234�Pedro�50000 001�3245678865434�Paulo�40000.99 001�3445678865434�Jose�60000.99" + Environment.NewLine +
                          "002�2345675434544345�Jose da Silva�Rural 002�2345675433444345�Eduardo Pereira�Rural" + Environment.NewLine +
                          "003�10�[1-10-100,2-30-2.50,3-40-3.10]�Pedro 003�08�[1-34-10,2-33-1.50,3-40-0.10]�Paulo 003�08�[1-1-1000]�Jose";

            var sut = new InFile(Guid.NewGuid(), sourcePath, content);
            Assert.Equal(3, sut.Sellers.Count);
        }

        [Fact]
        public void ShouldReturn2CustomersWhenParse2Customers()
        {
            const string sourcePath = "C:\\test.dat";
            var content = "001�1234567891234�Pedro�50000 001�3245678865434�Paulo�40000.99 001�3445678865434�Jose�60000.99" + Environment.NewLine +
                          "002�2345675434544345�Jose da Silva�Rural 002�2345675433444345�Eduardo Pereira�Rural" + Environment.NewLine +
                          "003�10�[1-10-100,2-30-2.50,3-40-3.10]�Pedro 003�08�[1-34-10,2-33-1.50,3-40-0.10]�Paulo 003�08�[1-1-1000]�Jose";

            var sut = new InFile(Guid.NewGuid(), sourcePath, content);
            Assert.Equal(2, sut.Customers.Count);
        }
    }
}
