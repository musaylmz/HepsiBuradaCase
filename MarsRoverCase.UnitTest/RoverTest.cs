using MarsRoverCase.Application.Extensions;
using MarsRoverCase.Domain.Enums;
using MarsRoverCase.Domain.Models;
using MarsRoverCase.Infrastructure.Services;
using System;
using System.Linq;
using Xunit;

namespace MarsRoverCase.UnitTest
{
    public class RoverTest
    {
        private readonly RoverService _roverService;

        public RoverTest()
        {
            _roverService = new RoverService();
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("MMLRT")]
        [InlineData("ALLLMM")]
        public void RoverMovement_WhenInvalidParameters_ReturnFalse(string movementRequest)
        {
            bool result = movementRequest.CheckMovementParams();

            Assert.False(result);
        }

        [Theory]
        [InlineData("RMRMMMM")]
        [InlineData("MMLMM")]
        [InlineData("LRMMMM")]
        public void RoverMovement_WhenOutPlateau_ReturnError(string movementRequest)
        {
            var plateau = new Plateau(5, 5);
            var deploymentPosition = new Position(1, 2, DirectionType.N);

            var rover = new Rover(deploymentPosition, plateau)
            {
                Movements = movementRequest.ToCharArray().Select(x => Enum.Parse<MovementType>(x.ToString())).ToList()
            };

            var result = _roverService.RoverMovement(rover);

            Assert.False(result.IsSuccess);
            Assert.Null(result.Data);
            Assert.NotNull(result.Message);
        }

        [Theory]
        [InlineData("LMLMLMLMM")]
        public void RoverMovement_WhenTaskInput1_ReturnSuccess(string movementRequest)
        {
            var plateau = new Plateau(5, 5);
            var deploymentPosition = new Position(1, 2, DirectionType.N);

            var rover = new Rover(deploymentPosition, plateau)
            {
                Movements = movementRequest.ToCharArray().Select(x => Enum.Parse<MovementType>(x.ToString())).ToList()
            };

            var result = _roverService.RoverMovement(rover);
            rover = (Rover)result.Data;

            Assert.True(result.IsSuccess);
            Assert.Null(result.Message);
            Assert.Equal(1, rover.Position.X);
            Assert.Equal(3, rover.Position.Y);
            Assert.Equal(DirectionType.N, rover.Position.Direction);
        }

        [Theory]
        [InlineData("MMRMMRMRRM")]
        public void RoverMovement_WhenTaskInput2_ReturnSuccess(string movementRequest)
        {
            var plateau = new Plateau(5, 5);
            var deploymentPosition = new Position(3, 3, DirectionType.E);

            var rover = new Rover(deploymentPosition, plateau)
            {
                Movements = movementRequest.ToCharArray().Select(x => Enum.Parse<MovementType>(x.ToString())).ToList()
            };

            var result = _roverService.RoverMovement(rover);
            rover = (Rover)result.Data;

            Assert.True(result.IsSuccess);
            Assert.Null(result.Message);
            Assert.Equal(5, rover.Position.X);
            Assert.Equal(1, rover.Position.Y);
            Assert.Equal(DirectionType.E, rover.Position.Direction);
        }
    }
}
