using consolidation_csharp_lesson_6.Models;

var atm = new ATM(SampleData.AccountDataset);
atm.Menu();

var petShop = PetShop.FromPetDataset(SampleData.PetDataset);
petShop.Pets[0].CelebrateBirthday();
petShop.SellPet(petShop.Pets[2]);