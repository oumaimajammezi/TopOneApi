using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class MessageCommande
    {
        public string Idcommande { get; set; }
        public int Idmessage { get; set; }
        public string DescriptionMessage { get; set; }
        public bool AfficherClient { get; set; }
    }
}
