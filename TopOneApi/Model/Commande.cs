using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class Commande
    {
        public List< DetCommandeClient> DetCmd { get; set; }
        public EntCommandeClient EntCmd { get; set; } 
    }
}
