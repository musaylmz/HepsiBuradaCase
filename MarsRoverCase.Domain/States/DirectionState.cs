using MarsRoverCase.Domain.Models;

namespace MarsRoverCase.Domain.States
{
    public abstract class DirectionState
    {
        public Position Position { get; set; }
        public Plateau Plateau { get; set; }
        public DirectionState(Position position, Plateau plateau)
        {
            this.Position = position;
            this.Plateau = plateau;
        }

        public abstract void MoveStraight(out bool isOutPlateau);
        public abstract DirectionState MoveLeft();
        public abstract DirectionState MoveRight();
    }
}
