﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foodball
{
    public class clAdicionaPratos
    {
        public int id_AdicionarPratos;
        public string nome;
        public string preco;
        public string tipo;

        conectaBD BD = new conectaBD();

        public int Salvar()
        {
            int id = 0;
            try
            {
                BD._sql = String.Format(new CultureInfo("en-US"), "INSERT INTO ADICIONAR_PRATOS ( Nome,Preco,Tipo ) " +
                                              " values ( '{0}','{1}','{2}' )",
                                                nome, preco, tipo) + "; SELECT SCOPE_IDENTITY();";


                BD.ExecutaComando(false, out id);

                if (id > 0)
                {
                    MessageBox.Show("Prato cadastrado com sucesso!", "Cadastro com sucesso",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar Prato ", "Erro", MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro.: " + ex.Message, "Erro", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }

            return id;
        }

        public void Excluir()
        {
            try
            {
                int exOK = 0;

                BD._sql = "DELETE FROM ADICIONAR_PRATOS WHERE ID_AdicionarPratos = " + id_AdicionarPratos;

                exOK = BD.ExecutaComando(false);

                if (exOK == 1)
                {
                    MessageBox.Show("Produto deletado com sucesso!", "Salvo com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao deletar Produto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro.: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Atualizar()
        {
            try
            {
                int exOK = 0;

                BD._sql = "UPDATE ADICIONAR_PRATOS SET Nome = '" + nome + "', Preco = '" + preco + "', Tipo = '" + tipo + "' where id_AdicionarPratos = " + id_AdicionarPratos;

                exOK = BD.ExecutaComando(false);



                if (exOK == 1)
                {
                    MessageBox.Show("Prato Alterado com sucesso!", "Salvo com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao alterar Prato, contate o desenvolvedor!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro.: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable PesquisaPorNome()
        {
            try
            {
                BD._sql = "SELECT * FROM ADICIONAR_PRATOS " +
                        " WHERE NOME LIKE '%" + nome + "%' ";

                return BD.ExecutaSelect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro.: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
