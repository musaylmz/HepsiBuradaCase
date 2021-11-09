using MarsRoverCase.Application;
using MarsRoverCase.Application.Extensions;
using MarsRoverCase.Application.Interfaces;
using MarsRoverCase.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverCase.Infrastructure.Services
{
    public class PlateauService : IPlateauService
    {
        public BaseResponse DrawPlateau(List<string> plateauParams)
        {
            if (!plateauParams.CheckDrawPlateauParams())
                return BaseResponse.ReturnAsError(message: "Invalid parameters for drawing plataeu area");

            return BaseResponse.ReturnAsSuccess(new Plateau(int.Parse(plateauParams.FirstOrDefault()), int.Parse(plateauParams.LastOrDefault())));
        }
    }
}
