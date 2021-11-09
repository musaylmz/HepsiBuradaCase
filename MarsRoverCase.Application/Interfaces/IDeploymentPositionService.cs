using MarsRoverCase.Domain.Models;
using System.Collections.Generic;

namespace MarsRoverCase.Application.Interfaces
{
    public interface IDeploymentPositionService
    {
        BaseResponse SetPosition(Plateau plateau, List<string> deploymentPositionParams);
    }
}
