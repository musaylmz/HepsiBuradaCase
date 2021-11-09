using MarsRoverCase.Application.Extensions;
using MarsRoverCase.Domain.Models;
using MarsRoverCase.Infrastructure.Services;
using System.Linq;
using Xunit;

namespace MarsRoverCase.UnitTest
{
    public class PlateauTest
    {
        private readonly PlateauService _plateauService;

        public PlateauTest()
        {
            _plateauService = new PlateauService();
        }

        [Theory]
        [InlineData("5 5")]
        [InlineData("3 4")]
        [InlineData("3 3")]
        public void DrawPlateau_WhenValidParameters_ReturnSuccess(string plateauRequest)
        {
            var plateauParams = plateauRequest.ConvertToStringList();

            var result = _plateauService.DrawPlateau(plateauRequest);
            var plateau = (Plateau)result.Data;

            Assert.True(result.IsSuccess);
            Assert.Equal(plateau.Width, int.Parse(plateauParams.First()));
            Assert.Equal(plateau.Height, int.Parse(plateauParams.Last()));
            Assert.Null(result.Message);
        }

        [Theory]
        [InlineData("0 5")]
        [InlineData("5 0")]
        [InlineData("0 0")]
        public void DrawPlateau_WhenPointsIsZero_ReturnError(string plateauRequest)
        {
            var result = _plateauService.DrawPlateau(plateauRequest);

            Assert.False(result.IsSuccess);
            Assert.Null(result.Data);
            Assert.NotNull(result.Message);
        }

        [Theory]
        [InlineData("5")]
        [InlineData("5 1 3")]
        [InlineData("3 one")]
        public void DrawPlateau_WhenInvalidParams_ReturnError(string plateauRequest)
        {
            var result = _plateauService.DrawPlateau(plateauRequest);

            Assert.False(result.IsSuccess);
            Assert.Null(result.Data);
            Assert.NotNull(result.Message);
        }
    }
}
