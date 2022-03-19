using MarsRoverProject.Core.Base;
using MarsRoverProject.Core.Exceptions;
using MarsRoverProject.Domain.Rules;

namespace MarsRoverProject.Domain
{
    public record Surface
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Surface(int height, int width)
        {
            ValidateRule(new CoordinatesNegativeCheck(height,width));
            Height = height;
            Width = width;
        }

        void ValidateRule(IRuleCheck rule)
        {
            if (!rule.IsValid())
                throw new DomainException(rule.Message);
        }
    }
}
