using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foodball
{
    public partial class frmprincipal : Form
    {
        public frmprincipal()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            BuscarPratos formulario = new BuscarPratos();
            formulario.Show();
        }

        private void btnfuncionarios_Click(object sender, EventArgs e)
        {
            AdicionarFuncionarios formulario = new AdicionarFuncionarios();
            formulario.Show();

        }

        private void btncliente_Click(object sender, EventArgs e)
        {
            AdicionarClientes formulario = new AdicionarClientes();
            formulario.Show();
        }

        private void btnprato_Click(object sender, EventArgs e)
        {
            AdicionarPratos formulario = new AdicionarPratos();
            formulario.Show();
        }

        private void btnfornecedor_Click(object sender, EventArgs e)
        {
            AdicionarFornecedor formulario = new AdicionarFornecedor();
            formulario.Show();
        }

        private void btnbuscafuncionarios_Click(object sender, EventArgs e)
        {
            BuscarFuncionarios formulario = new BuscarFuncionarios();
            formulario.Show();
        }

        private void btnbuscaclientes_Click(object sender, EventArgs e)
        {
            BuscarClientes formulario = new BuscarClientes();
            formulario.Show();
        }

        private void btnbuscafornecedor_Click(object sender, EventArgs e)
        {
            BuscarFornecedores formulario = new BuscarFornecedores();
            formulario.Show();
        }

        private void frmprincipal_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
