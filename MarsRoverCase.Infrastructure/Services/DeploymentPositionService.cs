using MarsRoverCase.Application.Extensions;
using MarsRoverCase.Application.Interfaces;
using MarsRoverCase.Application.Wrappers;
using MarsRoverCase.Domain.Models;

namespace MarsRoverCase.Infrastructure.Services
{
    public class DeploymentPositionService : IDeploymentPositionService
    {
        /// <summary>
        /// Aracın plato üzerine yerleştirilmesini sağlar.
        /// </summary>
        public BaseResponse SetDeploymentPosition(PlateauModel plateau, string deploymentPositionRequest)
        {
            var deploymentPositionParams = deploymentPositionRequest.ConvertToStringList();

            var position = deploymentPositionParams.ConvertToPositionModel();

            if (position == null)
                return BaseResponse.ReturnAsError(message: "Invalid parameters for rover deployment position on plateau");

            if (!CheckDeploymentPosition(plateau, position))
                return BaseResponse.ReturnAsError(message: "Rover must be positioned in the plateau");

            return BaseResponse.ReturnAsSuccess(position);
        }

        #region Private Methods

        /// <summary>
        /// Aracın plato üzerine yerleştirilmesi için platoya göre kontrolünü yapar.
        /// </summary>
        private static bool CheckDeploymentPosition(PlateauModel plateau, PositionModel position)
        {
            if (plateau.Width < position.X || plateau.Height < position.Y || position.X < 0 || position.Y < 0)
                return false;

            return true;
        }

        #endregion
    }
}
