
using MarsRoverProject.Core.Base;

namespace MarsRoverProject.Domain.Rules
{
    public class RoverSurfaceBordersCheck: IRuleCheck
    {
        int _x { get; set; }
        int _y { get; set; }
        Surface _surface { get; set; }
        public string Message => "Rover should be inside the surface borders!";

        public RoverSurfaceBordersCheck(int x, int y, Surface surface)
        {
            _x = x;
            _y = y;
            _surface = surface;
        }

        bool isCoordinateXValid => _x >= 0 && _x <= _surface.Height;
        bool isCoordinateYValid => _y >= 0 && _y <= _surface.Width;

        public bool IsValid() => isCoordinateXValid && isCoordinateYValid;
    }
}