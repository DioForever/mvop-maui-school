using SchoolApp.Models;

namespace SchoolApp;

[QueryProperty(nameof(Filename), nameof(Filename))]
public partial class StudentPage : ContentPage
{
    private string appDataPath = FileSystem.AppDataDirectory;

    public StudentPage()
    {
        InitializeComponent();
        string randomFileName = Path.GetRandomFileName() + Models.Student.Ending;

        LoadStudent(randomFileName);
    }

    public string Filename
    {
        set { LoadStudent(value); }
    }

    public void LoadStudent(string filepath)
    {
        Student teacherModel = new Student();
        string pathToSupport = Path.Combine(appDataPath, filepath);

        if (File.Exists(pathToSupport))
        {
            string[] text = File.ReadAllLines(pathToSupport);

            // In case there is more or less values we just reset it as it was corrupted
            if (text.Count() != 2)
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

        Student support = (Student)BindingContext;
        support.FirstName = firstName;
        support.LastName = lastName;

        string fileText = firstName + "\n " + lastName;

        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
        {
            await DisplayAlert("Error", "Please enter a first and last name.", "OK");
            return;
        }

        string path = Path.Combine(appDataPath, support.Filename);

        File.WriteAllText(path, fileText);

        await Shell.Current.GoToAsync("..");

        return;
    }


    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Student student)
        {
            if (File.Exists(student.Filename))
                File.Delete(student.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }
}