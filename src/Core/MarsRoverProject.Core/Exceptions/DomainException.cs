namespace MarsRoverProject.Core.Exceptions
{
    public class DomainException : BaseExceptions
    {
        public DomainException(string message)
        {
            ExceptionMessage = message;
            ExceptionId = "f4927718-8a18-4bdc-a72d-042b1c0709c4";
        }

        public override string ExceptionId { get; set; }
        public override string ExceptionMessage { get; set; }
    }
}
