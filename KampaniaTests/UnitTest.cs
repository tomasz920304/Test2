using KampaniaAPI.Manager;
using KampaniaProjekt.Controllers;
using KampaniaProjekt.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace KampaniaProjekt.Tests
{
    public class KampaniaProjektTests
    {
        KampaniaController _controller;

        public KampaniaProjektTests()
        {
            _controller = new KampaniaController(new KampaniaRepository(@"Data Source=(local);Initial Catalog=TestKampaniaDataBase;Integrated Security=True"));
        }

        //Testing the Get Method

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Kampania>>(okResult.Value);
            Assert.Equal(7, items.Count);
        }

        //Testing the GetById method

        [Fact]
        public void GetById_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(777);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ReturnsOkResult()
        {
            // Arrange
            var test = 1;

            // Act
            var okResult = _controller.Get(test);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ReturnsRightItem()
        {
            // Arrange
            var test = 1;

            // Act
            var okResult = _controller.Get(1).Result as OkObjectResult;

            // Assert
            Assert.IsType<Kampania>(okResult.Value);
            Assert.Equal(test, (okResult.Value as Kampania).Id);
        }

        //Testing the Add Method


        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Kampania testItem = new Kampania()
            {
                Id = 1,
                Nazwa = "Nazwa1",
                Koszt = 1
            };

            // Act
            var createdResponse = _controller.Post(testItem);

            // Assert
            Assert.IsType<CreatedResult>(createdResponse);
        }

        //Remove method

        [Fact]
        public void Remove_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExisting = 777;

            // Act
            var badResponse = _controller.Delete(notExisting);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }
        [Fact]
        public void Remove_ReturnsOkResult()
        {
            // Arrange
            var existing = 6;

            // Act
            var okResponse = _controller.Delete(existing);

            // Assert
            Assert.IsType<OkResult>(okResponse);
        }
    }
}
