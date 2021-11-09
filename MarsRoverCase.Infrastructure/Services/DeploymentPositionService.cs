using MarsRoverCase.Application;
using MarsRoverCase.Application.Extensions;
using MarsRoverCase.Application.Interfaces;
using MarsRoverCase.Domain.Enums;
using MarsRoverCase.Domain.Models;
using System;
using System.Collections.Generic;

namespace MarsRoverCase.Infrastructure.Services
{
    public class DeploymentPositionService : IDeploymentPositionService
    {
        public BaseResponse SetPosition(Plateau plateau, List<string> deploymentPositionParams)
        {
            if (!deploymentPositionParams.CheckDeploymentPositionParams())
                return BaseResponse.ReturnAsError(message: "Invalid parameters for deployment point on plateau");

            Position position = new Position(int.Parse(deploymentPositionParams[0]), int.Parse(deploymentPositionParams[1]), (DirectionType)Enum.Parse(typeof(DirectionType), deploymentPositionParams[2]));

            if (!CheckDeploymentPosition(plateau, position))
                return BaseResponse.ReturnAsError(message: "Rover can't located on plateau.");

            return BaseResponse.ReturnAsSuccess(position);
        }

        private static bool CheckDeploymentPosition(Plateau plateau, Position position)
        {
            if (plateau.Width < position.X || plateau.Height < position.Y || position.X < 0 || position.Y < 0)
                return false;

            return true;
        }
    }
}
