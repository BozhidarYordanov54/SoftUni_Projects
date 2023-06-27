Dictionary<int, double> bankAccounts = new();

string[] bankAccountsInput = Console.ReadLine().Split(",");

for (int i = 0; i < bankAccountsInput.Length; i++)
{
	string[] cmdArgs = bankAccountsInput[i].Split("-");

	int name = int.Parse(cmdArgs[0]);
	double balance = double.Parse(cmdArgs[1]);

	if (!bankAccounts.ContainsKey(name))
	{
		bankAccounts.Add(name, balance);
	}
	else 
	{
        bankAccounts[name] = balance;
    }
}

string command = string.Empty;
while ((command = Console.ReadLine()) != "End")
{
	string[] cmdArgs = command.Split(" ");

    string accountCommand = cmdArgs[0];
    int accountNumber = int.Parse(cmdArgs[1]);
    double sum = double.Parse(cmdArgs[2]);

    try
	{

        switch (accountCommand)
        {
            case "Deposit":
                bankAccounts[accountNumber] += sum;
                break;
            case "Withdraw":
                if (sum > bankAccounts[accountNumber])
                {
                    throw new ArgumentException("Insufficient balance!");
                }
                bankAccounts[accountNumber] -= sum;
                break;
            default:
                throw new ArgumentException("Invalid command!");
        }

        Console.WriteLine($"Account {accountNumber} has new balance: {bankAccounts[accountNumber]:f2}");
    }
	catch (KeyNotFoundException)
	{
        Console.WriteLine("Invalid account!");
    }
    catch(ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally 
    {
        Console.WriteLine("Enter another command");
    }
}