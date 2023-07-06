namespace consolidation_csharp_lesson_6.Models;

public class ATM
{
    private Dictionary<string, BankAccount> accounts;

    public ATM(IEnumerable<BankAccount> accounts)
    {
        this.accounts = accounts.ToDictionary(
            account => account.AccountNumber,
            account => account.Clone()
        );
    }

    public ATM(Dictionary<string, BankAccount> accounts)
    {
        this.accounts = accounts;
    }

    public void ProcessDeposit(string accountNumber, float amount)
    {
        throw new NotImplementedException();
    }

    public void ProcessWithdrawal(string accountNumber, float amount)
    {
        throw new NotImplementedException();
    }

    public void ServeCustomer(string accountNumber)
    {
        Console.WriteLine($"Welcome, {accounts[accountNumber].CustomerName}.");
        while (true)
        {
            Console.WriteLine("Would you like to deposit or withdraw money today?");
            Console.WriteLine("[D] Deposit");
            Console.WriteLine("[W] Withdraw");
            Console.WriteLine("[X] Cancel");

            string actionCode = Console.ReadLine()?.ToLower();

            switch (actionCode)
            {
                case "d":
                    Console.Write("Enter deposit amount: ");
                    if (float.TryParse(Console.ReadLine(), out float depositAmount))
                    {
                        ProcessDeposit(accountNumber, depositAmount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid amount.");
                    }
                    break;
                case "w":
                    Console.Write("Enter withdrawal amount: ");
                    if (float.TryParse(Console.ReadLine(), out float withdrawalAmount))
                    {
                        ProcessWithdrawal(accountNumber, withdrawalAmount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid amount.");
                    }
                    break;
                case "x":
                    Console.WriteLine("No problem. Thank you for your visit!");
                    return;
                default:
                    Console.WriteLine("That doesn't seem to be one of the options. Please try again.");
                    break;
            }
        }
    }

    public void Menu()
    {
        Console.Write("Please enter your account number: ");
        string accountNumber = Console.ReadLine();

        if (accounts.ContainsKey(accountNumber))
        {
            ServeCustomer(accountNumber);
        }
        else
        {
            Console.WriteLine("That account number is not recognized.");
        }
    }
}
