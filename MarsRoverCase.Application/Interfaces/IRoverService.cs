using MarsRoverCase.Domain.Models;

namespace MarsRoverCase.Application.Interfaces
{
    public interface IRoverService
    {
        BaseResponse RoverMovement(Rover rover);
    }
}
