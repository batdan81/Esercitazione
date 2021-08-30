using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class Articoli
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Nome { get; set; }
        public double Prezzo { get; set; }
        public DateTime Scadenza { get; set; }
        public int CodiceNumerico { get; set; }
    }
}
