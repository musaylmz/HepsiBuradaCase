using System.Collections.Generic;

namespace MarsRoverCase.Application.Interfaces
{
    public interface IPlateauService
    {
        BaseResponse DrawPlateau(List<string> plateauParams);
    }
}
