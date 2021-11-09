using MarsRoverCase.Domain.Models;

namespace MarsRoverCase.Domain.States
{
    public class WestDirectionState : DirectionState
    {
        public WestDirectionState(Position Position, Plateau Plateau) : base(Position, Plateau) { }

        public override DirectionState MoveLeft()
        {
            return new SouthDirectionState(Position, Plateau);
        }

        public override DirectionState MoveRight()
        {
            return new NorthDirectionState(Position, Plateau);
        }

        public override void MoveStraight(out bool isOutPlateau)
        {
            if (Position.X - 1 <= Plateau.Width && Position.X - 1 >= 0)
            {
                Position.X -= 1;
                isOutPlateau = false;
            }
            else
                isOutPlateau = true;
        }
    }
}
