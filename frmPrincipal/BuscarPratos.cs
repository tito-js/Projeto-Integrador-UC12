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
    public partial class BuscarPratos : Form
    {
        public BuscarPratos()
        {
            InitializeComponent();
        }

        private void BuscarPratos_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        clAdicionaPratos pratos = new clAdicionaPratos();

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPesquisa.Text != "")
                {
                    pratos.nome = txtPesquisa.Text;
                    dgvPratos.DataSource = pratos.PesquisaPorNome();
                }

                // dgvPratos.Columns[0].Visible = false;


                // dgvPratos.Columns[1].Width = 200;

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO.: " + ex.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection linha = dgvPratos.SelectedRows;
            pratos.id_AdicionarPratos = int.Parse(linha[0].Cells[0].Value.ToString());
            pratos.nome = linha[0].Cells[1].Value.ToString();
            pratos.preco = linha[0].Cells[2].Value.ToString();
            pratos.tipo = linha[0].Cells[3].Value.ToString();

            AdicionarPratos formulario = new AdicionarPratos();
            formulario.ShowDialog();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (dgvPratos.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection linha = dgvPratos.SelectedRows;
                pratos.id_AdicionarPratos = int.Parse(linha[0].Cells[0].Value.ToString());

                DialogResult resposta = MessageBox.Show("Você tem certeza que deseja excluir o pratos" + linha[0].Cells[1].Value.ToString() + " ?", "Tem certeza?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                {
                    pratos.Excluir();
                    txtNome_TextChanged(null, null);
                }
            }
        }
    }
}
