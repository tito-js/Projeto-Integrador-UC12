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
    public partial class AdicionarPratos : Form
    {
        public AdicionarPratos()
        {
            InitializeComponent();
        }

        private void AdicionarPratos_Load(object sender, EventArgs e)
        {
            if (pratos != null)
            {
                txtID.Text = pratos.id_AdicionarPratos.ToString();
                txtNome.Text = pratos.Nome;
                txtTipo.Text = pratos.Tipo;
                txtPreco.Text = pratos.Preco;
                btnSalvar.Text = "Atualizar";
            }
        }

        clPratos pratos;

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            clPratos pratos = new clPratos();
            pratos.Nome = txtNome.Text;
            pratos.Preco= txtPreco.Text;
            pratos.Tipo = txtTipo.Text;

            if (txtID.Text == "")
            {
                txtID.Text = Convert.ToString(pratos.Salvar());
            }
            else
            {
                pratos.id_AdicionarPratos = int.Parse(txtID.Text);
                pratos.Atualizar();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtPreco.Text = "";
            txtTipo.Text = "";

        }
    }
}
