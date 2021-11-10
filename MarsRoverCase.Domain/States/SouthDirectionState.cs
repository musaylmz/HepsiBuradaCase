using MarsRoverCase.Domain.Enums;
using MarsRoverCase.Domain.Models;

namespace MarsRoverCase.Domain.States
{
    public class SouthDirectionState : DirectionState
    {
        public SouthDirectionState(PositionModel Position, PlateauModel Plateau) : base(Position, Plateau) { }

        public override DirectionState MoveLeft()
        {
            Position.Direction = DirectionType.E;
            return new EastDirectionState(Position, Plateau);
        }

        public override DirectionState MoveRight()
        {
            Position.Direction = DirectionType.W;
            return new WestDirectionState(Position, Plateau);
        }

        public override void MoveStraight(out bool isOutPlateau)
        {
            if (Position.Y - 1 <= Plateau.Height && Position.Y - 1 >= 0)
            {
                Position.Y -= 1;
                isOutPlateau = false;
            }
            else
                isOutPlateau = true;
        }
    }
}
