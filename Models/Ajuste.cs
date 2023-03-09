using System;
using System.Collections.Generic;

namespace SGA_Solution.Models;

public partial class Ajuste
{
    public int Id { get; set; }

    public string MovimientoR { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string CodigoA { get; set; } = null!;

    public string NombreA { get; set; } = null!;

    public int CantidadS { get; set; }

    public decimal PrecioU { get; set; }

    public DateTime? Caducidad { get; set; }
}
