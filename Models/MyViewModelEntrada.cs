namespace SGA_Solution.Models
{
    public class MyViewModelEntrada
    {
        public Movimiento Movimiento { get; set; } = null!;
        //public Entrada Entrada { get; set; } = null!;
        public List<Entrada> Entradas { get; set; } = new List<Entrada>();
        public List<Articulo> Articulos { get; set; } = null!;
        public string CodigoArticulo { get; set; } = null!;
        public string NombreArticulo { get; set; } = null!;

    }
}
