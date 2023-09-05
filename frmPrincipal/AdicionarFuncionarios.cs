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
    public partial class AdicionarFuncionarios : Form
    {
        public AdicionarFuncionarios()
        {
            InitializeComponent();
        }

        clFuncionarios funcionarios;

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void AdicionarFuncionarios_Load(object sender, EventArgs e)
        {
            if (funcionarios != null)
            {
                txtID.Text = funcionarios.idFuncionario.ToString();
                txtNome.Text = funcionarios.nome;
                txtCPF.Text = funcionarios.cpf;
                txtCargo.Text = funcionarios.cargo;
                txtTelefone.Text = funcionarios.telefone;
                btnSalvar.Text = "Atualizar";
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            clFuncionarios funcionarios = new clFuncionarios();
            funcionarios.nome = txtNome.Text;
            funcionarios.cpf = txtCPF.Text;
            funcionarios.cargo = txtCargo.Text;
            funcionarios.telefone = txtTelefone.Text;

            if (txtID.Text == "")
            {
                txtID.Text = Convert.ToString(funcionarios.Salvar());
            }
            else
            {
                funcionarios.idFuncionario = int.Parse(txtID.Text);
                funcionarios.Atualizar();
            }
        }

        private void btnBuscaCEP_Click(object sender, EventArgs e)
        {


        }

        private void txtCargo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtCargo.Text = "";
            txtTelefone.Text = "";
        }
    }
}
