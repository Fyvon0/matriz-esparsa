using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Matriz_Esparsa
{
    class ListaLigadaCruzada
    {
        Celula primeiro; // como a lista é ligada cruzada, só precisamos de um nó primeiro que aponta para
                         // as linhas e para as colunas
        Celula atual;
        Celula anterior;
        int linhas;
        int colunas;

        //Criar a estrutura básica da matriz esparsa com dimensão M x N - Construtor - feito - atualizado
        //Inserir um novo elemento em uma posição(l, c) da matriz - InserirEm - feito
        //Ler um arquivo texto com as coordenadas e os valores não nulos, armazenando-os na matriz - LerArquivo - a fazer
        //Retornar o valor de uma posição(l, c) da matriz - ValorDe - feito
        //Exibir a matriz na tela, em um gridView - ExibirNoGridView - feito
        //Liberar todas as posições alocadas da matriz, incluindo sua estrutura básica - Limpar - feito
        //Remover o elemento(l, c) da matriz - RemoverElemento - feito
        //Somar a constante K a todos os elementos da coluna c da matriz - SomaValorEmColuna - feito
        //Somar duas matrizes esparsas, cada uma representada em uma estrutura própria e ambas exibidas
        //em seu próprio gridView.O resultado deve gerar uma nova estrutura de matriz esparsa e exibido
        //em um gridview próprio - SomaMatrizes - fazendo
        //Multiplicar duas matrizes esparsas, cada uma representada em uma estrutura própria e ambas
        //exibidas em seu próprio gridView.O resultado deve gerar uma nova estrutura de matriz esparsa e
        //exibido em um gridview próprio. - a fazer

        //Criar a estrutura básica da matriz esparsa com dimensão M x N - Construtor - feito - atualizado
        public ListaLigadaCruzada(int qtdeLinhas, int qtdeColunas)
        {
            if (qtdeLinhas <= 0 || qtdeColunas <= 0)
                throw new Exception("Quantidade inválida de linhas ou colunas");

            linhas = qtdeLinhas;
            colunas = qtdeColunas;

            int i = 1;

            anterior = primeiro = new Celula(null, null, 0, 0, Double.NaN);

            for (; i <= qtdeLinhas; i++)
            {
                atual = new Celula(null, null, i, 0, Double.NaN);
                atual.Direita = atual; // não existe dado ainda, logo o nó aponta para si mesmo
                anterior.Abaixo = atual; // faz o nó anterior apontar para o nó atual
                anterior = atual;
            }
            atual.Abaixo = primeiro; // faz o último nó cabeça nas linhas apontar para o primeiro

            anterior = primeiro;
            for (i = 1; i <= qtdeColunas; i++)
            {
                atual = new Celula(null, null, 0, i, Double.NaN);
                atual.Abaixo = atual; // não existe dado ainda, logo o nó aponta para si mesmo
                anterior.Direita = atual; // faz o nó anterior apontar para o nó atual
                anterior = atual;
            }
            atual.Direita = primeiro; // faz o último nó cabeça das colunas apontar para o primeiro
        }

        public ListaLigadaCruzada(String nomeArquivo)
        {
            this.LerArquivo(nomeArquivo);
        }

        //Inserir um novo elemento em uma posição(l, c) da matriz - InserirEm - feito - atualizado
        public bool InserirEm (int linha, int coluna, double valor)
        {
            if (linha > linhas || linha < 1 || coluna > colunas || coluna < 1) // se a posição passada por parâmetro for inválida,
                throw new Exception("Posição passada por parâmetro inválida");

            if (Double.IsNaN(valor) || valor == 0) // nós não queremos armazenar nada nulo
                return false;

            PosicionaPonteiros(linha, 'L');

            while (atual.Coluna < coluna && atual.Coluna != 0)
            {
                anterior = atual;
                atual = atual.Direita;
            }

            if (atual.Coluna == coluna) //se já existe algo na mesma linha e na mesma coluna
                return false;           //retorna falso pois não pode inserir

            Celula novaCelula = new Celula(atual, null, linha, coluna, valor);
            anterior.Direita = novaCelula;

            PosicionaPonteiros(coluna, 'C');

            while (atual.Linha <= linha && atual.Linha != 0)
            {
                anterior = atual;
                atual = atual.Abaixo;
            }

            anterior.Abaixo = novaCelula;
            novaCelula.Abaixo = atual;

            return true;
        }

        public void LerArquivo (String nomeArquivo)
        {
            this.Limpar();
            StreamReader arquivo = new StreamReader(nomeArquivo);
            String linha;
            linhas = colunas = 0;
            primeiro = new Celula(null, null, 0, 0, Double.NaN);
            primeiro.Abaixo = primeiro;
            primeiro.Direita = primeiro;
            while ((linha = arquivo.ReadLine()) != null)
            {
                int lin = Convert.ToInt32(linha.Substring(0, 3));
                if (lin > linhas)
                {
                    anterior = primeiro;
                    while (anterior.Abaixo != primeiro)
                        anterior = anterior.Abaixo;
                    for (int i = linhas; i <= lin; i++)
                    {
                        atual = new Celula(null, null, i, 0, Double.NaN);
                        atual.Direita = atual; // não existe dado ainda, logo o nó aponta para si mesmo
                        anterior.Abaixo = atual; // faz o nó anterior apontar para o nó atual
                        anterior = atual;
                    }
                    atual.Abaixo = primeiro;
                    linhas = lin;
                }
                int col = Convert.ToInt32(linha.Substring(3, 3));
                if (col > colunas)
                {
                    anterior = primeiro;
                    while (anterior.Direita != primeiro)
                        anterior = anterior.Direita;
                    for (int i = colunas; i <= col; i++)
                    {
                        atual = new Celula(null, null, 0, i, Double.NaN);
                        atual.Abaixo = atual; // não existe dado ainda, logo o nó aponta para si mesmo
                        anterior.Direita = atual; // faz o nó anterior apontar para o nó atual
                        anterior = atual;
                    }
                    atual.Direita = primeiro;
                    colunas = col;
                }

                double val = Convert.ToDouble(linha.Substring(6));
                this.InserirEm(lin, col, val);
            }

            arquivo.Close();
        }

        //Retornar o valor de uma posição(l, c) da matriz - ValorDe - feito - atualizado
        public double ValorDe (int linha, int coluna)
        {
            if (linha > linhas || linha < 1 || coluna > colunas || coluna < 1)
                return Double.NaN;

            PosicionaPonteiros(linha, 'L');

            while (atual.Coluna <= coluna && atual.Coluna != 0)
            {
                if (atual.Coluna == coluna)
                    return atual.Valor;
                atual = atual.Direita;
            }

            return 0;
        }
         
        //Exibir a matriz na tela, em um gridView - ExibirNoGridView - feito - atualizado
        public void ExibirNoGridView(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv.ColumnCount = colunas;
            dgv.RowCount = linhas;

            for (int l = 1; l <= linhas; l++)
            {
                dgv.Rows[l - 1].HeaderCell.Value = String.Format("{0}", dgv.Rows[l-1].Index + 1);
                for (int c = 1; c <= colunas; c++)
                    dgv.Rows[l - 1].Cells[c - 1].Value = this.ValorDe(l, c);
            }

            for (int c = 1; c <= colunas; c++)
                dgv.Columns[c - 1].HeaderCell.Value = String.Format("{0}", dgv.Columns[c-1].Index + 1);
        }

        //Liberar todas as posições alocadas da matriz, incluindo sua estrutura básica - Limpar - feito - atualizado
        public void Limpar()
        {
            atual = anterior = primeiro = null;
            linhas = colunas = 0;
        }

        //Remover o elemento(l, c) da matriz - RemoverElemento - feito - atualizado
        public bool RemoverElemento (int linha, int coluna)
        {
            if (linha > linhas|| linha < 1 || coluna > colunas || coluna < 1)
                return false;

            PosicionaPonteiros(linha, 'L');
            bool achou = false;
            while (atual.Coluna <= coluna && atual.Coluna != 0)
            {
                if (atual.Coluna == coluna)
                {
                    achou = true;
                    break;
                }
                anterior = atual;
                atual = atual.Direita;
            }

            if (!achou)
                return false;

            anterior.Direita = atual.Direita;
            atual = null;

            PosicionaPonteiros(coluna, 'C');
            while (atual.Linha < linha)
            {
                anterior = atual;
                atual = atual.Abaixo;
            }
            anterior.Abaixo = atual.Abaixo;

            return true;
        }

        //Somar a constante K a todos os elementos da coluna c da matriz - SomaValorEmColuna - feito - atualizado
        public void SomaValorEmColuna (double valor, int coluna)
        {
            if (coluna < 1 || coluna > colunas)
                throw new Exception("Valor de coluna inválido");

            if (Double.IsNaN(valor))
                throw new Exception("Não é possível somar NaN a um valor");

            PosicionaPonteiros(coluna, 'C');
            for (int i = 1; i <= linhas; i++)
            {
                if (atual.Linha == i)
                {
                    atual.Valor += valor;
                    if (atual.Valor == 0)
                        RemoverElemento(atual.Linha, atual.Coluna);
                    atual = atual.Abaixo;
                }
                else
                    this.InserirEm(i, coluna, valor);
            }
        }


        //Somar duas matrizes esparsas, cada uma representada em uma estrutura própria e ambas exibidas
        //em seu próprio gridView.O resultado deve gerar uma nova estrutura de matriz esparsa e exibido
        //em um gridview próprio - SomarMatrizes - feito - atualizado
        public static ListaLigadaCruzada SomarMatrizes (ListaLigadaCruzada matriz1, ListaLigadaCruzada matriz2)
        {
            if (matriz1.linhas != matriz2.linhas|| matriz1.colunas != matriz2.colunas)
                throw new Exception("Não é possível somar matrizes com quantidade de linhas e colunas diferentes");

            ListaLigadaCruzada result = new ListaLigadaCruzada(matriz1.linhas, matriz1.colunas);

            matriz1.atual = matriz1.primeiro.Abaixo.Direita;
            matriz2.atual = matriz2.primeiro.Abaixo.Direita;
            while (matriz1.atual.Linha != 0) //as duas matrizes andarão juntas, não havendo necessidade para se checar duas vezes
            {
                while (matriz1.atual.Coluna != 0 && matriz2.atual.Coluna != 0)
                {
                    if (matriz1.atual.Coluna < matriz2.atual.Coluna)
                    {
                        result.InserirEm(matriz1.atual.Linha, matriz1.atual.Coluna, matriz1.atual.Valor);
                        matriz1.atual = matriz1.atual.Direita;
                        continue;
                    }
                    if (matriz1.atual.Coluna == matriz2.atual.Coluna)
                    {
                        if (matriz1.atual.Valor + matriz2.atual.Valor != 0)
                            result.InserirEm(matriz1.atual.Linha, matriz1.atual.Coluna, (matriz1.atual.Valor + matriz2.atual.Valor));
                        matriz1.atual = matriz1.atual.Direita;
                        matriz2.atual = matriz2.atual.Direita;
                        continue;
                    }
                    result.InserirEm(matriz2.atual.Linha, matriz2.atual.Coluna, matriz2.atual.Valor);
                    matriz2.atual = matriz2.atual.Direita;
                }
                if (matriz1.atual.Coluna == 0)
                {
                    while (matriz2.atual.Coluna != 0)
                    {
                        result.InserirEm(matriz2.atual.Linha, matriz2.atual.Coluna, matriz2.atual.Valor);
                        matriz2.atual = matriz2.atual.Direita;
                    }
                }
                if (matriz2.atual.Coluna == 0)
                {
                    while (matriz1.atual.Coluna != 0)
                    {
                        result.InserirEm(matriz1.atual.Linha, matriz1.atual.Coluna, matriz1.atual.Valor);
                        matriz1.atual = matriz1.atual.Direita;
                    }
                }
                matriz1.atual = matriz1.atual.Abaixo.Direita;
                matriz2.atual = matriz2.atual.Abaixo.Direita;
            }
            return result;
        }

        //Multiplicar duas matrizes esparsas, cada uma representada em uma estrutura própria e ambas
        //exibidas em seu próprio gridView.O resultado deve gerar uma nova estrutura de matriz esparsa e
        //exibido em um gridview próprio. - MultiplicarMatrizes - fazendo
        public static ListaLigadaCruzada MultiplicarMatrizes (ListaLigadaCruzada matriz1, ListaLigadaCruzada matriz2)
        {
            if (matriz1.colunas != matriz2.linhas)
                throw new Exception("Não é possível multiplicar matrizes se o número de colunas da primeira for diferentes do número de linhas da segunda");

            ListaLigadaCruzada result = new ListaLigadaCruzada(matriz1.linhas, matriz2.colunas);
            double valor = 0;

            for (int i = 1; i <= matriz1.linhas; i++)
                for (int j = 1; j <= matriz2.colunas; j++)
                {
                    for (int k = 1; k <= matriz1.colunas; k++)
                        valor += (matriz1.ValorDe(i, k) * matriz2.ValorDe(k, j));
                    result.InserirEm(i,j,valor);
                    valor = 0;
                }

            return result;
        }

        private bool PosicionaPonteiros (int indice, char eixo)
        {
            if (indice < 1) 
                return false;

            if (eixo != 'L' && eixo != 'C' && eixo != 'l' && eixo !='c')
                throw new Exception("Eixo indicado inválido");

            if (eixo == 'L' || eixo == 'l')
                if (indice > linhas)
                    return false;
                else
                {
                    anterior = atual = primeiro;
                    while (atual.Linha < indice) // percorre os nós cabeça a busca da linha procurada
                        atual = anterior = atual.Abaixo;
                    atual = atual.Direita;
                }
            else
                if (indice > colunas)
                    return false;
                else
                {
                    anterior = atual = primeiro;
                    while (atual.Coluna < indice) // percorre os nós cabeça a busca da linha procurada
                        atual = anterior = atual.Direita;
                    atual = atual.Abaixo;
                }

            return true;
        }
    }
}
