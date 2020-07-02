using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using NUnit.Framework;

namespace NanoService.Test
{
    public class Tests
    {
        private NanoServiceWebApplicationFactory _factory;
        private HttpClient _client;

        [OneTimeSetUp]
        public void GivenARequestToTheController()
        {
            _factory = new NanoServiceWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        //[Test]
        //public async System.Threading.Tasks.Task Test1Async()
        //{
        //    var textContent = new ByteArrayContent(Encoding.UTF8.GetBytes("Backpack for his applesauce"));
        //    textContent.Headers.ContentType = new MediaTypeHeaderValue("text/plain");

        //    var result = await _client.PostAsync("/sample", textContent);
        //    Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        //}

        [Test]
        public async System.Threading.Tasks.Task Test1Async()
        {
            var result = await _client.GetAsync("/dogs");
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}