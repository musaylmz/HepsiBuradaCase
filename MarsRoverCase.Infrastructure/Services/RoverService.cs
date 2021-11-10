using MarsRoverCase.Application.Interfaces;
using MarsRoverCase.Application.Wrappers;
using MarsRoverCase.Domain.Enums;
using MarsRoverCase.Domain.Models;
using System;

namespace MarsRoverCase.Infrastructure.Services
{
    public class RoverService : IRoverService
    {
        /// <summary>
        /// Aracın plato üzerinde hareketini gerçekleştirir.
        /// </summary>
        public BaseResponse MoveRover(RoverModel rover)
        {
            foreach (var movement in rover.Movements)
            {
                bool isOutPlateau = false;
                GetLastPosition(rover, out string lastPosition);

                switch (movement)
                {
                    case MovementType.L:
                        rover.MoveLeft();
                        break;
                    case MovementType.R:
                        rover.MoveRight();
                        break;
                    case MovementType.M:
                        rover.MoveStraight(out isOutPlateau);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                // Araç plato dışına çıkarsa hareket sonlandırılır ve son konum bilgisi döndürülür
                if (isOutPlateau)
                    return BaseResponse.ReturnAsError(message: $"Rover cannot move outside the plateau! Last position : {lastPosition}");
            }

            return BaseResponse.ReturnAsSuccess(rover);
        }


        #region Private Methods

        /// <summary>
        /// Aracın son konum bilgisini döndürür.
        /// </summary>
        private static void GetLastPosition(RoverModel rover, out string lastPosition)
        {
            lastPosition = $"{rover.Position.X} {rover.Position.Y} {rover.Position.Direction}";
        }

        #endregion
    }
}
