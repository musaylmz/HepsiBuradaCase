using MarsRoverCase.Domain.Models;

namespace MarsRoverCase.Domain.States
{
    public class EastDirectionState : DirectionState
    {
        public EastDirectionState(Position Position, Plateau Plateau) : base(Position, Plateau) { }

        public override DirectionState MoveLeft()
        {
            return new NorthDirectionState(Position, Plateau);
        }

        public override DirectionState MoveRight()
        {
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
