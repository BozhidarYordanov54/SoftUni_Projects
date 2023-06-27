Account checkingAccount = new CheckingAccount(1000);
Account savingsAccount = new SavingsAccount(500);

checkingAccount.Withdraw(500);
savingsAccount.Withdraw(200);

internal class SavingsAccount : Account
{
    public SavingsAccount(decimal initialBalance) : base(initialBalance)
    {

    }

    public override void Withdraw(decimal withdrawAmount)
    {
        balance -= withdrawAmount;
        Console.WriteLine("Savings account balance: " + balance);
    }
}

public class CheckingAccount : Account
{
    public CheckingAccount(decimal initialBalance) : base(initialBalance)
    {

    }

    public override void Withdraw(decimal withdrawAmount)
    {
        balance -= withdrawAmount;
        Console.WriteLine("Checking account balance: " + balance);
    }
}

public abstract class Account
{
    protected decimal balance;
    public Account(decimal initialBalance)
    {
        balance = initialBalance;
    }
    public abstract void Withdraw(decimal withdrawAmount);
}