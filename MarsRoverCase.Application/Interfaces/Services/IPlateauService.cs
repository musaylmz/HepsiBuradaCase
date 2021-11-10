using MarsRoverCase.Application.Wrappers;

namespace MarsRoverCase.Application.Interfaces
{
    public interface IPlateauService
    {
        /// <summary>
        /// Platoyu oluşturur.
        /// </summary>
        BaseResponse DrawPlateau(string plateauRequest);
    }
}
