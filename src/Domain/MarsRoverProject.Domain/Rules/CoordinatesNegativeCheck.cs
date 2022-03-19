using MarsRoverProject.Core.Base;

namespace MarsRoverProject.Domain.Rules
{
    public class CoordinatesNegativeCheck : IRuleCheck
    {
        int _x { get; set; }
        int _y { get; set; }
        public string Message => "Coordinates X and Y cannot be negative or zero!";

        public CoordinatesNegativeCheck(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public bool IsValid() => _x > 0 && _y > 0;
    }
}