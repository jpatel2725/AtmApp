using System;

namespace AtmApp {
    public class AtmApplication
    {
        public Bank Bank { get; private set; }

        public AtmApplication()
        {
            Bank = new Bank();
        }
    

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("ATM Main Menu:");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Select Account");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateAccount();
                    break;
                case "2":
                    SelectAccount();
                    break;
                case "3":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to try again...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void CreateAccount()
    {
        Console.Clear();
        Console.Write("Enter Account Number: ");
        int accountNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter Initial Balance: ");
        double initialBalance = double.Parse(Console.ReadLine());
        Console.Write("Enter Interest Rate: ");
        double interestRate = double.Parse(Console.ReadLine());
        Console.Write("Enter Account Holder's Name: ");
        string accountHolderName = Console.ReadLine();

        Account newAccount = new Account(accountNumber, initialBalance, interestRate, accountHolderName);
        Bank.AddAccount(newAccount);
        Console.WriteLine("Account created successfully! Press any key to return to main menu...");
        Console.ReadKey();
    }

    private void SelectAccount()
    {
        Console.Clear();
        Console.Write("Enter Account Number: ");
        int accountNumber = int.Parse(Console.ReadLine());
        Account account = Bank.RetrieveAccount(accountNumber);

        if (account != null)
        {
            bool managingAccount = true;
            while (managingAccount)
            {
                Console.Clear();
                Console.WriteLine($"Account Menu for {account.AccountHolderName}:");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Display Transactions");
                Console.WriteLine("5. Exit Account");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Balance: {account.Balance:C}");
                        break;
                    case "2":
                        Console.Write("Enter amount to deposit: ");
                        double depositAmount = double.Parse(Console.ReadLine());
                        account.Deposit(depositAmount);
                        Console.WriteLine("Deposit successful!");
                        break;
                    case "3":
                        Console.Write("Enter amount to withdraw: ");
                        double withdrawAmount = double.Parse(Console.ReadLine());
                        try
                        {
                            account.Withdraw(withdrawAmount);
                            Console.WriteLine("Withdrawal successful!");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "4":
                        Console.WriteLine("Transactions:");
                        foreach (var transaction in account.Transactions)
                        {
                            Console.WriteLine(transaction);
                        }
                        break;
                    case "5":
                        managingAccount = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again...");
                        break;
                }

                if (managingAccount)
                {
                    Console.WriteLine("Press any key to return to the account menu...");
                    Console.ReadKey();
                }
            }
        }
        else
        {
            Console.WriteLine("Account not found. Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
}