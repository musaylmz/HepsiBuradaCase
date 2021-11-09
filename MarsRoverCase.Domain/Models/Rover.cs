using MarsRoverCase.Domain.Enums;
using MarsRoverCase.Domain.States;
using System.Collections.Generic;

namespace MarsRoverCase.Domain.Models
{
    public class Rover
    {
        private DirectionState DirectionState;
        public Rover(Position position, Plateau plateau)
        {
            this.DirectionState = DirectionStateFactory.Create(position, plateau);
        }

        public Plateau Plateau { get; set; }
        public Position DeploymentPosition { get; set; }
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
