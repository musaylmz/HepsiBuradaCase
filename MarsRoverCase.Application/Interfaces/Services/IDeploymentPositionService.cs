using MarsRoverCase.Application.Wrappers;
using MarsRoverCase.Domain.Models;

namespace MarsRoverCase.Application.Interfaces
{
    public interface IDeploymentPositionService
    {
        /// <summary>
        /// Aracın plato üzerine yerleştirilmesini sağlar.
        /// </summary>
        BaseResponse SetDeploymentPosition(PlateauModel plateau, string deploymentPositionRequest);
    }
}
