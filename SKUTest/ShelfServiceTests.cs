using Moq;
using SKU.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SKU.Services;
using Castle.Components.DictionaryAdapter.Xml;
using Castle.Core.Configuration;

namespace SKUTest
{
    [TestClass]
    public class ShelfServiceTests
    {
        [TestMethod]
        public async Task GetShelfCabinets_ReturnsCabinets_WhenResponseIsSuccessful()
        {
            // Arrange
            var httpClientMock = new Mock<HttpClient>();
            var configurationMock = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();
            var expectedCabinets = new List<Cabinet>(); // Provide some sample cabinets here

            // Set up the HttpClient mock to return a successful response
            httpClientMock
                .Setup(client => client.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ObjectContent<List<Cabinet>>(expectedCabinets, new JsonMediaTypeFormatter())
                });

            var shelfService = new ShelfManager(configurationMock.Object);

            // Act
            var actualCabinets = await shelfService.GetShelfCabinets();

            // Assert
            CollectionAssert.AreEqual(expectedCabinets, actualCabinets);
        }
    }
}
