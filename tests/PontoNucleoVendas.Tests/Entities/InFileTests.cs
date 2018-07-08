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
            var content = "001Á1234567891234ÁPedroÁ50000 001Á3245678865434ÁPauloÁ40000.99 001Á3445678865434ÁJoseÁ60000.99" + Environment.NewLine +
                          "002Á2345675434544345ÁJose da SilvaÁRural 002Á2345675433444345ÁEduardo PereiraÁRural" + Environment.NewLine +
                          "003Á10Á[1-10-100,2-30-2.50,3-40-3.10]ÁPedro 003Á08Á[1-34-10,2-33-1.50,3-40-0.10]ÁPaulo 003Á08Á[1-1-1000]ÁJose";

            var sut = new InFile(Guid.NewGuid(), sourcePath, content);
            Assert.Equal(3, sut.Sellers.Count);
        }

        [Fact]
        public void ShouldReturn2CustomersWhenParse2Customers()
        {
            const string sourcePath = "C:\\test.dat";
            var content = "001Á1234567891234ÁPedroÁ50000 001Á3245678865434ÁPauloÁ40000.99 001Á3445678865434ÁJoseÁ60000.99" + Environment.NewLine +
                          "002Á2345675434544345ÁJose da SilvaÁRural 002Á2345675433444345ÁEduardo PereiraÁRural" + Environment.NewLine +
                          "003Á10Á[1-10-100,2-30-2.50,3-40-3.10]ÁPedro 003Á08Á[1-34-10,2-33-1.50,3-40-0.10]ÁPaulo 003Á08Á[1-1-1000]ÁJose";

            var sut = new InFile(Guid.NewGuid(), sourcePath, content);
            Assert.Equal(2, sut.Customers.Count);
        }
    }
}
