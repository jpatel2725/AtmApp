using System.Collections.Generic;
using System;


namespace AtmApp { 
public class Account
{
    public int AccountNumber { get; set; }
    public double Balance { get; set; }
    public double InterestRate { get; set; }
    public string AccountHolderName { get; set; }
    public List<string> Transactions { get; private set; }

    public Account(int accountNumber, double initialBalance, double interestRate, string accountHolderName)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
        InterestRate = interestRate;
        AccountHolderName = accountHolderName;
        Transactions = new List<string>();
    }

    public void Deposit(double amount)
    {
        Balance += amount;
        Transactions.Add($"Deposit: {amount:C}");
    }

    public void Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            Transactions.Add($"Withdrawal: {amount:C}");
        }
        else
        {
            throw new InvalidOperationException("Insufficient funds");
        }
    }
}
}