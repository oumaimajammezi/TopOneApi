using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class HistoriqueConnexion
    {
        public int Id { get; set; }
        public string Idclient { get; set; }
        public DateTime? DateConnexion { get; set; }
        public string Origine { get; set; }
        public string PageVue { get; set; }
        public string AdresseIp { get; set; }
    }
}
