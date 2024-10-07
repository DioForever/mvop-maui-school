using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    internal class AllSupport
    {
        public ObservableCollection<Support> Support { get; set; } = new ObservableCollection<Support>();

        public AllSupport() =>
            LoadSupport();

        public void LoadSupport()
        {
            Support.Clear();

            string appDataPath = FileSystem.AppDataDirectory;

            IEnumerable<Support> supports = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, Models.Support.SearchPattern)

                                        // Each file name is used to create a new Note
                                        .Where(filepath => File.ReadAllLines(filepath).Count() == 2)
                                        .Select(filepath => new Support()
                                        {
                                            FirstName = File.ReadAllLines(filepath)[0],
                                            LastName = File.ReadAllLines(filepath)[1],
                                            UniqueId = Path.GetFileNameWithoutExtension(filepath)
                                        })

                                        // With the final collection of notes, order them by date
                                        .OrderBy(teacher => teacher.FirstName);

            foreach (Support support in supports)
                Support.Add(support);
        }
    }
}
