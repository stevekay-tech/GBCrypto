using GloboCrypto.WebAPI.Services.Coins;
using GloboCrypto.WebAPI.Services.Http;
using GloboCrypto.WebAPI.Services.Models;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GloboCrypto.Tests
{
    [TestFixture]
    public class CoinServiceTests
    {
        private ICoinService CoinService;
        private Mock<IConfiguration> MockConfiguration;
        private Mock<IHttpService> MockHttpService;
        [SetUp]
        public void Setup()
        {
            MockConfiguration = new Mock<IConfiguration>();
            MockHttpService = new Mock<IHttpService>();
            
            MockConfiguration.Setup(p => p["NomicsAPIKey"]).Returns("a-key");

            CoinService = new CoinService(MockConfiguration.Object, MockHttpService.Object);
        }

        [Test]
        public async Task GetCoinInfo_Success()
        {
            MockHttpService.Setup(p => p.GetAsync<NomicsCoinInfo[]>(
                It.IsAny<string>()
                ))
                .ReturnsAsync(new NomicsCoinInfo[] { new NomicsCoinInfo { Id = "BTC" } });
            var result = await CoinService.GetCoinInfo("BTC");
            Assert.AreEqual("BTC", result.Id);
        }

        [Test]
        public async Task GetCoinInfo_NotFound()
        {
            MockHttpService.Setup(p => p.GetAsync<NomicsCoinInfo[]>(
                It.IsAny<string>()
                ))
                .ReturnsAsync(new NomicsCoinInfo[0]);
            var result = await CoinService.GetCoinInfo("AA");
            Assert.AreEqual(null, result);
        }

    }
}