using System;
using System.Collections.Generic;

#nullable disable

namespace Supermarket.Models
{
    public partial class CategoriaArticoli
    {
        public int CategoryId { get; set; }
        public string NomeCategoria { get; set; }
        public string Descrizione { get; set; }
    }
}
