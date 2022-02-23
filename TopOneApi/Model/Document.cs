using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class Document
    {
        public decimal IdDoc { get; set; }
        public string Path { get; set; }
        public decimal Type { get; set; }
        public string Extention { get; set; }
    }
}
