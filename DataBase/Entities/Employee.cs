using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    internal class Employee
    {
        internal string fullnameEmployee { get; private set; } = "";
        internal DateOnly birthday { get; private set; } = new DateOnly();
        internal int windowNumber { get; private set; } = 0;
    }
}
