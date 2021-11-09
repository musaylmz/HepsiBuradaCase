using MarsRoverCase.Domain.Enums;

namespace MarsRoverCase.Domain.Models
{
    public class Position
    {
        public Position(int x, int y, DirectionType direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public DirectionType Direction { get; set; }
    }
}
