using MarsRoverCase.Domain.Models;

namespace MarsRoverCase.Domain.States
{
    public abstract class DirectionState
    {
        public PositionModel Position { get; set; }
        public PlateauModel Plateau { get; set; }
        public DirectionState(PositionModel position, PlateauModel plateau)
        {
            this.Position = position;
            this.Plateau = plateau;
        }

        public abstract void MoveStraight(out bool isOutPlateau);
        public abstract DirectionState MoveLeft();
        public abstract DirectionState MoveRight();
    }
}
