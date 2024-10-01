using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    internal class Support
    {
        public string Filename => $"{FirstName}-{LastName}.supp";
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
