using BL.Rentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YONKER
{
    public partial class FormProductos : Form
    {
        ProductosBL _productos;
        

        public FormProductos()
        {
            InitializeComponent();
            _productos = new ProductosBL();
            listaProductoBindingSource.DataSource = _productos.ObtenerProductos();
        } 
    }
}
