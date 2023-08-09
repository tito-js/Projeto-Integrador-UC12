using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foodball
{
    public partial class AdicionarClientes : Form
    {
        public AdicionarClientes()
        {
            InitializeComponent();
        }

        public clCliente cliente;

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdicionarClientes_Load(object sender, EventArgs e)
        {
            if (cliente != null)
            {
                txtID.Text = cliente.idcliente.ToString();
                txtNome.Text = cliente.nome;
                txtCpf.Text = cliente.cpf;
                txtCEP.Text = cliente.cep;
                txtComplemento.Text = cliente.complemento;
                txtBairro.Text = cliente.bairro;
                txtEndereco.Text = cliente.endereco;
                txtTelefone.Text = cliente.telefone;
                txtCidade.Text = cliente.cidade;
                txtUF.Text = cliente.uf;
                btnSalvar.Text = "Atualizar";
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            clCliente cliente = new clCliente();
            cliente.nome = txtNome.Text;
            cliente.cpf = txtCpf.Text;
            cliente.cep = txtCEP.Text;
            cliente.complemento = txtComplemento.Text;
            cliente.bairro = txtBairro.Text;
            cliente.endereco = txtEndereco.Text;
            cliente.telefone = txtTelefone.Text;
            cliente.cidade = txtCidade.Text;
            cliente.uf = txtUF.Text;

            if (txtID.Text == "")
            {
                txtID.Text = Convert.ToString(cliente.Salvar());
            }
            else
            {
                cliente.idcliente = int.Parse(txtID.Text);
                cliente.Atualizar();
            }
        }

        private void btnBuscaCEP_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/" + txtCEP.Text + "/json/");
            request.AllowAutoRedirect = false;
            HttpWebResponse ChecaServidor = (HttpWebResponse)request.GetResponse();

            if (ChecaServidor.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show("Erro na requisição: " + ChecaServidor.StatusCode.ToString());
                return; // Encerra o códigoz
            }

            using (Stream webStream = ChecaServidor.GetResponseStream())
            {
                if (webStream != null)
                {
                    using (StreamReader responseReader = new StreamReader(webStream))
                    {
                        String response = responseReader.ReadToEnd();
                        MessageBox.Show(response);
                        response = Regex.Replace(response, "[{},]", string.Empty);
                        response = response.Replace("\"", "");
                        MessageBox.Show(response);

                        String[] substrings = response.Split('\n');


                        // CEP
                        string[] valor = substrings[1].Split(':');
                        txtCEP.Text = valor[1].ToString();

                        // Endereço
                        string[] valor1 = substrings[2].Split(':');
                        txtEndereco.Text = valor1[1].ToString();

                        // Bairro
                        string[] valor2 = substrings[4].Split(':');
                        txtBairro.Text = valor2[1].ToString();

                        // Cidade
                        string[] valor3 = substrings[5].Split(':');
                        txtCidade.Text = valor3[1].ToString();

                        // UF
                        string[] valor4 = substrings[6].Split(':');
                        txtUF.Text = valor4[1].ToString();

                        // Complemento
                        string[] valor5 = substrings[3].Split(':');
                        txtComplemento.Text = valor5[1].ToString();
                    }
                }
            }
        }
    }
}
