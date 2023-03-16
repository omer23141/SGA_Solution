namespace SGA_Solution.Models
{
    public class MyViewModelSalida
    {
        public Movimiento Movimiento { get; set; } = null!;
        public List<Salida> Salidas { get; set; } = new List<Salida>();
        public List<Articulo> Articulos { get; set; } = null!;
        public string CodigoArticulo { get; set; } = null!;
        public string NombreArticulo { get; set; } = null!;

    }
}
