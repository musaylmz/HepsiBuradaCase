using MarsRoverCase.Domain.Enums;
using MarsRoverCase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverCase.Application.Extensions
{
    public static class PlateauExtension
    {
        /// <summary>
        /// Plato oluşturma için girilen değeri kontrol eder, uygunsa platoyu oluşturur
        /// </summary>
        /// <param name="plateauParams">Plato oluşturma parametresi</param>
        /// <returns>Plateau model</returns>
        public static PlateauModel ConvertToPlateauModel(this List<string> plateauParams)
        {
            if (plateauParams.Count != 2)
                return null;

            _ = int.TryParse(plateauParams[0], out int width);
            _ = int.TryParse(plateauParams[1], out int height);

            if (width == 0 || height == 0)
                return null;

            return new PlateauModel(width, height);
        }

        /// <summary>
        /// Aracı platoya yerleştirmek için girilen değeri kontrol eder, uygunsa yerleştirmeyi sağlar
        /// </summary>
        /// <param name="deploymentPositionParams">Araç konumlandırma parametresi</param>
        /// <returns>Position model</returns>
        public static PositionModel ConvertToPositionModel(this List<string> deploymentPositionParams)
        {
            if (deploymentPositionParams.Count != 3)
                return null;

            _ = int.TryParse(deploymentPositionParams[0], out int x);
            _ = int.TryParse(deploymentPositionParams[1], out int y);
            _ = Enum.TryParse(deploymentPositionParams[2], out DirectionType direction);

            if (x < 0 || y < 0 || direction == 0)
                return null;

            return new PositionModel(x, y, direction);
        }

        /// <summary>
        /// String değeri listeye dönüştürür
        /// </summary>
        public static List<string> ConvertToStringList(this string input)
        {
            return input.Trim()?.Split(' ').ToList();
        }
    }
}
