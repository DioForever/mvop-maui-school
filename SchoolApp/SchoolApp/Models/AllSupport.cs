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

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Support> supports = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.supp")

                                        // Each file name is used to create a new Note
                                        .Where(filename => File.ReadAllLines(filename).Count() == 2)
                                        .Select(filename => new Support()
                                        {
                                            FirstName = File.ReadAllText(filename).Split("")[0],
                                            LastName = File.ReadAllText(filename).Split("")[1]
                                        })

                                        // With the final collection of notes, order them by date
                                        .OrderBy(support => support.FirstName);

            // Add each note into the ObservableCollection
            foreach (Support support in supports)
                Support.Add(support);
        }
    }
}
