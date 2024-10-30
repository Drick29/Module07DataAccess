using Module07DataAccess.Services;
using MySql.Data.MySqlClient;

namespace Module07DataAccess;

public partial class MainPage : ContentPage
{
    int count = 0;

    private readonly DatabaseConnectionService _databaseConnectionService;

    public MainPage()
    {
        InitializeComponent();
        // Initialize Database Connection
        _databaseConnectionService = new DatabaseConnectionService();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private async void OnTestConnectionClicked(object sender, EventArgs e)
    {
        var connectionString = _databaseConnectionService.GetConnectionString(); // Fixed variable name
        try
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                ConnectionStatusLabel.Text = "Connection Successful";
                ConnectionStatusLabel.TextColor = Colors.Green;
            }
        }
        catch (Exception ex)
        {
            ConnectionStatusLabel.Text = $"Connection Failed: {ex.Message}"; // Fixed string formatting
            ConnectionStatusLabel.TextColor = Colors.Red;
        }
    }

    private async void OpenViewPersonal(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ViewPersonal");
    }
}
