﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
      public  class ProductosBL
    {
        Contexto _contexto;
        public BindingList<Producto> ListaProducto { get; set; }

        public ProductosBL()

        {
            _contexto = new Contexto();
            ListaProducto = new BindingList<Producto>();

           
        }

        public BindingList<Producto> ObtenerProductos()
        {
            _contexto.Productos.Load();
            ListaProducto = _contexto.Productos.Local.ToBindingList();
            return ListaProducto;
        }

        public Resultado GuardarProducto(Producto producto)
        {
            var resultado = Validar(producto);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.SaveChanges();
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
                    _contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }
       
        private Resultado Validar(Producto producto)
        {

            var resultado = new Resultado();
            resultado.Exitoso = true;

            if(producto == null)
            {
                resultado.Mensaje = "Agregue un producto valido";
                resultado.Exitoso = false;

                return resultado;
            }

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

            if (producto.TipoId == 0)
            {
                resultado.Mensaje = "Seleccione un tipo";
                resultado.Exitoso = false;
            }

            if (producto.CategoriaId == 0)
            {
                resultado.Mensaje = "Seleccione una categoria";
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
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int TipoId { get; set; }
        public Tipo Tipo { get; set; }
        public bool Activo { get; set; }
        public byte[] Foto { get; set; }

        public Producto()
        {
            Activo = true;

        }
    }

    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}
