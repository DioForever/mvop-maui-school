namespace SchoolApp;

public partial class AllTeachersPage : ContentPage
{
	public AllTeachersPage()
	{
		InitializeComponent();

        BindingContext = new Models.AllTeacher();
    }

    protected override void OnAppearing()
    {
		((Models.AllTeacher)BindingContext).LoadTeachers();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(TeacherPage));
    }

    private async void teachersCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var teacher = (Models.Teacher)e.CurrentSelection[0];

            await Shell.Current.GoToAsync($"{nameof(TeacherPage)}?{nameof(TeacherPage.FirstLastName)}={teacher.FirstName + teacher.LastName}");

            teachersCollection.SelectedItem = null;
        }
    }
}