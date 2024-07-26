using System.Collections.Generic;
using System.Linq;

namespace AtmApp { 
public class Bank
{
    private List<Account> accounts;

    public Bank()
    {
        accounts = new List<Account>();
        for (int i = 0; i < 10; i++)
        {
            accounts.Add(new Account(100 + i, 100.0, 0.03, $"AccountHolder{i + 1}"));
        }
    }

    public void AddAccount(Account account)
    {
        accounts.Add(account);
    }

    public Account RetrieveAccount(int accountNumber)
    {
        return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
    }

    public List<Account> Accounts => accounts;
}
}