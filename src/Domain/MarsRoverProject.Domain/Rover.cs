using MarsRoverProject.Core.Base;
using MarsRoverProject.Core.Exceptions;
using MarsRoverProject.Domain.Rules;

namespace MarsRoverProject.Domain;

public class Rover
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public Directions Direction { get; private set; }
    public Surface Surface { get; private set; }

    public Rover(Surface surface)
    {
        ValidateRule(new SurfaceNullCheck(surface));

        X = 0;
        Y = 0;
        Direction = Directions.N;
        Surface = surface;
    }

    public Rover(int x, int y, Directions direction, Surface surface)
    {
        ValidateRule(new SurfaceNullCheck(surface));
        ValidateRule(new RoverSurfaceBordersCheck(x, y, surface));

        X = x;
        Y = y;
        Direction = direction;
        Surface = surface;
    }

    void move()
    {
        switch (Direction)
        {
            case Directions.N:
                Y++;
                break;
            case Directions.S:
                Y--;
                break;
            case Directions.E:
                X++;
                break;
            case Directions.W:
                X--;
                break;
            default:
                break;
        }

        ValidateRule(new RoverSurfaceBordersCheck(X, Y, Surface));
    }

    void rotateToRight()
    {
        switch (Direction)
        {
            case Directions.N:
                Direction = Directions.E;
                break;
            case Directions.E:
                Direction = Directions.S;
                break;
            case Directions.S:
                Direction = Directions.W;
                break;
            case Directions.W:
                Direction = Directions.N;
                break;
            default:
                break;
        }
    }
    void rotateToLeft()
    {
        switch (Direction)
        {
            case Directions.N:
                Direction = Directions.W;
                break;
            case Directions.S:
                Direction = Directions.E;
                break;
            case Directions.E:
                Direction = Directions.N;
                break;
            case Directions.W:
                Direction = Directions.S;
                break;
            default:
                break;
        }
    }


    public void MoveWith(Commands command)
    {
        switch (command)
        {
            case Commands.L:
                rotateToLeft();
                break;
            case Commands.R:
                rotateToRight();
                break;
            case Commands.M:
                move();
                break;
            default:
                break;
        }
    }

    public override string ToString() => $"{X} {Y} {Direction.ToString()}";

    void ValidateRule(IRuleCheck rule)
    {
        if (!rule.IsValid())
            throw new DomainException(rule.Message);
    }
}
