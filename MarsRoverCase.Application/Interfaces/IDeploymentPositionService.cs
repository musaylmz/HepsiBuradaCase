using MarsRoverCase.Domain.Models;

namespace MarsRoverCase.Application.Interfaces
{
    public interface IDeploymentPositionService
    {
        BaseResponse SetPosition(Plateau plateau, string deploymentPositionRequest);
    }
}
