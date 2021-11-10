using MarsRoverCase.Domain.Enums;
using System;
using System.Collections.Generic;

namespace MarsRoverCase.Application.Extensions
{
    public static class RoverExtension
    {
        /// <summary>
        /// Araç hareketi için girilen değeri kontrol eder, uygunsa hareket listesi oluşturur
        /// </summary>
        /// <param name="roverMovementParams">Araç hareket parametresi</param>
        /// <returns>Rover hareket listesi</returns>
        public static List<MovementType> ConvertToMovementTypes(this string roverMovementParams)
        {
            roverMovementParams = roverMovementParams.Trim();

            if (string.IsNullOrEmpty(roverMovementParams))
                return null;

            var movementTypes = new List<MovementType>();

            var roverMovementParamsArr = roverMovementParams.ToCharArray();

            foreach (var param in roverMovementParamsArr)
            {
                _ = Enum.TryParse(param.ToString(), out MovementType movement);

                if (movement == 0)
                    return null;

                movementTypes.Add(movement);
            }

            return movementTypes;
        }
    }
}
