namespace consolidation_csharp_lesson_6.Models;

public class PetShop
{
    public List<Animal> Pets { get; set; }

    public PetShop(List<Animal> pets)
    {
        Pets = pets;
    }

    public static PetShop FromPetDataset(List<PetData> petDataset)
    {
        throw new NotImplementedException();
    }

    public Animal FindPetWithName(string name)
    {
        throw new NotImplementedException();
    }

    public void AddPet(Animal pet)
    {
        throw new NotImplementedException();
    }

    public void SellPet(Animal pet)
    {
        throw new NotImplementedException();
    }
}
