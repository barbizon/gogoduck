using DuckDuck.ViewModels;
using DuckDuckGoProxy.Integration.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace DuckDuck.Client.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IDuckDuckClient<DuckDuckRequest, DuckDuckResponse> _target;
        public UnitTest1()
        {
            _target = new DuckDuckClient(TestData.DuckClientSourceConfigSuccess);
        }

        [TestMethod]
        public async Task TestClientSuccess()
        { 
            var result = await _target.GetAsync(TestData.DuckDuckRequest);
            Assert.IsTrue(result.RelatedTopics.Any());
        }
    }
}
