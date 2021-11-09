using MarsRoverCase.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverCase.Application.Extensions
{
    public static class PlateauExtension
    {
        public static bool CheckDrawPlateauParams(this List<string> plateauParams)
        {
            if (plateauParams.Count != 2)
                return false;

            _ = int.TryParse(plateauParams[0], out int width);
            _ = int.TryParse(plateauParams[1], out int height);

            if (width == 0 || height == 0)
                return false;

            return true;
        }

        public static bool CheckDeploymentPositionParams(this List<string> deploymentPositionParams)
        {
            if (deploymentPositionParams.Count != 3)
                return false;

            _ = int.TryParse(deploymentPositionParams[0], out int x);
            _ = int.TryParse(deploymentPositionParams[1], out int y);
            _ = Enum.TryParse(deploymentPositionParams[2], out DirectionType direction);

            if (x < 0 || y < 0 || direction == 0)
                return false;

            return true;
        }

        public static List<string> ConvertToStringList(this string item)
        {
            return item.Trim()?.Split(' ').ToList();
        }
    }
}
