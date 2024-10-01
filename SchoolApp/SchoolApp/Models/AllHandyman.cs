using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    internal class AllHandyman
    {
        public ObservableCollection<Handyman> Handyman { get; set; } = new ObservableCollection<Handyman>();

        public AllHandyman() =>
            LoadHandyman();

        public void LoadHandyman()
        {
            Handyman.Clear();

            string appDataPath = FileSystem.AppDataDirectory;

            IEnumerable<Handyman> handymanEnumerable = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.hand")
                                        .Where(filename => File.ReadAllLines(filename).Count() == 2)

                                        // Each file name is used to create a new Note
                                        .Select(filename => new Handyman()
                                        {
                                            FirstName = File.ReadAllText(filename).Split("")[0],
                                            LastName = File.ReadAllText(filename).Split("")[1]
                                        })

                                        // With the final collection of notes, order them by date
                                        .OrderBy(handyman => handyman.FirstName);

            foreach (Handyman handyman in handymanEnumerable)
                Handyman.Add(handyman);
        }
    }
}
