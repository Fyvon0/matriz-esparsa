using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matriz_Esparsa
{
    class ListaLigadaCruzada
    {
        Celula[] linhas;
        Celula[] colunas;
        Celula linhaAtual;
        Celula linhaAnterior;
        Celula colunaAtual;
        Celula colunaAnterior;

        //Criar a estrutura básica da matriz esparsa com dimensão M x N - Construtor - feito
        //Inserir um novo elemento em uma posição(l, c) da matriz - InserirEm - feito
        //Ler um arquivo texto com as coordenadas e os valores não nulos, armazenando-os na matriz - a fazer
        //Retornar o valor de uma posição(l, c) da matriz - ValorDe - feito
        //Exibir a matriz na tela, em um gridView - ExibirNoGridView - feito
        //Liberar todas as posições alocadas da matriz, incluindo sua estrutura básica - Limpar - feito
        //Remover o elemento(l, c) da matriz - RemoverElemento - feito
        //Somar a constante K a todos os elementos da coluna c da matriz - SomaValorEmColuna - feito
        //Somar duas matrizes esparsas, cada uma representada em uma estrutura própria e ambas exibidas
        //em seu próprio gridView.O resultado deve gerar uma nova estrutura de matriz esparsa e exibido
        //em um gridview próprio - a fazer
        //Multiplicar duas matrizes esparsas, cada uma representada em uma estrutura própria e ambas
        //exibidas em seu próprio gridView.O resultado deve gerar uma nova estrutura de matriz esparsa e
        //exibido em um gridview próprio. - a fazer

        //Criar a estrutura básica da matriz esparsa com dimensão M x N - Construtor - feito
        public ListaLigadaCruzada(int qtdeLinhas, int qtdeColunas)
        {
            qtdeLinhas++;   // A primeira linha é feita de nós cabeças, havendo l-1 linhas de dados
            qtdeColunas++;  // O mesmo para as colunas
            linhas = new Celula[qtdeLinhas]; 
            colunas = new Celula[qtdeColunas]; 

            int i = 0;

            for (; i < qtdeLinhas; i++)
                linhas[i] = new Celula(null, null, i, 0, Double.NaN);

            for (i = 1; i < qtdeColunas; i++)
                colunas[i] = new Celula(null, null, 0, i, Double.NaN);

            linhas[0] = colunas[0];

            for (i = 0; i < qtdeLinhas; i++)
                if (i != qtdeLinhas - 1)
                    linhas[i].Abaixo = linhas[i + 1];
                else
                    linhas[i].Abaixo = linhas[0];

            for (i = 0; i < qtdeColunas; i++)
                if (i != qtdeColunas - 1)
                    colunas[i].Abaixo = colunas[i + 1];
                else
                    colunas[i].Abaixo = colunas[0];

        }

        //Inserir um novo elemento em uma posição(l, c) da matriz - InserirEm - feito
        public bool InserirEm (int linha, int coluna, double valor)
        {
            if (linha > linhas.Length - 1 || linha < 1 || coluna > colunas.Length - 1 || coluna < 1)
                return false;

            linhaAnterior = linhas[linha];
            linhaAtual = linhas[linha].Direita;
            while (linhaAtual.Coluna <= coluna || linhaAtual.Coluna != 0)
            {
                if (linhaAtual.Coluna == coluna)
                    return false;
                linhaAnterior = linhaAtual;
                linhaAtual = linhaAtual.Direita;
            }

            Celula novaCelula = new Celula(linhaAtual, null, linha, coluna, valor);
            linhaAnterior.Direita = novaCelula;

            colunaAnterior = colunas[coluna];
            colunaAtual = colunas[coluna].Abaixo;
            while (colunaAtual.Linha <= linha || colunaAtual.Linha != 0)
            {
                if (colunaAtual.Linha == linha)
                    return false;
                colunaAnterior = colunaAtual;
                colunaAtual = colunaAtual.Abaixo;
            }

            colunaAnterior.Abaixo = novaCelula;
            novaCelula.Abaixo = colunaAtual;

            return true;
        }

        //Retornar o valor de uma posição(l, c) da matriz - ValorDe - feito
        public double ValorDe (int linha, int coluna)
        {
            if (linha > linhas.Length - 1 || linha < 1 || coluna > colunas.Length - 1 || coluna < 1)
                throw new Exception("Valor de linha e/ou coluna inválido");

            linhaAtual = linhas[linha].Direita;
            while (linhaAtual.Coluna <= coluna || linhaAtual.Coluna != 0)
            {
                if (linhaAtual.Coluna == coluna)
                    return linhaAtual.Valor;
                linhaAtual = linhaAtual.Direita;
            }

            return 0.0D;
        }
         
        //Exibir a matriz na tela, em um gridView - ExibirNoGridView - feito
        public void ExibirNoGridView(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv.ColumnCount = colunas.Length - 2;
            dgv.RowCount = linhas.Length - 2;

            linhaAtual = linhas[1].Direita;
            while (linhaAtual.Linha != 0)
            {
                while (linhaAtual.Coluna != 0)
                    dgv.Rows[linhaAtual.Linha - 1].Cells[linhaAtual.Coluna - 1].Value = linhaAtual.Valor;
                linhaAtual = linhaAtual.Abaixo.Direita;
            }
        }

        //Liberar todas as posições alocadas da matriz, incluindo sua estrutura básica - Limpar - feito
        public void Limpar()
        {
            int i;
            for (i = 0; i < colunas.Length; i++)
                colunas[i] = null;
            for (i = 0; i < linhas.Length; i++)
                linhas[i] = null;
            linhaAnterior = linhaAtual = colunaAnterior = colunaAtual = null;
        }

        //Remover o elemento(l, c) da matriz - RemoverElemento - feito
        public bool RemoverElemento (int linha, int coluna)
        {
            if (linha > linhas.Length - 1 || linha < 1 || coluna > colunas.Length - 1 || coluna < 1)
                return false;

            linhaAnterior = linhas[linha];
            linhaAtual = linhas[linha].Direita;
            bool achou = false;
            while (linhaAtual.Coluna <= coluna || linhaAtual.Coluna != 0)
            {
                if (linhaAtual.Coluna == coluna)
                {
                    achou = true;
                    break;
                }
                linhaAnterior = linhaAtual;
                linhaAtual = linhaAtual.Direita;
            }

            if (!achou)
                return false;

            linhaAnterior.Direita = linhaAtual.Direita;

            linhaAtual = null;

            colunaAnterior = colunas[coluna];
            colunaAtual = colunas[coluna].Abaixo;
            while (colunaAtual.Linha < linha)
            {
                colunaAnterior = colunaAtual;
                colunaAtual = colunaAtual.Abaixo;
            }
            colunaAnterior.Abaixo = colunaAtual.Abaixo;
            colunaAtual = null;

            return true;
        }

        //Somar a constante K a todos os elementos da coluna c da matriz - SomaValorEmColuna - feito
        public void SomaValorEmColuna (double valor, int coluna)
        {
            if (coluna < 1 || coluna > colunas.Length - 1)
                throw new Exception("Valor de coluna inválido");

            if (Double.IsNaN(valor))
                throw new Exception("Não é possível somar NaN a um valor");

            colunaAtual = colunas[coluna].Abaixo;
            while (colunaAtual.Linha != 0)
            {
                colunaAtual.Valor += valor;
                colunaAtual = colunaAtual.Abaixo;
            }
        }
    }
}
