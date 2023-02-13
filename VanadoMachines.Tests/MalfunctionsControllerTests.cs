using Dapper;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanadoMachines.Controllers;
using VanadoMachines.Dtos;
using VanadoMachines.Models;
using VanadoMachines.Services;

namespace VanadoMachines.Tests
{
    public class MalfunctionsControllerTests
    {
        [Fact]
        public async Task ShouldAddMalfunction()
        {
            //Arrange
            var fakeMalfunction = A.Fake<MalfunctionDto>();
            var fakeService = A.Fake<IMalfunctionService>();
            var controller = new MalfunctionsController(fakeService);

            //Act
            var actionResult = await controller.AddMalfunction(fakeMalfunction);

            //Assert
            var result = actionResult as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task ShouldUpdateMalfunction()
        {
            //Arrange
            var fakeMalfunction = A.Fake<MalfunctionDto>();
            var fakeMalfunctionUpdate = A.Fake<Malfunction>();
            var fakeService = A.Fake<IMalfunctionService>();
            var controller = new MalfunctionsController(fakeService);

            //Act
            await controller.AddMalfunction(fakeMalfunction);
            var actionResult = await controller.UpdateMalfunction(fakeMalfunctionUpdate);

            //Assert
            var result = actionResult as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task ShouldDeleteMalfunction()
        {
            //Arrange
            var fakeMalfunction = A.Fake<MalfunctionDto>();
            var fakeId = 0;
            var fakeService = A.Fake<IMalfunctionService>();
            var controller = new MalfunctionsController(fakeService);

            //Act
            await controller.AddMalfunction(fakeMalfunction);
            var actionResult = await controller.DeleteMalfunction(fakeId);

            //Assert
            var result = actionResult as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task ShouldGetMalfunction()
        {
            //Arrange
            var fakeMalfunction = A.Fake<Malfunction>();
            var fakeId = 0;
            var fakeService = A.Fake<IMalfunctionService>();
            A.CallTo(() => fakeService.GetMalfunction(fakeId)).Returns(Task.FromResult(fakeMalfunction));
            var controller = new MalfunctionsController(fakeService);

            //Act
            var actionResult = await controller.GetMalfunction(fakeId);

            //Assert
            var result = actionResult as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.IsAssignableFrom<Malfunction>(result.Value);
        }

        [Fact]
        public async Task ShouldGetMalfunctions()
        {
            //Arrange
            var fakeMalfunction = A.CollectionOfDummy<Malfunction>(5).AsList();
            var fakeService = A.Fake<IMalfunctionService>();
            A.CallTo(() => fakeService.GetAllMalfunctions(0,5)).Returns(Task.FromResult(fakeMalfunction));
            var controller = new MalfunctionsController(fakeService);

            //Act
            var queryParams = new QueryParameters
            {
                Offset = 0,
                Count = 5
            };
            var actionResult = await controller.Get(queryParams);

            //Assert
            var result = actionResult as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.IsAssignableFrom<List<Malfunction>>(result.Value);
        }

       
    }
}
