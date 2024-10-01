namespace SchoolApp;

[QueryProperty(nameof(FirstLastName), nameof(FirstLastName))]
public partial class TeacherPage : ContentPage
{
    private string appDataPath = FileSystem.AppDataDirectory;
    private bool editing = false;

    public TeacherPage()
	{
		InitializeComponent();
	}

    public string FirstLastName
    {
        set { LoadTeacher(value); }
    }

    public void LoadTeacher(string fileName)
    {
        Models.Teacher teacherModel = new Models.Teacher();;

        if (File.Exists(fileName))
        {
            editing = true;

            string[] text = File.ReadAllLines(fileName);

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

        BindingContext = teacherModel;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Teacher teacher)
        {
            string firstName = FirstNameEditor.Text;
            string lastName = LastNameEditor.Text;
            string fileName = firstName + lastName + ".teac";
            string fileText = firstName + " " + lastName;

            if (File.Exists(Path.Combine(appDataPath, fileName)) && editing == false) return;
            else File.WriteAllText(Path.Combine(appDataPath, fileName), fileText);
        }

        await Shell.Current.GoToAsync("..");

        return;
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Teacher teacher)
        {
            // Delete the file.
            if (File.Exists(teacher.Filename))
                File.Delete(teacher.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }
}