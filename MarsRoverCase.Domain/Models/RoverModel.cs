using MarsRoverCase.Domain.Enums;
using MarsRoverCase.Domain.States;
using System.Collections.Generic;

namespace MarsRoverCase.Domain.Models
{
    public class RoverModel
    {
        public PlateauModel Plateau;
        public PositionModel Position;
        private DirectionState DirectionState;

        public RoverModel(PositionModel position, PlateauModel plateau)
        {
            this.Plateau = plateau;
            this.Position = position;
            this.DirectionState = DirectionStateFactory.Create(position, plateau);
        }

        public List<MovementType> Movements { get; set; }
        public void MoveStraight(out bool isOutPlateau)
        {
            this.DirectionState.MoveStraight(out isOutPlateau);
        }
        public void MoveLeft()
        {
            this.DirectionState = this.DirectionState.MoveLeft();
        }
        public void MoveRight()
        {
            this.DirectionState = this.DirectionState.MoveRight();
        }
    }

}
