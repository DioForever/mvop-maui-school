﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    internal class Support : Person
    {
        public static new string Ending = ".support";
        public static new string SearchPattern = $"*{Ending}";
        public new string Filename => $"{UniqueId}{Ending}";
    }
}
