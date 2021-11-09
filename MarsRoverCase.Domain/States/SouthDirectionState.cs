using MarsRoverCase.Domain.Models;

namespace MarsRoverCase.Domain.States
{
    public class SouthDirectionState : DirectionState
    {
        public SouthDirectionState(Position Position, Plateau Plateau) : base(Position, Plateau) { }

        public override DirectionState MoveLeft()
        {
            return new EastDirectionState(Position, Plateau);
        }

        public override DirectionState MoveRight()
        {
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
