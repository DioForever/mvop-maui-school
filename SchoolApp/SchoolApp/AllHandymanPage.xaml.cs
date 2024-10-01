namespace SchoolApp;

public partial class AllHandymanPage : ContentPage
{
	public AllHandymanPage()
	{
		InitializeComponent();

        BindingContext = new Models.AllHandyman();
    }

    protected override void OnAppearing()
    {
        ((Models.AllHandyman)BindingContext).LoadHandyman();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        //await Shell.Current.GoToAsync(nameof(TeacherPage));
    }

    private async void handymanCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var handyman = (Models.Handyman)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            //await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.Filename}");

            // Unselect the UI
            handymanCollection.SelectedItem = null;
        }
    }
}