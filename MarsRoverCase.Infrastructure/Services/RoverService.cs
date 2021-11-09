using MarsRoverCase.Application;
using MarsRoverCase.Application.Interfaces;
using MarsRoverCase.Domain.Enums;
using MarsRoverCase.Domain.Models;
using System;

namespace MarsRoverCase.Infrastructure.Services
{
    public class RoverService : IRoverService
    {
        public BaseResponse RoverMovement(Rover rover)
        {
            foreach (var movingDirection in rover.Movements)
            {
                bool isOutPlateau = false;
                GetLastPosition(rover, out string lastPosition);

                switch (movingDirection)
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

                if (isOutPlateau)
                    return BaseResponse.ReturnAsError(message: $"Rover cannot move out of the plateau! Last position : {lastPosition}");
            }

            return BaseResponse.ReturnAsSuccess(rover);
        }

        private static void GetLastPosition(Rover rover, out string lastPosition)
        {
            lastPosition = $"{rover.DeploymentPosition.X} {rover.DeploymentPosition.Y} {rover.DeploymentPosition.Direction}";
        }
    }
}
