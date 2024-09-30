using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PropertyManagementApi.Controllers;
using PropertyManagementApi.DTOs;
using PropertyManagementApi.Models;
using PropertyManagementApi.Services;

namespace PropertyManagementApi.Tests
{
    [TestFixture]
    public class PropertiesControllerTests
    {
        private Mock<IPropertyService> _mockService;
        private IMapper _mapper;
        private PropertiesController _controller;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IPropertyService>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = mapperConfig.CreateMapper();

            _controller = new PropertiesController(_mockService.Object, _mapper);
        }

        [Test]
        public async Task GetProperties_ReturnsOkResult_WithListOfProperties()
        {
            // Arrange
            var properties = new List<Property>
            {
                new Property { PropertyID = 1, Address = "123 Maple Street", City = "Springfield", State = "IL", ZipCode = "62701" },
                new Property { PropertyID = 2, Address = "456 Oak Street", City = "Shelbyville", State = "IN", ZipCode = "46176" }
            };
            _mockService.Setup(service => service.GetAllPropertiesAsync()).ReturnsAsync(properties);

            // Act
            var result = await _controller.GetProperties();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var returnedProperties = okResult.Value as IEnumerable<PropertyDTO>;
            Assert.AreEqual(2, ((List<PropertyDTO>)returnedProperties).Count);
        }

        [Test]
        public async Task GetProperty_ReturnsNotFound_WhenPropertyDoesNotExist()
        {
            // Arrange
            _mockService.Setup(service => service.GetPropertyByIdAsync(It.IsAny<int>())).ReturnsAsync((Property)null);

            // Act
            var result = await _controller.GetProperty(1);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

        [Test]
        public async Task CreateProperty_ReturnsCreatedAtActionResult_WithCreatedProperty()
        {
            // Arrange
            var propertyDTO = new PropertyDTO { Address = "789 Pine Street", City = "Capital City", State = "TX", ZipCode = "73301" };
            var property = new Property { PropertyID = 3, Address = "789 Pine Street", City = "Capital City", State = "TX", ZipCode = "73301" };

            _mockService.Setup(service => service.CreatePropertyAsync(It.IsAny<Property>())).ReturnsAsync(property);

            // Act
            var result = await _controller.CreateProperty(propertyDTO);

            // Assert
            Assert.IsInstanceOf<CreatedAtActionResult>(result.Result);
            var createdAtActionResult = result.Result as CreatedAtActionResult;
            Assert.IsNotNull(createdAtActionResult);
            var returnedProperty = createdAtActionResult.Value as PropertyDTO;
            Assert.AreEqual(3, returnedProperty.PropertyID);
        }

        [Test]
        public async Task UpdateProperty_ReturnsNoContent_WhenUpdateIsSuccessful()
        {
            // Arrange
            var propertyDTO = new PropertyDTO { PropertyID = 1, Address = "123 Maple Street Updated", City = "Springfield", State = "IL", ZipCode = "62701" };
            var updatedProperty = new Property { PropertyID = 1, Address = "123 Maple Street Updated", City = "Springfield", State = "IL", ZipCode = "62701" };

            _mockService.Setup(service => service.UpdatePropertyAsync(It.IsAny<int>(), It.IsAny<Property>())).ReturnsAsync(updatedProperty);

            // Act
            var result = await _controller.UpdateProperty(1, propertyDTO);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public async Task DeleteProperty_ReturnsNoContent_WhenDeleteIsSuccessful()
        {
            // Arrange
            _mockService.Setup(service => service.DeletePropertyAsync(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteProperty(1);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public async Task DeleteProperty_ReturnsNotFound_WhenPropertyDoesNotExist()
        {
            // Arrange
            _mockService.Setup(service => service.DeletePropertyAsync(It.IsAny<int>())).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteProperty(1);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
}
