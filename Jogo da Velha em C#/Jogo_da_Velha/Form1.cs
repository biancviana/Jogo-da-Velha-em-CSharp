using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo_da_Velha
{
    public partial class Form1 : Form
    {
        int Xplayer = 0, Oplayer = 0, empatesPontos = 0, rodadas = 0;
        bool turno = true; /*pra definir os turnos dos jogadores, X ou O.
        // true --> X & false --> O. */
        bool jogo_final = false;
        string[] texto = new string[9];

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            btn.Text = "";
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button7.Text = "";
            button8.Text = "";
            rodadas = 0;
            jogo_final = false;

            for (int i = 0; i < 9; i++) // resetar o que tem dentro das ARRAYs.
            {
                texto[i] = "";
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            // btn.Text = "X"; --> meu botton referência
            Button btn = (Button)sender; // botton clicável, pra sempre que eu clicar em qql outro botton, esse objeto seja a referência.
            int buttonIndex = btn.TabIndex; // se eu clicar no botão 0, a variável buttonIndex será igual a 0, e assim sucessivamente.

            if (btn.Text == "" && jogo_final == false)
            {

                if (turno) // pra quando o turno for true, ou seja, X.
                {
                    btn.Text = "X";
                    texto[buttonIndex] = btn.Text; // no [buttonIndex] estou falando qual o índice da minha ARRAY.
                                                   // ou seja, se eu clicar no botão 0, ele irá colocar dentro do índice 0.
                    rodadas++;
                    turno = !turno; // para os turnos irem se alternando. se está true, vai ficar false.
                    Checagem(1);
                }

                else // pra quando o turno for false, a vez da O.
                {
                    btn.Text = "O";
                    texto[buttonIndex] = btn.Text; // vai verificar se o jogador ganhou ou deu empate.
                    rodadas++;
                    turno = !turno; // para os turnos irem se alternando. se está false, vai ficar true.
                    Checagem(2);
                } // final de estrutura
            }
        } // final do método do botão 


        void Vencedor(int PlayerQueGanhou)
        {
            jogo_final = true; // quando algum jogador ganhar ou der empate, o jogo se encerra e o jogador não pode ficar clicando. 

            if (PlayerQueGanhou == 1)
            {
                Xplayer++;
                Xpontos.Text = Convert.ToString(Xplayer);
                MessageBox.Show("Jogador X ganhou!");
                turno = true;
;           }
            else
            {
                Oplayer++;
                Opontos.Text = Convert.ToString(Oplayer);
                MessageBox.Show("Jogador O ganhou!");
                turno = false;
            }
        }


        void /* método sem retorno */ Checagem(int ChecagemPlayer) // vai checar se o jogador 1 ou 2 ganhou.
                                                                   // quando a ChecagemPlayer for 1, ele vai checar pro jogador X.
                                                                   // quando a ChecagemPlayer for 2, ele vai checar pro jogador O.
        {
            string suporte = "";

            if (ChecagemPlayer == 1)
            {
                suporte = "X";
            }

            else
            {
                suporte = "O";

            } // final do suporte.

            for (int horizontal = 0; horizontal < 8; horizontal += 3) // a checagem aumenta de 3 em 3. começa horizontalmente no índice 0 para o 2; e pula do 0 para o índice 3 da linha 2.
            {
                if (suporte == texto[horizontal]) // se o suporte for igual ao que tem dentro do conteúdo da ARRAY, X ou O, aí sim a verificação será feita.
                {
                    // CHECAGEM NA HORIZONTAL:

                    if (texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 2])
                    {
                        Vencedor(ChecagemPlayer);
                        return;
                    } // final da checagem na horizontal
                }
            } // final do looping FOR horizontal


                 

            for (int vertical = 0; vertical < 3 ; vertical++) // o looping vai acontecer apenas 3 vezes, começando do 0, aumentando 1 e confirmando nas colunas, em qual coluna foi ganhado na vertical.
            {
                if (suporte == texto[vertical]) // se o suporte for igual ao que tem dentro do conteúdo da ARRAY, X ou O, aí sim a verificação será feita.
                {
                    // CHECAGEM NA VERTICAL

                    if (texto[vertical] == texto[vertical + 3] && texto[vertical] == texto[vertical + 6]) //por exemplo, se eu quero descobrir o que está abaixo do índice 0, vou aumentar 3 para descobrir.
                                                                                                          // e pra ver o que tem embaixo da minha ARRAY, aumento de 6 em 6.                          
                    {
                        Vencedor(ChecagemPlayer);
                        return;
                    } // final da checagem na vertical
                }
            } // final do looping FOR vertical


            // CHECAGEM NA DIAGONAL PRINCIPAL:

            if (texto[0] == suporte)
            {

                if (texto[0] == texto[4] && texto[0] == texto[8])
                {
                    Vencedor(ChecagemPlayer);
                    return;
                } // fim da diagonal principal 
            }


                // CHECAGEM NA DIAGONAL SECUNDÁRIA:

                if (texto[2] == suporte)
                {
                    if (texto[2] == texto [4] && texto [2] == texto[6])
                    {
                       Vencedor(ChecagemPlayer);
                       return;
                    } // fim da diagonal secundária
                        
                }


                if (rodadas == 9 && jogo_final == false) // o jogo estiver rodando.
            {
                empatesPontos++;
                empates.Text = Convert.ToString(empatesPontos);
                MessageBox.Show("Empate!");
                jogo_final = true; // jogo vai ter terminado.
                return;
            }                

            



        }
    }
}



