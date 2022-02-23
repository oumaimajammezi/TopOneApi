using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class ImageProduit
    {
        public string Idimage { get; set; }
        public string Idproduit { get; set; }
        public string Extention { get; set; }
        public int? Ordre { get; set; }
        public bool? Actif { get; set; }
    }
}
