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

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Teacher> teachers = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.teac")

                                        // Each file name is used to create a new Note
                                        .Where(filename => File.ReadAllLines(filename).Count() == 2)
                                        .Select(filename => new Teacher()
                                        {
                                            FirstName = File.ReadAllText(filename).Split("")[0],
                                            LastName = File.ReadAllText(filename).Split("")[1]
                                        })

                                        // With the final collection of notes, order them by date
                                        .OrderBy(teacher => teacher.FirstName);

            // Add each note into the ObservableCollection
            foreach (Teacher teacher in teachers)
                Teachers.Add(teacher);
        }
    }
}
