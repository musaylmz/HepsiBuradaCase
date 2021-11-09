using MarsRoverCase.Domain.Enums;
using System;

namespace MarsRoverCase.Application.Extensions
{
    public static class RoverExtension
    {
        public static bool CheckMovementParams(this string roverMovementParams)
        {
            roverMovementParams = roverMovementParams.Trim();

            if (string.IsNullOrEmpty(roverMovementParams))
                return false;

            var roverMovementParamsArr = roverMovementParams.ToCharArray();

            foreach (var param in roverMovementParamsArr)
            {
                _ = Enum.TryParse(param.ToString(), out MovementType movement);

                if (movement == 0)
                    return false;
            }

            return true;
        }
    }
}
