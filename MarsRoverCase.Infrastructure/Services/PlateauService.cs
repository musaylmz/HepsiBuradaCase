using MarsRoverCase.Application.Extensions;
using MarsRoverCase.Application.Interfaces;
using MarsRoverCase.Application.Wrappers;

namespace MarsRoverCase.Infrastructure.Services
{
    public class PlateauService : IPlateauService
    {
        /// <summary>
        /// Platoyu oluşturur.
        /// </summary>
        public BaseResponse DrawPlateau(string plateauRequest)
        {
            var plateauParams = plateauRequest.ConvertToStringList();

            var plateau = plateauParams.ConvertToPlateauModel();

            if (plateau == null)
                return BaseResponse.ReturnAsError(message: "Invalid parameters for drawing plataeu area");

            return BaseResponse.ReturnAsSuccess(plateau);
        }
    }
}
