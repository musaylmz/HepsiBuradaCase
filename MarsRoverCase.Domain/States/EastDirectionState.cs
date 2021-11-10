using MarsRoverCase.Domain.Enums;
using MarsRoverCase.Domain.Models;

namespace MarsRoverCase.Domain.States
{
    public class EastDirectionState : DirectionState
    {
        public EastDirectionState(PositionModel Position, PlateauModel Plateau) : base(Position, Plateau) { }

        public override DirectionState MoveLeft()
        {
            Position.Direction = DirectionType.N;
            return new NorthDirectionState(Position, Plateau);
        }

        public override DirectionState MoveRight()
        {
            Position.Direction = DirectionType.S;
            return new SouthDirectionState(Position, Plateau);
        }

        public override void MoveStraight(out bool isOutPlateau)
        {
            if (Position.X + 1 <= Plateau.Width && Position.X + 1 >= 0)
            {
                Position.X += 1;
                isOutPlateau = false;
            }
            else
                isOutPlateau = true;
        }
    }
}
