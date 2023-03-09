using System;
using System.Collections.Generic;

namespace SGA_Solution.Models;

public partial class Articulo
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public int Stock { get; set; }

    public decimal PrecioU { get; set; }

    public DateTime? Caducidad { get; set; }
}
