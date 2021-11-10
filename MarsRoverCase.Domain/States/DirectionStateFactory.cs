using MarsRoverCase.Domain.Enums;
using MarsRoverCase.Domain.Models;
using System;

namespace MarsRoverCase.Domain.States
{
    public class DirectionStateFactory
    {
        public static DirectionState Create(PositionModel position, PlateauModel plateau)
        {
            return position.Direction switch
            {
                DirectionType.N => new NorthDirectionState(position, plateau),
                DirectionType.E => new EastDirectionState(position, plateau),
                DirectionType.S => new SouthDirectionState(position, plateau),
                DirectionType.W => new WestDirectionState(position, plateau),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
    }
}
