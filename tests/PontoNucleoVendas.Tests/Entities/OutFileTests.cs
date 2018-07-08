using System;
using PontoNucleoVendas.Domain.Entities;
using Xunit;

namespace PontoNucleoVendas.Tests.Entities
{
    public class OutFileTests
    {
        [Fact]
        public void ShouldReturn3SellersWhenParse3Sellers()
        {
            const string sourcePath = "C:\\test.dat";
            var content = "001ç1234567891234çPedroç50000 001ç3245678865434çPauloç40000.99 001ç3445678865434çJoseç60000.99" + Environment.NewLine +
                          "002ç2345675434544345çJose da SilvaçRural 002ç2345675433444345çEduardo PereiraçRural" + Environment.NewLine +
                          "003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çPedro 003ç08ç[1-34-10,2-33-1.50,3-40-0.10]çPaulo 003ç08ç[1-1-1000]çJose";

            var inFile = new InFile(Guid.NewGuid(), sourcePath, content);
            var sut = new OutFile(Guid.NewGuid(), inFile);

            Assert.Equal(3, sut.SellersCount);
        }

        [Fact]
        public void ShouldReturn2CustomersWhenParse2Customers()
        {
            const string sourcePath = "C:\\test.dat";
            var content = "001ç1234567891234çPedroç50000 001ç3245678865434çPauloç40000.99 001ç3445678865434çJoseç60000.99" + Environment.NewLine +
                          "002ç2345675434544345çJose da SilvaçRural 002ç2345675433444345çEduardo PereiraçRural" + Environment.NewLine +
                          "003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çPedro 003ç08ç[1-34-10,2-33-1.50,3-40-0.10]çPaulo 003ç08ç[1-1-1000]çJose";

            var inFile = new InFile(Guid.NewGuid(), sourcePath, content);
            var sut = new OutFile(Guid.NewGuid(), inFile);

            Assert.Equal(2, sut.CustomersCount);
        }

        [Fact]
        public void ShouldReturnSaleId10WhenParseHowMostExpensive()
        {
            const string sourcePath = "C:\\test.dat";
            var content = "001ç1234567891234çPedroç50000 001ç3245678865434çPauloç40000.99 001ç3445678865434çJoseç60000.99" + Environment.NewLine +
                          "002ç2345675434544345çJose da SilvaçRural 002ç2345675433444345çEduardo PereiraçRural" + Environment.NewLine +
                          "003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çPedro 003ç08ç[1-34-10,2-33-1.50,3-40-0.10]çPaulo 003ç08ç[1-1-1000]çJose";

            var inFile = new InFile(Guid.NewGuid(), sourcePath, content);
            var sut = new OutFile(Guid.NewGuid(), inFile);

            Assert.Equal(10, sut.MostExpensiveSaleId);
        }

        [Fact]
        public void ShouldReturnSalesmanPauloWhenParseHowWorstSalesman()
        {
            const string sourcePath = "C:\\test.dat";
            var content = "001ç1234567891234çPedroç50000 001ç3245678865434çPauloç40000.99 001ç3445678865434çJoseç60000.99" + Environment.NewLine +
                          "002ç2345675434544345çJose da SilvaçRural 002ç2345675433444345çEduardo PereiraçRural" + Environment.NewLine +
                          "003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çPedro 003ç08ç[1-34-10,2-33-1.50,3-40-0.10]çPaulo 003ç08ç[1-1-1000]çJose";

            var inFile = new InFile(Guid.NewGuid(), sourcePath, content);
            var sut = new OutFile(Guid.NewGuid(), inFile);

            Assert.Equal("Paulo", sut.WorstSalesman);
        }
    }
}
