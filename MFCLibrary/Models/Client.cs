using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.Models
{
    internal class Client
    {
        internal string fullnameClient { get; private set; } = "";
        internal string passport { get; private set; } = "";
        internal Client(string fullnameClient, string passport)
        {
            this.fullnameClient = fullnameClient;
            this.passport = passport;
        }
    }
}
