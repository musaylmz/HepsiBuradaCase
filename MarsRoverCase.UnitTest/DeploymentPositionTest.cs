using MarsRoverCase.Application.Extensions;
using MarsRoverCase.Domain.Models;
using MarsRoverCase.Infrastructure.Services;
using Xunit;

namespace MarsRoverCase.UnitTest
{
    public class DeploymentPositionTest
    {
        private readonly DeploymentPositionService _deploymentPositionService;

        public DeploymentPositionTest()
        {
            _deploymentPositionService = new DeploymentPositionService();
        }

        [Theory]
        [InlineData("2 4 N")]
        [InlineData("3 3 S")]
        [InlineData("1 3 S")]
        [InlineData("4 1 E")]
        public void SetPosition_WhenValidParameters_ReturnSuccess(string deploymentPositionRequest)
        {
            var deploymentPositionParams = deploymentPositionRequest.ConvertToStringList();
            var plateau = new PlateauModel(5, 5);

            var result = _deploymentPositionService.SetDeploymentPosition(plateau, deploymentPositionRequest);
            var deploymentPosition = (PositionModel)result.Data;

            Assert.True(result.IsSuccess);
            Assert.Equal(deploymentPosition.X, int.Parse(deploymentPositionParams[0]));
            Assert.Equal(deploymentPosition.Y, int.Parse(deploymentPositionParams[1]));
            Assert.Null(result.Message);
        }

        [Theory]
        [InlineData("2 N")]
        [InlineData("3 3 F")]
        [InlineData("2 1 4 S")]
        [InlineData("E")]
        public void SetPosition_WhenInvalidCoordinateParameters_ReturnError(string deploymentPositionRequest)
        {
            var plateau = new PlateauModel(5, 5);

            var result = _deploymentPositionService.SetDeploymentPosition(plateau, deploymentPositionRequest);

            Assert.False(result.IsSuccess);
            Assert.Null(result.Data);
            Assert.NotNull(result.Message);
        }

        [Theory]
        [InlineData("4 6 S")]
        [InlineData("2 7 E")]
        [InlineData("5 3 W")]
        [InlineData("6 2 N")]
        public void SetPosition_WhenOutPlateauParameters_ReturnError(string deploymentPositionRequest)
        {
            var plateau = new PlateauModel(2, 2);

            var result = _deploymentPositionService.SetDeploymentPosition(plateau, deploymentPositionRequest);

            Assert.False(result.IsSuccess);
            Assert.Null(result.Data);
            Assert.NotNull(result.Message);
        }
    }
}
