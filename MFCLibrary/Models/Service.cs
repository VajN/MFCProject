using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.Models
{
    internal class Service
    {
        internal string name { get; private set; } = "";
        internal Service(string name)
        {
            this.name = name;
        }
    }
}
