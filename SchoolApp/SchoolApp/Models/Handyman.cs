using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    internal class Handyman
    {
        public string Filename => $"{FirstName}-{LastName}.hand";
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
