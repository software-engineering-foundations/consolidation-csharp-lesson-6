namespace consolidation_csharp_lesson_6.Models;

public class Cat : Animal
{
    public Cat(string name, int age) : base(name, age, "cat") {}

    public void Meow()
    {
        throw new NotImplementedException();
    }
}
