using Microsoft.Maui.Storage;
using SchoolApp.Models;
namespace SchoolApp;

[QueryProperty(nameof(Filename), nameof(Filename))]
public partial class TeacherPage : ContentPage
{
    private string appDataPath = FileSystem.AppDataDirectory;

    public TeacherPage()
	{
		InitializeComponent();
        string randomFileName = Path.GetRandomFileName() + Teacher.Ending;

        LoadTeacher(randomFileName);
    }

    public string Filename
    {
        set { LoadTeacher(value); }
    }

    public void LoadTeacher(string filepath)
    {
        Teacher teacherModel = new Teacher();
        string pathToTeacher = Path.Combine(appDataPath, filepath);

        if (File.Exists(pathToTeacher))
        {
            string[] text = File.ReadAllLines(pathToTeacher);

            // In case there is more or less values we just reset it as it was corrupted
            if(text.Count() != 2)
            {
                teacherModel.FirstName = "";
                teacherModel.LastName = "";
            }
            else
            {
                teacherModel.FirstName = text[0];
                teacherModel.LastName = text[1];
            }
        }
        teacherModel.UniqueId = Path.GetFileNameWithoutExtension(filepath);

        BindingContext = teacherModel;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        string firstName = FirstNameEditor.Text;
        string lastName = LastNameEditor.Text;

        Teacher teacher = (Teacher)BindingContext;
        teacher.FirstName = firstName;
        teacher.LastName = lastName;

        string fileText = firstName + "\n " + lastName;

        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
        {
            await DisplayAlert("Error", "Please enter a first and last name.", "OK");
            return;
        }

        string path = Path.Combine(appDataPath, teacher.Filename);

        File.WriteAllText(path, fileText);

        await Shell.Current.GoToAsync("..");

        return;
    }


    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Teacher teacher)
        {
            if (File.Exists(teacher.Filename))
                File.Delete(teacher.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }
}