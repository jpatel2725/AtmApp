using System.Windows;

namespace AtmApp { 
public partial class SelectAccountWindow : Window
{
    private AtmApplication atmApplication;

    public SelectAccountWindow(AtmApplication atmApplication)
    {
        InitializeComponent();
        this.atmApplication = atmApplication;
    }

    private void SelectButton_Click(object sender, RoutedEventArgs e)
    {
        int accountNumber = int.Parse(AccountNumberTextBox.Text);
        Account account = atmApplication.Bank.RetrieveAccount(accountNumber);

        if (account != null)
        {
            AccountWindow accountWindow = new AccountWindow(account);
            accountWindow.Show();
        }
        else
        {
            MessageBox.Show("Account not found.");
        }
        this.Close();
    }
}
}