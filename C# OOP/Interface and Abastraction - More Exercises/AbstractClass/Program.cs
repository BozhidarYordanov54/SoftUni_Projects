


Animal dog = new Dog();
Animal cat = new Cat();

dog.MakeSound();
cat.MakeSound();

public class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow");
    }
}
public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof");
    }
}
public abstract class Animal
{
    public abstract void MakeSound();
    
}