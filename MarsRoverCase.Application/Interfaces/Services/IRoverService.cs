using MarsRoverCase.Application.Wrappers;
using MarsRoverCase.Domain.Models;

namespace MarsRoverCase.Application.Interfaces
{
    public interface IRoverService
    {
        /// <summary>
        /// Aracın plato üzerinde hareketini gerçekleştirir.
        /// </summary>
        BaseResponse MoveRover(RoverModel rover);
    }
}
