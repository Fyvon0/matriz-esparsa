using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matriz_Esparsa
{
    public partial class Form1 : Form
    {
        ListaLigadaCruzada matriz1,matriz2,matriz3;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbxGrids.SelectedItem))
            {
                case 1:
                    try
                    {
                        if (!matriz1.InserirEm(Convert.ToInt32(nudLinhas.Value), Convert.ToInt32(nudColunas.Value), Convert.ToDouble(nudValor.Value)))
                            MessageBox.Show("Já existe um valor nessa posição");
                        else
                            matriz1.ExibirNoGridView(dataGridView1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 2:
                    try
                    {
                        if (!matriz2.InserirEm(Convert.ToInt32(nudLinhas.Value), Convert.ToInt32(nudColunas.Value), Convert.ToDouble(nudValor.Value)))
                            MessageBox.Show("Já existe um valor nessa posição");
                        else
                            matriz2.ExibirNoGridView(dataGridView2);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbxGrids.SelectedItem))
            {
                case 1:
                    nudValor.Value = Convert.ToDecimal(matriz1.ValorDe(Convert.ToInt32(nudLinhas.Value), Convert.ToInt32(nudColunas.Value)));
                    break;
                case 2:
                    nudValor.Value = Convert.ToDecimal(matriz2.ValorDe(Convert.ToInt32(nudLinhas.Value), Convert.ToInt32(nudColunas.Value)));
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbxGrids.SelectedItem))
            {
                case 1:
                    matriz1.RemoverElemento(Convert.ToInt32(nudLinhas.Value), Convert.ToInt32(nudColunas.Value));
                    matriz1.ExibirNoGridView(dataGridView1);
                    break;
                case 2:
                    matriz2.RemoverElemento(Convert.ToInt32(nudLinhas.Value), Convert.ToInt32(nudColunas.Value));
                    matriz2.ExibirNoGridView(dataGridView2);
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbxGrids.SelectedItem))
            {
                case 1:
                    matriz1.SomaValorEmColuna(Convert.ToDouble(nudValor.Value), Convert.ToInt32(nudColunas.Value));
                    matriz1.ExibirNoGridView(dataGridView1);
                    break;
                case 2:
                    matriz2.SomaValorEmColuna(Convert.ToInt32(nudValor.Value), Convert.ToInt32(nudColunas.Value));
                    matriz2.ExibirNoGridView(dataGridView2);
                    break;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbxGrids.SelectedItem))
            {
                case 1:
                    matriz1.Limpar();
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    cbxGrids.Items.Remove(cbxGrids.SelectedItem);
                    if (cbxGrids.Items.Count == 0)
                        gbxOperacoes.Enabled = false;
                    else
                      cbxGrids.SelectedIndex = 0;
                    break;
                case 2:
                    matriz2.Limpar();
                    dataGridView2.Rows.Clear();
                    dataGridView2.Columns.Clear();
                    cbxGrids.Items.Remove(cbxGrids.SelectedItem);
                    if (cbxGrids.Items.Count == 0)
                        gbxOperacoes.Enabled = false;
                    else
                       cbxGrids.SelectedIndex = 0;
                    break;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            switch (Convert.ToInt32(nudCriarGridView.Value))
            {
                case 1:
                    matriz1.LerArquivo(openFileDialog1.FileName);
                    matriz1.ExibirNoGridView(dataGridView1);
                    break;
                case 2:
                    matriz2.LerArquivo(openFileDialog1.FileName);
                    matriz2.ExibirNoGridView(dataGridView2);
                    break;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (cbxGrids.Items.Count == 2)
                ListaLigadaCruzada.MultiplicarMatrizes(matriz1, matriz2).ExibirNoGridView(dataGridView3);
            else
                MessageBox.Show("É necessário ter duas matrizes para fazer a multiplicação");      
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (cbxGrids.Items.Count == 2)
                ListaLigadaCruzada.SomarMatrizes(matriz1, matriz2).ExibirNoGridView(dataGridView3);
            else
                MessageBox.Show("É necessário ter duas matrizes para fazer a soma");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(nudCriarGridView.Value))
            {
                case 1:
                    matriz1 = new ListaLigadaCruzada(Convert.ToInt32(nudCriarLinhas.Value), Convert.ToInt32(nudCriarColunas.Value));
                    matriz1.ExibirNoGridView(dataGridView1);
                    if (!cbxGrids.Items.Contains(1))
                        cbxGrids.Items.Add(1);
                    break;
                case 2:
                    matriz2 = new ListaLigadaCruzada(Convert.ToInt32(nudCriarLinhas.Value), Convert.ToInt32(nudCriarColunas.Value));
                    matriz2.ExibirNoGridView(dataGridView2);
                    if (!cbxGrids.Items.Contains(2))
                        cbxGrids.Items.Add(2);
                    break;
            }
            cbxGrids.SelectedIndex = 0;

            gbxOperacoes.Enabled = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
