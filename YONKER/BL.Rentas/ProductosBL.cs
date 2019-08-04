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
        public BindingList<Producto> ListaProducto { get; set; }

        public ProductosBL()

        {
            ListaProducto = new BindingList<Producto>();

            var producto1 = new Producto();
            producto1.Id = 1;
            producto1.Nombre = "Tono";
            producto1.Precio = 1300;
            producto1.Existencia = 5;
            producto1.Activo = true;

            ListaProducto.Add(producto1);

            var producto2 = new Producto();
            producto2.Id = 2;
            producto2.Nombre = "Motor";
            producto2.Precio = 5000;
            producto2.Existencia = 3;
            producto2.Activo = true;

            ListaProducto.Add(producto2);

            var producto3 = new Producto();
            producto3.Id = 3;
            producto3.Nombre = "Disco de frenos";
            producto3.Precio = 800;
            producto3.Existencia =23;
            producto3.Activo = true;

            ListaProducto.Add(producto3);
        }

        public BindingList<Producto> ObtenerProductos()
        {
            return ListaProducto;
        }

        public Resultado GuardarProducto(Producto producto)
        {
            var resultado = Validar(producto);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            if (producto.Id == 0)
            {
                producto.Id = ListaProducto.Max(item => item.Id) + 1;
                
            }
            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarProducto()
        {
            var nuevoProducto = new Producto();
            ListaProducto.Add(nuevoProducto);
        }

        public bool EliminarProducto(int id)
        {
            foreach (var producto in ListaProducto)
            {
                if (producto.Id == id)
                {
                    ListaProducto.Remove(producto);
                    return true;
                }
            }
            return false;
        }
       
        private Resultado Validar(Producto producto)
        {

            var resultado = new Resultado();
            resultado.Exitoso = true;
            if (string.IsNullOrEmpty(producto.Nombre) == true)
            {
                resultado.Mensaje = "Ingrese una descripcion";
                resultado.Exitoso = false;
            }

            if (producto.Existencia <0)
            {
                resultado.Mensaje = "La Exisitencia dbe ser mayor que cero";
                resultado.Exitoso = false;
            }

            if (producto.Precio <=0)
            {
                resultado.Mensaje = "El precio deber ser mayor que cero";
                resultado.Exitoso = false;
            }
            return resultado;
        }
    }

    public class Producto
    {
        public int Id { get; set; }
        public string Nombre{ get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public bool Activo { get; set; }
    }

    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}
