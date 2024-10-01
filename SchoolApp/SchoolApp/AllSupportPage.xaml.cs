namespace SchoolApp;

public partial class AllSupportPage : ContentPage
{
    public AllSupportPage()
    {
        InitializeComponent();

        BindingContext = new Models.AllSupport();
    }

    protected override void OnAppearing()
    {
        ((Models.AllSupport)BindingContext).LoadSupport();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        //await Shell.Current.GoToAsync(nameof(TeacherPage));
    }

    private async void supportCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var support = (Models.Support)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            //await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.Filename}");

            // Unselect the UI
            supportCollection.SelectedItem = null;
        }
    }
}