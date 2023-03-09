using System;
using System.Collections.Generic;

namespace SGA_Solution.Models;

public partial class Entrada
{
    public int Id { get; set; }

    public string MovimientoR { get; set; } = null!;

    public string Proveedor { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string CodigoA { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal CostoU { get; set; }

    public decimal Total { get; set; }

    public DateTime? Caducidad { get; set; }
}
