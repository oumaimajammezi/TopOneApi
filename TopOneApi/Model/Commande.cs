using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class Commande
    {
        public decimal Id { get; set; }
        public decimal IdClient { get; set; }
        public decimal IdEtatCmd { get; set; }
    }
}
