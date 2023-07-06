namespace consolidation_csharp_lesson_6.Models;

public static class SampleData
{
    public static List<BankAccount> AccountDataset = new List<BankAccount>
    {
        new BankAccount
        {
            AccountNumber = "12169553",
            CustomerName = "Alice Smith",
            Balance = 50
        },
        new BankAccount
        {
            AccountNumber = "82309802",
            CustomerName = "Bob Jones",
            Balance = 200
        },
        new BankAccount
        {
            AccountNumber = "38987723",
            CustomerName = "Charlie Taylor",
            Balance = 100
        },
        new BankAccount
        {
            AccountNumber = "32605081",
            CustomerName = "David Brown",
            Balance = 70
        },
        new BankAccount
        {
            AccountNumber = "87630077",
            CustomerName = "Eve Williams",
            Balance = 20
        },
        new BankAccount
        {
            AccountNumber = "04985834",
            CustomerName = "Frank Wilson",
            Balance = 250
        },
        new BankAccount
        {
            AccountNumber = "77195058",
            CustomerName = "Grace Johnson",
            Balance = 150
        },
        new BankAccount
        {
            AccountNumber = "83670310",
            CustomerName = "Heidi Davies",
            Balance = 125
        },
        new BankAccount
        {
            AccountNumber = "40469993",
            CustomerName = "Ivan Patel",
            Balance = 175
        },
        new BankAccount
        {
            AccountNumber = "92174700",
            CustomerName = "Judy Robinson",
            Balance = 220
        },
        new BankAccount
        {
            AccountNumber = "75029429",
            CustomerName = "Mallory Wright",
            Balance = 30
        },
    };

    public static List<PetData> PetDataset = new List<PetData>
    {
        new PetData { Name = "Spot", Age = 5, Species = "dog" },
        new PetData { Name = "Fluffy", Age = 16, Species = "cat" },
        new PetData { Name = "Buddy", Age = 3, Species = "dog" },
        new PetData { Name = "Fido", Age = 9, Species = "dog" },
        new PetData { Name = "Nemo", Age = 1, Species = "fish" },
        new PetData { Name = "Ginger", Age = 8, Species = "cat" },
        new PetData { Name = "Floppy", Age = 2, Species = "rabbit" },
    };
}
