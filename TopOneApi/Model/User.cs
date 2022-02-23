using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }
        public string Liaison { get; set; }
        public DateTime? DateCreation { get; set; }
        public string UserCreation { get; set; }
        public string Tag { get; set; }
        public bool Actif { get; set; }
    }
}
