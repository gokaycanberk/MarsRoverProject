
namespace MarsRoverProject.Core.Base
{
    public interface IRuleCheck
    {
        bool IsValid();
        string Message { get; }
    }
}
