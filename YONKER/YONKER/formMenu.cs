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
    public partial class formMenu : Form
    {
        public formMenu()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login();

        }

        private void login()
        {
            var formLogin = new FormLogin();
            formLogin.ShowDialog();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            login();
        }

        private void RentasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void InventarioGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormProductos = new FormProductos();
            FormProductos.MdiParent = this;
            FormProductos.Show();
        }
    }
}
