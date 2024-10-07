using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    internal class Teacher : Person
    {
        public static new string Ending = ".teacher";
        public static new string SearchPattern = $"*{Ending}";
        public new string Filename => $"{UniqueId}{Ending}";
    }

}
