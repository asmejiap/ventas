using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
      public  class ProductosBL
    {
        public BindingList<producto> listaProducto { get; set; }

        public ProductosBL()

        {
            listaProducto = new BindingList<producto>();

            var producto1 = new producto();
            producto1.Id = 1;
            producto1.Nombre = "Tono";
            producto1.Precio = 1300;
            producto1.Existencia = 5;
            producto1.Activo = true;

            listaProducto.Add(producto1);

            var producto2 = new producto();
            producto2.Id = 2;
            producto2.Nombre = "Motor";
            producto2.Precio = 5000;
            producto2.Existencia = 3;
            producto2.Activo = true;

            listaProducto.Add(producto2);

            var producto3 = new producto();
            producto3.Id = 3;
            producto3.Nombre = "Disco de frenos";
            producto3.Precio = 800;
            producto3.Existencia =23;
            producto3.Activo = true;

            listaProducto.Add(producto3);
        }

        public BindingList<producto> ObtenerProductos()
        {
            return listaProducto;
        }
    }

    public class producto
    {
        public int Id { get; set; }
        public string Nombre{ get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public bool Activo { get; set; }
    }
}
