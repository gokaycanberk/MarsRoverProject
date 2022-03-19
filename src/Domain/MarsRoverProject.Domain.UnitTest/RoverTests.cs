using MarsRoverProject.Core.Exceptions;
using Xunit;

namespace MarsRoverProject.Domain.UnitTest;

public class RoverTests
{

    [Fact]
    public void Rover_Should_Throw_Exception_When_Null_Surface_Constructor()
    {
        Assert.Throws<DomainException>(() => new Rover(null));
    }

    [Fact]
    public void Rover_Should_Throw_Exception_When_Null_Surface_Constructor_With_Coordinates()
    {
        Assert.Throws<DomainException>(() => new Rover(10, 10, Directions.W, null));
    }

    [Fact]
    public void Rover_Should_Return_Rover_When_Constructed_With_Only_Surface_Successfully()
    {
        var surface = new Surface(10, 10);
        var rover = new Rover(surface);

        Assert.Equal(0, rover.X);
        Assert.Equal(0, rover.Y);
        Assert.Equal(Directions.N, rover.Direction);
    }

    [Theory]
    [InlineData(int.MinValue, int.MinValue, 10, 10)]
    [InlineData(int.MinValue, 5, 10, 10)]
    [InlineData(3, int.MinValue, 10, 10)]
    [InlineData(3, 100, 10, 10)]
    [InlineData(11, 5, 10, 10)]
    [InlineData(11, 11, 10, 10)]
    public void Rover_Should_Throw_Exception_When_Coordinates_Not_In_Surface_Borders(int x, int y, int height, int width)
    {
        var surface = new Surface(height, width);

        Assert.Throws<DomainException>(() => new Rover(x, y, Directions.N, surface));
    }

    [Fact]
    public void Rover_Should_Return_Rover_When_Constructed_With_Coordinates_And_Surface_Successfully()
    {
        var surface = new Surface(10, 10);
        var rover = new Rover(5, 5, Directions.S, surface);

        Assert.Equal(5, rover.X);
        Assert.Equal(5, rover.Y);
        Assert.Equal(Directions.S, Directions.S);
    }

    [Theory]
    [InlineData(Directions.N, Directions.W)]
    [InlineData(Directions.S, Directions.E)]
    [InlineData(Directions.E, Directions.N)]
    [InlineData(Directions.W, Directions.S)]
    public void Rover_Should_Rotate_To_Left_When_Command_Is_Left(Directions input, Directions expected)
    {
        var surface = new Surface(10, 10);
        var rover = new Rover(5, 5, input, surface);

        rover.MoveWith(Commands.L);
        Assert.Equal(expected, rover.Direction);
    }

    [Theory]
    [InlineData(Directions.N, Directions.E)]
    [InlineData(Directions.S, Directions.W)]
    [InlineData(Directions.E, Directions.S)]
    [InlineData(Directions.W, Directions.N)]
    public void Rover_Should_Rotate_To_Right_When_Command_Is_Right(Directions input, Directions expected)
    {
        var surface = new Surface(10, 10);
        var rover = new Rover(5, 5, input, surface);

        rover.MoveWith(Commands.R);
        Assert.Equal(expected, rover.Direction);
    }
}
