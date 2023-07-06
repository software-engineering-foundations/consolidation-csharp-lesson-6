using System.Reflection.Metadata;
using consolidation_csharp_lesson_6.Models;
using FluentAssertions;
using Xunit;

namespace consolidation_csharp_lesson_6.Tests;

public class TestChallenges
{
    [Theory]
    [InlineData("12169553", "Alice Smith", 50, 30, 80)]
    [InlineData("82309802", "Bob Jones", 200, 12, 212)]
    public void BankAccount_WithValidDeposit_ShouldUpdateBalance(
        string accountNumber, string customerName, float initialBalance, float depositAmount, float finalBalance)
    {
        // Arrange
        var bankAccount = new BankAccount { AccountNumber = accountNumber, CustomerName = customerName, Balance = initialBalance };

        // Act
        bankAccount.Deposit(depositAmount);

        // Assert
        Assert.Equal(finalBalance, bankAccount.Balance);
    }

    [Theory]
    [InlineData("12169553", "Alice Smith", 50, 0, "We only accept deposits of positive amounts.")]
    [InlineData("82309802", "Bob Jones", 200, -10, "We only accept deposits of positive amounts.")]
    public void BankAccount_WithInvalidDeposit_ShouldRaiseError(
        string accountNumber, string customerName, float initialBalance, float depositAmount, string expectedErrorMessage)
    {
        // Arrange
        var bankAccount = new BankAccount { AccountNumber = accountNumber, CustomerName = customerName, Balance = initialBalance };

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => bankAccount.Deposit(depositAmount));
        Assert.Equal(expectedErrorMessage, exception.Message);
        Assert.Equal(initialBalance, bankAccount.Balance);
    }

    [Theory]
    [InlineData("12169553", "Alice Smith", 50, 30, 20)]
    [InlineData("82309802", "Bob Jones", 200, 12, 188)]
    public void BankAccount_WithValidWithdrawal_ShouldUpdateBalance(
        string accountNumber, string customerName, float initialBalance, float withdrawalAmount, float finalBalance)
    {
        // Arrange
        var bankAccount = new BankAccount { AccountNumber = accountNumber, CustomerName = customerName, Balance = initialBalance };

        // Act
        bankAccount.Withdraw(withdrawalAmount);

        // Assert
        Assert.Equal(finalBalance, bankAccount.Balance);
    }

    [Theory]
    [InlineData("12169553", "Alice Smith", 50, 0, "We only accept withdrawals of positive amounts.")]
    [InlineData("82309802", "Bob Jones", 200, -10, "We only accept withdrawals of positive amounts.")]
    [InlineData("38987723", "Charlie Taylor", 100, 1000000, "You cannot withdraw more than you have in your account.")]
    public void BankAccount_WithInvalidWithdrawal_ShouldRaiseErrorAndNotAffectBalance(
        string accountNumber, string customerName, float initialBalance, float withdrawalAmount, string expectedErrorMessage)
    {
        // Arrange
        var bankAccount = new BankAccount { AccountNumber = accountNumber, CustomerName = customerName, Balance = initialBalance };

        // Act and Assert

        Exception exception = withdrawalAmount <= 0
            ? Assert.Throws<ArgumentOutOfRangeException>(() => bankAccount.Withdraw(withdrawalAmount))
            : Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(withdrawalAmount));

        Assert.Equal(expectedErrorMessage, exception.Message);
        Assert.Equal(initialBalance, bankAccount.Balance);
    }

    [Theory]
    [InlineData("12169553", 30, "Your deposit was successful. Your new balance is 80.0. Thank you!")]
    [InlineData("82309802", 12, "Your deposit was successful. Your new balance is 212.0. Thank you!")]
    public void ATM_ProcessDeposit_WithValidInput_ShouldGenerateSuccessMessage(
        string accountNumber, float depositAmountInput, string expectedSuccessMessage)
    {
        // Arrange
        var atm = new ATM(SampleData.AccountDataset);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        atm.ProcessDeposit(accountNumber, depositAmountInput);

        // Assert
        var output = stringWriter.ToString().ReplaceLineEndings("");
        Assert.Equal(expectedSuccessMessage, output);
    }

    [Theory]
    [InlineData("82309802", 0, "We only accept deposits of positive amounts.")]
    [InlineData("38987723", -20, "We only accept deposits of positive amounts.")]
    public void ATM_ProcessDeposit_WithInvalidInput_ShouldGenerateErrorMessage(
        string accountNumber, float depositAmountInput, string expectedErrorMessage)
    {
        // Arrange
        var atm = new ATM(SampleData.AccountDataset);

        // Act
        var exception = Assert.Throws<InvalidOperationException>(() =>
            atm.ProcessDeposit(accountNumber, depositAmountInput));

        // Assert
        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Theory]
    [InlineData("12169553", 30, "Your withdrawal was successful. Your new balance is 20.0. Thank you!")]
    [InlineData("82309802", 12, "Your withdrawal was successful. Your new balance is 188.0. Thank you!")]
    public void ATM_ProcessWithdrawal_WithValidInput_ShouldGenerateSuccessMessage(
        string accountNumber, float withdrawalAmountInput, string expectedSuccessMessage)
    {
        // Arrange
        var atm = new ATM(SampleData.AccountDataset);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        atm.ProcessWithdrawal(accountNumber, withdrawalAmountInput);

        // Assert
        var output = stringWriter.ToString().ReplaceLineEndings("");
        Assert.Equal(expectedSuccessMessage, output);
    }

    [Theory]
    [InlineData("82309802", 0, "We only accept withdrawals of positive amounts.")]
    [InlineData("38987723", -20, "We only accept withdrawals of positive amounts.")]
    [InlineData("32605081", 1000000, "You cannot withdraw more than you have in your account.")]
    public void ATM_ProcessWithdrawal_WithInvalidInput_ShouldGenerateErrorMessage(
        string accountNumber, float withdrawalAmountInput, string expectedErrorMessage)
    {
        // Arrange
        var atm = new ATM(SampleData.AccountDataset);

        // Act and Assert
        Exception exception = Assert.Throws<InvalidOperationException>(() => atm.ProcessWithdrawal(accountNumber, withdrawalAmountInput));

        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Theory]
    [InlineData("Spot", 5, "dog")]
    [InlineData("Fluffy", 16, "cat")]
    public void Animal_RepresentsAsString(
        string name, int age, string species)
    {
        // Arrange
        Animal animal = Animal.CreateAnimal(name, age, species);

        // Act
        string animalString = animal.ToString();

        // Assert
        Assert.Equal($"{name}, {age} ({species})", animalString);
    }

    [Theory]
    [InlineData("Spot", 5, "dog", "Spot", 5, "dog", true)]
    [InlineData("Spot", 5, "dog", "Fido", 9, "dog", false)]
    public void AnimalEqualityTests(
        string name1, int age1, string species1,
        string name2, int age2, string species2, bool shouldBeEqual)
    {
        var animal1 = Animal.CreateAnimal(name1, age1, species1);
        var animal2 = Animal.CreateAnimal(name2, age2, species2);
        bool isEqual = animal1.Equals(animal2);
        Assert.Equal(shouldBeEqual, isEqual);
    }

    [Theory]
    [InlineData("Spot", 5, "dog", "It's Spot's birthday.")]
    [InlineData("Fluffy", 16, "cat", "It's Fluffy's birthday.")]
    public void TestAnimalCelebrateBirthday(string name, int age, string species, string birthdayMessage)
    {
        // Arrange
        var animal = Animal.CreateAnimal(name, age, species);
        var mockStdOut = new StringWriter();
        Console.SetOut(mockStdOut);

        // Act
        animal.CelebrateBirthday();

        // Assert
        Assert.Equal(age + 1, animal.Age);

        var outputtedLines = mockStdOut.ToString().ReplaceLineEndings("");
        Assert.Equal(birthdayMessage, outputtedLines);
    }

    [Theory]
    [InlineData("Spot", 5, "Spot says woof!")]
    [InlineData("Fido", 9, "Fido says woof!")]
    public void TestDogWoof(string name, int age, string woofMessage)
    {
        // Arrange
        var dog = new Dog(name, age);
        var mockStdOut = new StringWriter();
        Console.SetOut(mockStdOut);

        // Act
        dog.Woof();

        // Assert
        var outputtedLines = mockStdOut.ToString().ReplaceLineEndings("");
        Assert.Equal(woofMessage, outputtedLines);
    }

    [Theory]
    [InlineData("Spot", 5, "Spot says meow!")]
    [InlineData("Fido", 9, "Fido says meow!")]
    public void TestCatMeow(string name, int age, string woofMessage)
    {
        // Arrange
        var cat = new Cat(name, age);
        var mockStdOut = new StringWriter();
        Console.SetOut(mockStdOut);

        // Act
        cat.Meow();

        // Assert
        var outputtedLines = mockStdOut.ToString().ReplaceLineEndings("");
        Assert.Equal(woofMessage, outputtedLines);
    }

    public static object[] PetListInit = new object[]
    {
        new object[]
        {
            new List<PetData>
            {
                new PetData { Name = "Spot", Age = 5, Species = "dog" },
                new PetData { Name = "Fluffy", Age = 16, Species = "cat" },
                new PetData { Name = "Ginger", Age = 8, Species = "cat" }
            },
            new List<Animal>
            {
                new Dog("Spot", 5),
                new Cat("Fluffy", 16),
                new Cat("Ginger", 8)
            }
        },
        new object[]
        {
            new List<PetData>
            {
                new PetData { Name = "Buddy", Age = 3, Species = "dog" },
                new PetData { Name = "Fido", Age = 9, Species = "dog" }
            },
            new List<Animal>
            {
                new Dog("Buddy", 3),
                new Dog("Fido", 9)
            }
        }
    };

    [Theory]
    [MemberData(nameof(PetListInit))]
    public void TestPetShopFromPetDataset(List<PetData> petDataset, List<Animal> expectedPets)
    {
        // Arrange
        PetShop petShop = PetShop.FromPetDataset(petDataset);

        // Assert
        expectedPets.Should().BeEquivalentTo(petShop.Pets);
    }

    public static object[] FindPetNameExpected = new object[]
    {
        new object[]
        {
            new PetShop(new List<Animal>
            {
                new Dog("Spot", 5),
                new Cat("Fluffy", 16),
                new Cat("Ginger", 8)
            }),
            "Ginger",
            new Cat("Ginger", 8)
        },
        new object[]
        {
            new PetShop(new List<Animal>
            {
                new Dog("Buddy", 3),
                new Dog("Fido", 9)
            }),
            "Fido",
            new Dog("Fido", 9)
        }
    };

    [Theory]
    [MemberData(nameof(FindPetNameExpected))]
    public void TestPetShopFindPetWithNameWherePetInShop(PetShop petShop, string searchName, Animal expectedPet)
    {
        // Act
        Animal pet = petShop.FindPetWithName(searchName);

        // Assert
        pet.Should().Be(expectedPet);
    }

    public static object[] FindPetNameNotExpected = new object[]
    {
        new object[]
        {
            new PetShop(new List<Animal>
            {
                new Dog("Spot", 5),
                new Cat("Fluffy", 16)
            }),
            "Ginger",
            "No pets called Ginger found in our shop."
        },
        new object[]
        {
            new PetShop(new List<Animal>
            {
                new Dog("Buddy", 3),
                new Dog("Fido", 9)
            }),
            "Nemo",
            "No pets called Nemo found in our shop."
        }
    };

    [Theory]
    [MemberData(nameof(FindPetNameNotExpected))]
    public void TestPetShopFindPetWithNameWherePetNotInShop(PetShop petShop, string searchName, string expectedErrorMessage)
    {
        // Act
        Exception exception = Assert.Throws<InvalidOperationException>(() => petShop.FindPetWithName(searchName));

        // Assert
        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    public static object[] AddPetExpected = new object[]
    {
        new object[]
        {
            new PetShop(new List<Animal>
            {
                new Dog("Spot", 5),
                new Cat("Fluffy", 16)
            }),
            new Cat("Ginger", 8)
        },
        new object[]
        {
            new PetShop(new List<Animal>
            {
                new Dog("Buddy", 3),
                new Dog("Fido", 9)
            }),
            Animal.CreateAnimal("Nemo", 1, "cat")
        }
    };

    [Theory]
    [MemberData(nameof(AddPetExpected))]
    public void TestPetShopAddPet(PetShop petShop, Animal pet)
    {
        // Arrange
        int originalPetCount = petShop.Pets.Count;

        // Act
        petShop.AddPet(pet);

        // Assert
        Assert.Equal(originalPetCount + 1, petShop.Pets.Count);
        Assert.Contains(pet, petShop.Pets);
    }

    public static object[] SellPetExpected = new object[]
    {
        new object[]
        {
            new PetShop(new List<Animal>
            {
                new Dog("Spot", 5),
                new Cat("Ginger", 8)
            }),
            new Cat("Ginger", 8)
        },
        new object[]
        {
            new PetShop(new List<Animal>
            {
                new Dog("Buddy", 3),
                new Dog("Fido", 9)
            }),
            new Dog("Fido", 9)
        }
    };

    [Theory]
    [MemberData(nameof(SellPetExpected))]
    public void TestPetShopSellPet(PetShop petShop, Animal pet)
    {
        // Arrange
        int originalPetCount = petShop.Pets.Count;

        // Act
        petShop.SellPet(pet);

        // Assert
        Assert.Equal(originalPetCount - 1, petShop.Pets.Count);
        Assert.DoesNotContain(pet, petShop.Pets);
    }

    public static object[] SellPetNotExpected = new object[]
    {
        new object[]
        {
            new PetShop(new List<Animal>
            {
                new Dog("Spot", 5),
            }),
            new Cat("Ginger", 16),
            "Ginger the cat is not for sale in our shop."
        },
        new object[]
        {
            new PetShop(new List<Animal>
            {
                new Dog("Buddy", 3),
            }),
            new Dog("Fido", 9),
            "Fido the dog is not for sale in our shop."
        }
    };

    [Theory]
    [MemberData(nameof(SellPetNotExpected))]
    public void TestPetShopTrySellMissingPet(PetShop petShop, Animal pet, string expectedErrorMessage)
    {
        // Act and Assert
        var exception =  Assert.Throws<InvalidOperationException>(() => petShop.SellPet(pet));

        Assert.Equal(expectedErrorMessage, exception.Message);
    }
}
