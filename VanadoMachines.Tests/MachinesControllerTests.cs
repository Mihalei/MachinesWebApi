using Dapper;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using VanadoMachines.Controllers;
using VanadoMachines.Dtos;
using VanadoMachines.Models;
using VanadoMachines.Services;

namespace VanadoMachines.Tests
{
    public class MachinesControllerTests
    {
        [Fact]
        public async Task ShouldAddMachine()
        {
            //Arrange
            var fakeMachine = A.Fake<MachineDto>();
            var fakeService = A.Fake<IMachineService>();
            var controller = new MachinesController(fakeService);

            //Act
            var actionResult = await controller.AddMachine(fakeMachine);

            //Assert
            var result = actionResult as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task ShouldUpdateMachine()
        {
            //Arrange
            var fakeMachine = A.Fake<MachineDto>();
            var fakeMachineUpdate = A.Fake<Machine>();
            var fakeService = A.Fake<IMachineService>();
            var controller = new MachinesController(fakeService);

            //Act
            await controller.AddMachine(fakeMachine);
            var actionResult = await controller.UpdateMachine(fakeMachineUpdate);

            //Assert
            var result = actionResult as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task ShouldDeleteMachine()
        {
            //Arrange
            var fakeMachine = A.Fake<MachineDto>();
            int fakeId = 0;
            var fakeService = A.Fake<IMachineService>();
            var controller = new MachinesController(fakeService);

            //Act
            await controller.AddMachine(fakeMachine);
            var actionResult = await controller.DeleteMachine(fakeId);

            //Assert
            var result = actionResult as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

        }

        [Fact]
        public async Task ShouldGetMachine()
        {
            //Arrange
            var fakeMachineInfo = A.Fake<MachineInfoDto>();
            int fakeId = 0;
            var fakeService = A.Fake<IMachineService>();
            A.CallTo(() => fakeService.GetMachine(fakeId)).Returns(Task.FromResult(fakeMachineInfo));
            var controller = new MachinesController(fakeService);

            //Act
            var actionResult = await controller.GetMachine(fakeId);

            //Assert
            var result = actionResult as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.IsAssignableFrom<MachineInfoDto>(result.Value);
        }

        [Fact]
        public async Task ShouldGetAllMachines()
        {
            //Arrange
            var fakeMachinesList = A.CollectionOfDummy<Machine>(5).AsList();
            var fakeService = A.Fake<IMachineService>();
            A.CallTo(() => fakeService.GetAllMachines()).Returns(Task.FromResult(fakeMachinesList));
            var controller = new MachinesController(fakeService);

            //Act
            var actionResult = await controller.Get();

            //Assert
            var result = actionResult as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.IsAssignableFrom<List<Machine>>(result.Value);
        }

    }
}