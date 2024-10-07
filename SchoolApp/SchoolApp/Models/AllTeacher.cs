using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    internal class AllTeacher
    {
        public ObservableCollection<Teacher> Teachers { get; set; } = new ObservableCollection<Teacher>();

        public AllTeacher() =>
            LoadTeachers();

        public void LoadTeachers()
        {
            Teachers.Clear();

            string appDataPath = FileSystem.AppDataDirectory;

            IEnumerable<Teacher> teachers = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, Teacher.SearchPattern)

                                        // Each file name is used to create a new Note
                                        .Where(filepath => File.ReadAllLines(filepath).Count() == 2)
                                        .Select(filepath => new Teacher()
                                        {
                                            FirstName = File.ReadAllLines(filepath)[0],
                                            LastName = File.ReadAllLines(filepath)[1],
                                            UniqueId = Path.GetFileNameWithoutExtension(filepath)
                                        })

                                        // With the final collection of notes, order them by date
                                        .OrderBy(teacher => teacher.FirstName);

            foreach (Teacher teacher in teachers)
                Teachers.Add(teacher);
        }
    }
}
