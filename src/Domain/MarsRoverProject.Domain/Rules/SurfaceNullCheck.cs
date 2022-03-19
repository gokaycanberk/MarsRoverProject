
using MarsRoverProject.Core.Base;

namespace MarsRoverProject.Domain.Rules
{
    public class SurfaceNullCheck : IRuleCheck
    {
        Surface _surface { get; set; }
        public string Message => "Surface cannot be null!";

        public SurfaceNullCheck(Surface surface)
        {
            _surface = surface;
        }

        public bool IsValid() => _surface != null;
    }
}