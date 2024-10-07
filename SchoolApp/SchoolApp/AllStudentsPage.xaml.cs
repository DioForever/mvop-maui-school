using SchoolApp.Models;
using System.Windows.Input;

namespace SchoolApp;

public partial class AllStudentsPage : ContentPage
{
    public ICommand DeleteStudentCommand { get; }

    public AllStudentsPage()
    {
        InitializeComponent();

        DeleteStudentCommand = new Command<Student>(DeleteStudent);

        BindingContext = new Models.AllStudent();
    }

    protected override void OnAppearing()
    {
        ((Models.AllStudent)BindingContext).LoadStudents();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(StudentPage));
    }

    private async void studentCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // If we wish to allow editing of the student, which we don't
    }

    private async void DeleteStudent(Student student)
    {
        string path = Path.Combine(FileSystem.AppDataDirectory, student.Filename);
        File.Delete(path);

        ((Models.AllStudent)BindingContext).LoadStudents();
    }
}