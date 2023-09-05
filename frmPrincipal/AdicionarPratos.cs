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
            if (Pratos != null)
            {
                txtID.Text = Pratos.id_AdicionarPratos.ToString();
                txtNome.Text = Pratos.nome;
                txtTipo.Text = Pratos.tipo;
                txtPreco.Text = Pratos.preco;
                btnSalvar.Text = "Atualizar";
            }
        }

        clAdicionaPratos Pratos;

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            clAdicionaPratos pratos = new clAdicionaPratos();
            pratos.nome = txtNome.Text;
            pratos.preco= txtPreco.Text;
            pratos.tipo = txtTipo.Text;

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
