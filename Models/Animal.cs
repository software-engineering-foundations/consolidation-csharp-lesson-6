namespace consolidation_csharp_lesson_6.Models;

public abstract class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Species { get; set; }

    public static Animal CreateAnimal(string name, int age, string species)
    {
        switch (species)
        {
            case "dog":
                return new Dog(name, age);
            case "cat":
                return new Cat(name, age);
            default:
                throw new NotImplementedException();
        }
    }

    public Animal(string name, int age, string species) {
        Name = name;
        Age = age;
        Species = species;
    }

    public override string ToString()
    {
        throw new NotImplementedException();
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }
        return GetType().Equals(obj.GetType()) && Equals((Animal)obj);
    }

    public bool Equals(Animal other)
    {
        throw new NotImplementedException();
    }

    public void CelebrateBirthday()
    {
        throw new NotImplementedException();
    }
}