using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSS_Aula06Section_1409
{
    public partial class TabControlDadosCadastrais : Form
    {
        public TabControlDadosCadastrais()
        {
            InitializeComponent();
        }

        #region METODO LIMPAR UTILIZANDO O CONTROL
        public void Limpar(Control con)
        {
            foreach (Control caixa in con.Controls)
            {
                if (caixa is TextBox)
                {
                    ((TextBox)caixa).Clear();
                }
                else
                {
                    Limpar(caixa);
                }
            }

            txtCodigo.Clear();
            img.Image = null;
            txtCodigo.Focus();
        }
        #endregion

        #region STRINGS PARA O METODO SAIR / METODO SAIR
        string texto = "Deseja sair do Sistema? ;-;";
        string titulo = "<<< SAINDO DO SISTEMA.... >>>";
        MessageBoxButtons BOTAO = MessageBoxButtons.YesNo;
        MessageBoxDefaultButton PADRAO = MessageBoxDefaultButton.Button2;
        MessageBoxIcon ICONE = MessageBoxIcon.Question;
        DialogResult resposta;

        public void Sair()
        {
            resposta = MessageBox.Show(texto, titulo, BOTAO, ICONE, PADRAO);
            if (resposta == DialogResult.Yes) 
            { 
                Application.Exit(); 
            }

        }
        #endregion

        #region TABPAGE 1,2
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region BTNLIMPAR
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            this.Limpar(this);   
        }
        #endregion

        #region BTNFOTO
        private void btnFoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if(openFileDialog1.FileName != "")
            {
                img.Load(openFileDialog1.FileName);
            }
            else
            {
                img.Image = null;
            }
        }
        #endregion

        #region BTNADD
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(txtCodigo.Text, txtName.Text, img.Image);
            this.Limpar(this);
        }
        #endregion

        #region BTNINSERIR
        private void btnInserir_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Insert(0, txtCodigo.Text, txtName.Text, img.Image);
            this.Limpar(this);
        }
        #endregion

        #region BTNSAIR
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Sair();
        }
        #endregion

        #region BTNELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int linha = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            int reg = dataGridView1.RowCount;
            if (linha == 0)
            {
                MessageBox.Show("A T E N Ç Ã O - Selecione um item para excluir!!!",
                    "E X C L U I R  ITEM",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
            }
            else
            {
                this.dataGridView1.Rows.Clear();
            }
        }
        #endregion

        #region TXTNAME
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                btnFoto.Focus();
            }
        }
        #endregion

        #region TXTCODIGO
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                txtName.Focus();
            }
        }
        #endregion
    }
}
