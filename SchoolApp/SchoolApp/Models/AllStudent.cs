using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    internal class AllStudent
    {
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();

        public AllStudent() =>
            LoadStudents();

        public void LoadStudents()
        {
            Students.Clear();

            string appDataPath = FileSystem.AppDataDirectory;

            IEnumerable<Student> students = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, Student.SearchPattern)

                                        // Each file name is used to create a new Note
                                        .Where(filepath => File.ReadAllLines(filepath).Count() == 2)
                                        .Select(filepath => new Student()
                                        {
                                            FirstName = File.ReadAllLines(filepath)[0],
                                            LastName = File.ReadAllLines(filepath)[1],
                                            UniqueId = Path.GetFileNameWithoutExtension(filepath)
                                        })

                                        // With the final collection of notes, order them by date
                                        .OrderBy(teacher => teacher.FirstName);

            foreach (Student student in students)
                Students.Add(student);
        }
    }
}
