using System;
using System.Collections.Generic;

namespace SGA_Solution.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string ApellidoM { get; set; } = null!;

    public string ApellidoP { get; set; } = null!;

    public string Tipo { get; set; } = null!;
}
