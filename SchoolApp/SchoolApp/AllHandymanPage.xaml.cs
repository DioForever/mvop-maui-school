using SchoolApp.Models;
using System.Windows.Input;

namespace SchoolApp;

public partial class AllHandymanPage : ContentPage
{
    public ICommand DeleteHandymanCommand { get; }

    public AllHandymanPage()
    {
        InitializeComponent();

        DeleteHandymanCommand = new Command<Handyman>(DeleteHandyman);

        BindingContext = new Models.AllHandyman();
    }

    protected override void OnAppearing()
    {
        ((Models.AllHandyman)BindingContext).LoadHandyman();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(HandymanPage));
    }

    private async void handymanCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // If we wish to allow editing of the handyman, which we don't
    }

    private async void DeleteHandyman(Handyman handyman)
    {
        string path = Path.Combine(FileSystem.AppDataDirectory, handyman.Filename);
        File.Delete(path);

        ((Models.AllHandyman)BindingContext).LoadHandyman();
    }
}