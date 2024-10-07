using SchoolApp.Models;
using System.Windows.Input;

namespace SchoolApp;

public partial class AllTeachersPage : ContentPage
{
    public ICommand DeleteTeacherCommand { get; }

    public AllTeachersPage()
	{
		InitializeComponent();

        DeleteTeacherCommand = new Command<Teacher>(DeleteTeacher);

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
        // If we wish to allow editing of the teacher, which we don't
        //if (e.CurrentSelection.Count != 0)
        //{
        //    Teacher teacher = (Teacher)e.CurrentSelection[0];

        //    await Shell.Current.GoToAsync($"{nameof(TeacherPage)}?{nameof(TeacherPage.Filename)}={teacher.Filename}");

        //    teachersCollection.SelectedItem = null;
        //}
    }

    private async void DeleteTeacher(Teacher teacher)
    {
        string path = Path.Combine(FileSystem.AppDataDirectory, teacher.Filename);
        File.Delete(path);

        ((Models.AllTeacher)BindingContext).LoadTeachers();
    }
}