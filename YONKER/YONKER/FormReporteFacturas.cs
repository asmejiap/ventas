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
    public partial class FormReporteFacturas : Form
    {
        public FormReporteFacturas()
        {
            InitializeComponent();
            var _facturabl = new FacturaBL();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _facturabl.ObtenerFacturas();

            var reporte = new ReporteFacturas();
            reporte.SetDataSource(bindingSource);
            reporte.Database.Tables["Factura"].SetDataSource(bindingSource);

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }
    }
}
