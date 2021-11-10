using MarsRoverCase.Domain.Enums;
using MarsRoverCase.Domain.States;
using System.Collections.Generic;

namespace MarsRoverCase.Domain.Models
{
    public class Rover
    {
        public Plateau Plateau;
        public Position DeploymentPosition;
        private DirectionState DirectionState;

        public Rover(Position position, Plateau plateau)
        {
            this.Plateau = plateau;
            this.DeploymentPosition = position;
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
