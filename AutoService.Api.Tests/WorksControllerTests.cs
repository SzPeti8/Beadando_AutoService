using AutoService.Api.Controllers;
using AutoService.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using AutoService.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Api.Tests
{
    public class WorksControllerTests
    {
        [Fact]
        public async Task Get_ExistingWork_ReturnsOkWork()
        {
            Mock<IWorkService> workServiceMock = new Mock<IWorkService>();
            workServiceMock
                .Setup(x => x.Get(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(new Work());
            WorksController WorksControllers = new WorksController(workServiceMock.Object);

            var response = await WorksControllers.Get(0);
            var result = response.Result;

            workServiceMock.VerifyAll();

            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<Work?>((result as OkObjectResult).Value);
        }

        [Fact]
        public async Task Get_NonExistingWork_ReturnsNotFound()
        {
            Mock<IWorkService> workServiceMock = new Mock<IWorkService>();
            workServiceMock
                .Setup(x => x.Get(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(value: null);
            WorksController WorksController = new WorksController(workServiceMock.Object);

            var response = await WorksController.Get(0);
            var result = response.Result;

            workServiceMock.VerifyAll();

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetAll_Works_ReturnsOk()
        {
            Mock<IWorkService> workServiceMock = new Mock<IWorkService>();
            workServiceMock
                .Setup(x => x.GetAll())
                .ReturnsAsync(value: new List<Work>());
            WorksController WorksController = new WorksController(workServiceMock.Object);

            var response = await WorksController.GetAll();
            var result = response.Result;

            workServiceMock.VerifyAll();

            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<Work>>((result as OkObjectResult).Value);
        }

        [Fact]
        public async Task Add_Work_ReturnsOk()
        {
            Mock<IWorkService> workServiceMock = new Mock<IWorkService>();
            workServiceMock
                .Setup(x => x.Add(It.IsAny<Work>()))
                .Verifiable();

            WorksController WorksController = new WorksController(workServiceMock.Object);

            var response = await WorksController.Add(new Work());

            workServiceMock.VerifyAll();

            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public async Task Delete_NonExistingWork_ReturnsNotFound()
        {
            Mock<IWorkService> workServiceMock = new Mock<IWorkService>();
            workServiceMock
                .Setup(x => x.Get(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(value: null);

            WorksController WorksController = new WorksController(workServiceMock.Object);

            var response = await WorksController.Delete(0);

            workServiceMock.VerifyAll();

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public async Task Delete_ExistingWork_ReturnsOk()
        {
            Mock<IWorkService> workServiceMock = new Mock<IWorkService>();
            workServiceMock
                .Setup(x => x.Get(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(new Work());
            workServiceMock
                .Setup(x => x.Delete(It.IsAny<int>()))
                .Verifiable();

            WorksController WorksController = new WorksController(workServiceMock.Object);

            var response = await WorksController.Delete(0);

            workServiceMock.VerifyAll();

            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public async Task Update_ExistingWork_ReturnsOk()
        {

            var workServiceMock = new Mock<IWorkService>();
            var existingWork = new Work { Id = 0 };
            workServiceMock
                .Setup(x => x.Get(0, It.IsAny<bool>()))
                .ReturnsAsync(existingWork);
            workServiceMock
                .Setup(x => x.Update(It.IsAny<Work>()))
                .Verifiable();

            var controller = new WorksController(workServiceMock.Object);

            var response = await controller.Update(0, existingWork);

            workServiceMock.Verify(x => x.Get(0, It.IsAny<bool>()), Times.Once);
            workServiceMock.Verify(x => x.Update(existingWork), Times.Once);
            Assert.IsType<OkResult>(response);

        }

        [Fact]
        public async Task Update_NonExistingWork_ReturnsNotFound()
        {
            var workServiceMock = new Mock<IWorkService>();
            workServiceMock
                .Setup(x => x.Get(0, It.IsAny<bool>()))
                .ReturnsAsync((Work)null);

            var controller = new WorksController(workServiceMock.Object);

            var response = await controller.Update(0, new Work { Id = 0 });

            workServiceMock.Verify(x => x.Get(0, It.IsAny<bool>()), Times.Once);
            workServiceMock.Verify(x => x.Update(It.IsAny<Work>()), Times.Never);
            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public async Task Update_IdMismatch_ReturnsBadRequest()
        {
            Mock<IWorkService> workServiceMock = new Mock<IWorkService>();

            WorksController WorksController = new WorksController(workServiceMock.Object);

            var response = await WorksController.Update(0, new Work()
            {
                Id = 0
            });

            Assert.IsType<NotFoundResult>(response);
        }

    }
}
