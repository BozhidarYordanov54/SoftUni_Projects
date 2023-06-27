
Car car = new Car();
Plane plane = new Plane();

car.Move();
plane.Move();

public class Plane : IMovevable
{
    public void Move()
    {
        Console.WriteLine("Plane is flying.");
    }
}

public class Car : IMovevable
{
    public void Move()
    {
        Console.WriteLine("Car is moving.");
    }
}

public interface IMovevable
{
    void Move();
}