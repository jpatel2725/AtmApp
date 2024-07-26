using System.Windows;


namespace AtmApp { 
public partial class MainWindow : Window
{
    private AtmApplication atmApplication;

    public MainWindow()
    {
        InitializeComponent();
        atmApplication = new AtmApplication();
    }

    private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
    {
        CreateAccountWindow createAccountWindow = new CreateAccountWindow(atmApplication);
        createAccountWindow.Show();
    }

    private void SelectAccountButton_Click(object sender, RoutedEventArgs e)
    {
        SelectAccountWindow selectAccountWindow = new SelectAccountWindow(atmApplication);
        selectAccountWindow.Show();
    }

    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}
}