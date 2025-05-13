using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoService.Api.Controllers;
using AutoService.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using AutoService.Shared;

namespace AutoService.Api.Tests
{
    public class CustomersControllerTests
    {
        [Fact]
        public async Task Get_ExistingCustomer_ReturnsOkCustomer()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock
                .Setup(x => x.Get(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(new Customer());
            CustomersController customersController = new CustomersController(customerServiceMock.Object);

            var response = await customersController.Get(0);
            var result = response.Result;

            customerServiceMock.VerifyAll();

            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<Customer?>((result as OkObjectResult).Value);
        }

        [Fact]
        public async Task Get_NonExistingCustomer_ReturnsNotFound()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock
                .Setup(x => x.Get(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(value: null);
            CustomersController customersController = new CustomersController(customerServiceMock.Object);

            var response = await customersController.Get(0);
            var result = response.Result;

            customerServiceMock.VerifyAll();

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetAll_Customers_ReturnsOk()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock
                .Setup(x => x.GetAll())
                .ReturnsAsync(value: new List<Customer>());
            CustomersController customersController = new CustomersController(customerServiceMock.Object);

            var response = await customersController.GetAll();
            var result = response.Result;

            customerServiceMock.VerifyAll();

            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<Customer>>((result as OkObjectResult).Value);
        }

        [Fact]
        public async Task Add_Customer_ReturnsOk()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock
                .Setup(x => x.Add(It.IsAny<Customer>()))
                .Verifiable();

            CustomersController customersController = new CustomersController(customerServiceMock.Object);

            var response = await customersController.Add(new Customer());

            customerServiceMock.VerifyAll();

            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public async Task Delete_NonExistingCustomer_ReturnsNotFound()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock
                .Setup(x => x.Get(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(value: null);

            CustomersController customersController = new CustomersController(customerServiceMock.Object);

            var response = await customersController.Delete(0);

            customerServiceMock.VerifyAll();

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public async Task Delete_ExistingCustomer_ReturnsOk()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock
                .Setup(x => x.Get(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(new Customer());
            customerServiceMock
                .Setup(x => x.Delete(It.IsAny<int>()))
                .Verifiable();

            CustomersController customersController = new CustomersController(customerServiceMock.Object);

            var response = await customersController.Delete(0);

            customerServiceMock.VerifyAll();

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task Update_ExistingCustomer_ReturnsOk()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock
                .Setup(x => x.Get(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(new Customer());
            customerServiceMock
                .Setup(x => x.Update(It.IsAny<Customer>()))
                .Verifiable();

            CustomersController customersController = new CustomersController(customerServiceMock.Object);

            var response = await customersController.Update(0, new Customer()
            {
                Id = 0,
            });

            customerServiceMock.VerifyAll();

            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public async Task Update_NonExistingCustomer_ReturnsNotFound()
        {
            Mock<ICustomerService> customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock
                .Setup(x => x.Get(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(value: null);

            CustomersController customersController = new CustomersController(customerServiceMock.Object);

            var response = await customersController.Update(0, new Customer()
            {
                Id = 0,
            });

            customerServiceMock.VerifyAll();

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public async Task Update_IdMismatch_ReturnsBadRequest()
        {
            Mock<ICustomerService> workServiceMock = new Mock<ICustomerService>();

            CustomersController customersController = new CustomersController(workServiceMock.Object);

            var response = await customersController.Update(0, new Customer()
            {
                Id = 0
            });

            Assert.IsType<NotFoundResult>(response);
        }
    }
}
