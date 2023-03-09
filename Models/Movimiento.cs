using System;
using System.Collections.Generic;

namespace SGA_Solution.Models;

public partial class Movimiento
{
    public int Id { get; set; }

    public string Referencia { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string Tipo { get; set; } = null!;

    public decimal Total { get; set; }
}
