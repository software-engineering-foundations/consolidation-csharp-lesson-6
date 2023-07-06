namespace consolidation_csharp_lesson_6.Models;

public class Dog : Animal
{
    public Dog(string name, int age) : base(name, age, "dog") {}

    public void Woof()
    {
        throw new NotImplementedException();
    }
}
