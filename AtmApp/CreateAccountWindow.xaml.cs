using System.Windows;

namespace AtmApp { 
public partial class CreateAccountWindow : Window
{
    private AtmApplication atmApplication;

    public CreateAccountWindow(AtmApplication atmApplication)
    {
        InitializeComponent();
        this.atmApplication = atmApplication;
    }

    private void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        int accountNumber = int.Parse(AccountNumberTextBox.Text);
        double initialBalance = double.Parse(InitialBalanceTextBox.Text);
        double interestRate = double.Parse(InterestRateTextBox.Text);
        string accountHolderName = AccountHolderNameTextBox.Text;

        Account newAccount = new Account(accountNumber, initialBalance, interestRate, accountHolderName);
        atmApplication.Bank.AddAccount(newAccount);

        MessageBox.Show("Account created successfully!");
        this.Close();
    }
}
}