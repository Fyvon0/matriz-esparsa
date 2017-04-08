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
        Celula primeiro; // como a lista é ligada cruzada, só precisamos de um nó primeiro que aponta para
                         // as linhas e para as colunas
        Celula atual;
        Celula anterior;
        int linhas;
        int colunas;

        //Criar a estrutura básica da matriz esparsa com dimensão M x N - Construtor - feito - atualizado
        //Inserir um novo elemento em uma posição(l, c) da matriz - InserirEm - feito
        //Ler um arquivo texto com as coordenadas e os valores não nulos, armazenando-os na matriz - a fazer
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

            int i = 0;

            anterior = primeiro = new Celula(null, null, 0, 0, Double.NaN);

            for (; i < qtdeLinhas; i++)
            {
                atual = new Celula(null, null, i, 0, Double.NaN);
                atual.Direita = atual; // não existe dado ainda, logo o nó aponta para si mesmo
                anterior.Abaixo = atual; // faz o nó anterior apontar para o nó atual
                anterior = atual;
            }
            atual.Abaixo = primeiro; // faz o último nó cabeça nas linhas apontar para o primeiro

            for (i = 0; i < qtdeColunas; i++)
            {
                atual = new Celula(null, null, i, 0, Double.NaN);
                atual.Abaixo = atual; // não existe dado ainda, logo o nó aponta para si mesmo
                anterior.Direita = atual; // faz o nó anterior apontar para o nó atual
                anterior = atual;
            }
            atual.Direita = primeiro; // faz o último nó cabeça das colunas apontar para o primeiro
        }

        //Inserir um novo elemento em uma posição(l, c) da matriz - InserirEm - feito - atualizado
        public bool InserirEm (int linha, int coluna, double valor)
        {
            if (linha > linhas || linha < 1 || coluna > colunas || coluna < 1) // se a posição passada por parâmetro for inválida,
                return false;                                                  // retorna falso

            if (Double.IsNaN(valor) || valor == 0) // nós não queremos armazenar nada nulo
                return false;

            PosicionaPonteiros(linha, 'L');

            while (atual.Coluna <= coluna && atual.Coluna != 0)
            {
                if (atual.Coluna == coluna) //se já existe algo na mesma linha e na mesma coluna
                    return false;            //retorna falso pois não pode inserir
                anterior = atual;
                atual = atual.Direita;
            }

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

        //Retornar o valor de uma posição(l, c) da matriz - ValorDe - feito - atualizado
        public double ValorDe (int linha, int coluna)
        {
            if (linha > linhas || linha < 1 || coluna > colunas || coluna < 1)
                throw new Exception("Valor de linha e/ou coluna inválido");

            PosicionaPonteiros(linha, 'L');

            while (atual.Coluna <= coluna && atual.Coluna != 0)
            {
                if (atual.Coluna == coluna)
                    return atual.Valor;
                atual = atual.Direita;
            }

            return Double.NaN;
        }
         
        //Exibir a matriz na tela, em um gridView - ExibirNoGridView - feito - atualizado
        public void ExibirNoGridView(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv.ColumnCount = colunas;
            dgv.RowCount = linhas;

            atual = primeiro.Abaixo.Direita;
            while (atual.Linha != 0)
            {
                while (atual.Coluna != 0)
                {
                    dgv.Rows[atual.Linha - 1].Cells[atual.Coluna - 1].Value = atual.Valor;
                    atual = atual.Direita;
                }
                atual = atual.Abaixo.Direita;
            }
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
            while (atual.Linha != 0)
            {
                atual.Valor += valor;
                if (atual.Valor == 0)
                    RemoverElemento(atual.Linha, atual.Coluna);
                atual = atual.Abaixo;
            }
        }


        //Somar duas matrizes esparsas, cada uma representada em uma estrutura própria e ambas exibidas
        //em seu próprio gridView.O resultado deve gerar uma nova estrutura de matriz esparsa e exibido
        //em um gridview próprio - SomarMatrizes - feito - atualizado
        public ListaLigadaCruzada SomarMatrizes (ListaLigadaCruzada matriz1, ListaLigadaCruzada matriz2)
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
        public ListaLigadaCruzada MultiplicarMatrizes (ListaLigadaCruzada matriz1, ListaLigadaCruzada matriz2)
        {
            if (matriz1.colunas.Length != matriz2.linhas.Length)
                throw new Exception("Não é possível multiplicar matrizes se o número de colunas da primeira for diferentes do número de linhas da segunda");

            ListaLigadaCruzada result = new ListaLigadaCruzada(matriz1.linhas.Length, matriz2.colunas.Length);
            matriz1.atual = matriz1.linhas[1].Direita;
            matriz2.atual = matriz2.colunas[1].Abaixo;

            while (matriz1.atual.Linha != 0)
            {
                while(matriz2.atual.Coluna != 0)
                { }
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
