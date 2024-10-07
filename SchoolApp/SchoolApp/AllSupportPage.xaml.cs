using SchoolApp.Models;
using System.Windows.Input;

namespace SchoolApp;

public partial class AllSupportPage : ContentPage
{
    public ICommand DeleteSupportCommand { get; }

    public AllSupportPage()
    {
        InitializeComponent();

        DeleteSupportCommand = new Command<Support>(DeleteSupport);

        BindingContext = new Models.AllSupport();
    }

    protected override void OnAppearing()
    {
        ((Models.AllSupport)BindingContext).LoadSupport();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SupportPage));
    }

    private async void supportCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // If we wish to allow editing of the support, which we don't
        //if (e.CurrentSelection.Count != 0)
        //{
        //    Support support = (Support)e.CurrentSelection[0];

        //    await Shell.Current.GoToAsync($"{nameof(SupportPage)}?{nameof(SupportPage.Filename)}={support.Filename}");

        //    supportCollection.SelectedItem = null;
        //}
    }

    private async void DeleteSupport(Support support)
    {
        string path = Path.Combine(FileSystem.AppDataDirectory, support.Filename);
        File.Delete(path);

        ((Models.AllSupport)BindingContext).LoadSupport();
    }
}