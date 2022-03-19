using MarsRoverProject.Core.Exceptions;
using MarsRoverProject.Domain;

try
{
    var surfaceuBorders = Console.ReadLine().Split(" ").Select(border => Convert.ToInt32(border)).AsEnumerable();
    var roverInformation = Console.ReadLine().Split(" ").AsEnumerable();
    var commands = Console.ReadLine().ToUpper();

    var height = surfaceuBorders.ElementAt(0);
    var width = surfaceuBorders.ElementAt(1);
    var surface = new Surface(height, width);

    var coordinateX = Convert.ToInt32(roverInformation.ElementAt(0));
    var coordinateY = Convert.ToInt32(roverInformation.ElementAt(1));
    Directions direction;
    Enum.TryParse<Directions>(roverInformation.ElementAt(2).ToUpper(), false, out direction);

    var rover = new Rover(coordinateX, coordinateY, direction, surface);
    foreach (var commandStr in commands)
    {
        Commands command;
        Enum.TryParse<Commands>(commandStr.ToString(), false, out command);
        rover.MoveWith(command);
    }
    Console.WriteLine(rover.ToString());
}
catch (DomainException exception)
{
    Console.WriteLine(exception.ExceptionMessage);
}
catch (System.Exception exception)
{
    Console.WriteLine(exception.Message);
}