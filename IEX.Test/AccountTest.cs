using NUnit.Framework;
using System.Threading.Tasks;
using ZH.Code.IEX.V2;
using ZH.Code.IEX.V2.Model.Account.Request;
using ZH.Code.IEX.V2.Model.Account.Response;

namespace IEX.Test
{
    public class AccountTest
    {
        private IEXRestV2Client sandBoxClient;

        [SetUp]
        public void Setup()
        {
            sandBoxClient = new IEXRestV2Client(TestGlobal.pk, TestGlobal.sk, false, true);
        }

        [Test]
        public async Task MetadataAsyncTest()
        {
            MetadataResponse response = await sandBoxClient.Account.MetadataAsync();

            Assert.IsNotNull(response);
        }

        [Test]
        [TestCase(UsageType.All)]
        public async Task UsageAsyncTest(UsageType type)
        {
            UsageResponse response = await sandBoxClient.Account.UsageAsync(type);

            Assert.IsNotNull(response);
        }
    }
}