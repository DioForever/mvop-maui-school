using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    public class Person
    {
        public string Filename => $"{UniqueId}{Ending}";
        public string UniqueId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public static string Ending = "";
        public static string SearchPattern = $"*{Ending}";
    }
}
