﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class PieceJointeProduit
    {
        public string Iddocument { get; set; }
        public string Idproduit { get; set; }
        public string Extention { get; set; }
        public string NomDocument { get; set; }
        public string Designation { get; set; }
        public int Ordre { get; set; }
        public bool Actif { get; set; }
    }
}
