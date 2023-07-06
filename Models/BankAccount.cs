namespace consolidation_csharp_lesson_6.Models;

public class BankAccount
{
    public string AccountNumber { get; set; }
    public string CustomerName { get; set; }
    public float Balance { get; set; }

    public BankAccount Clone()
    {
        return new BankAccount(){
            AccountNumber = AccountNumber,
            CustomerName = CustomerName,
            Balance = Balance
        };
    }

    public void Deposit(float amount)
    {
        throw new NotImplementedException();
    }

    public void Withdraw(float amount)
    {
        throw new NotImplementedException();
    }
}
