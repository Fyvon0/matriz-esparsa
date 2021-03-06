﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matriz_Esparsa
{
    class Celula
    {
        Celula direita; // ponteiro para a o próximo elemento não nulo na mesma linha
        Celula abaixo; // ponteiro para a o próximo elemento não nulo na mesma coluna
        int linha, coluna;
        double valor;
        
        public Celula(Celula celulaDireita, Celula celulaAbaixo, int linhaCelula, int colunaCelula, double valorCelula)
        {
            direita = celulaDireita;
            abaixo = celulaAbaixo;
            linha = linhaCelula;
            coluna = colunaCelula;
            valor = valorCelula;
        }

        public Celula Direita
        {
            get
            {
                return direita;
            }

            set
            {
                direita = value;
            }
        }

        public Celula Abaixo
        {
            get
            {
                return abaixo;
            }

            set
            {
                abaixo = value;
            }
        }

        public int Linha
        {
            get
            {
                return linha;
            }

            set
            {
                linha = value;
            }
        }

        public int Coluna
        {
            get
            {
                return coluna;
            }

            set
            {
                coluna = value;
            }
        }

        public double Valor
        {
            get
            {
                return valor;
            }

            set
            {
                if (value == 0.0D || Double.IsNaN(value))
                    return;
                valor = value;
            }
        }

    }
}
