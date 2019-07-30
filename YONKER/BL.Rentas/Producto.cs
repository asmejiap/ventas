namespace BL.Rentas
{
    internal class Producto
    {
        public bool Activo { get; internal set; }
        public string Nombre { get; internal set; }
        public int Existencia { get; internal set; }
        public int Id { get; internal set; }
        public int MarcaVehiculo { get; internal set; }
        public int Precio { get; internal set; }
    }
}