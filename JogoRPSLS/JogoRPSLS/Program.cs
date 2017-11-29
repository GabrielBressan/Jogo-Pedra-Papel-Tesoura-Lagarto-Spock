using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoRPSLS
{
    class Program
    {
        static void Main(string[] args)
        {
            startGame();
        }
        static void startGame() //executa o game | run the game
        {
            string[] aTipo = new string[] { "Pedra", "Papel", "Tesoura", "Lagarto", "Spock" };
            int iVal1 = 0;
            int iVal2 = 0;
            int result = 0;
        Start:
            iVal1 = RecebeNum();
            Console.WriteLine(" ");
            Console.WriteLine("Você selecionou: {0}", aTipo[iVal1]);
            iVal2 = NumAleatorio();
            Console.WriteLine("O computador selecionou: {0}", aTipo[iVal2]);
            Console.WriteLine(" ");
            result = CalcResult(iVal1, iVal2);
            switch (result)
            {
                case 0:
                    Console.WriteLine("Você Ganhou!");
                    break;
                case 1:
                    Console.WriteLine("O Computador Ganhou!");
                    break;
                case 2:
                    Console.WriteLine("Houve um empate!");
                    break;
                default:
                    Console.WriteLine("Erro!");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
            goto Start;
        }
        static int RecebeNum() //recebe a escolha do jogador | Player choice
        {
            int aux;
        New:
            Console.WriteLine("Jogando Pedra Papel Tesoura Lagarto Spock ");
            Console.WriteLine(" ");
            Console.WriteLine("Selecione o tipo: ");
            Console.WriteLine("Pedra=0, Papel=1, Tesoura=2, Lagarto=3, Spock=4 ");
            try
            {
                aux = Convert.ToInt16(Console.ReadLine());
                if (aux > 4) //tratamento de exceção acessar posição invalida do vetor | 
                {
                    Console.WriteLine("Selecione um tipo válido!!");
                    Console.ReadKey();
                    Console.Clear();
                    goto New;
                }
            }
            catch (Exception) //tratamento de exceção entrada invalida (letra, vazio, ...) | 
            {
                Console.WriteLine("Selecione um tipo válido!!");
                Console.ReadKey();
                Console.Clear();
                goto New;
            }
            return aux;
        }
        static int NumAleatorio() //gera numero aleatorio (escolha do computador)
        {
            Random rdn = new Random();
            int iNumaleatorio;
            iNumaleatorio = rdn.Next(0, 5);
            return iNumaleatorio;
        }
        static int CalcResult(int x, int y) //verifica quem ganha o jogo
        {
            int res = 0;
            if (x == 0 && y == 0 || x == 1 && y == 1 || x == 2 && y == 2 || x == 3 && y == 3 || x == 4 && y == 4)
            {
                res = 2; //empate | tie in the game
            }
            else if (x == 0 && y == 1 || x == 0 && y == 4 || x == 1 && y == 2 || x == 1 && y == 3 || x == 2 && y == 4 || x == 2 && y == 0 || x == 3 && y == 0 || x == 4 && y == 1 || x == 3 && y == 2 || x == 4 && y == 3)
            {
                res = 1; //computador ganha | you lose
            }
            else if (x == 0 && y == 2 || x == 0 && y == 3 || x == 1 && y == 4 || x == 2 && y == 3 || x == 3 && y == 4 || x == 1 && y == 0 || x == 4 && y == 0 || x == 2 && y == 1 || x == 3 && y == 1 || x == 4 && y == 2)
            {
                res = 0; //vc ganha | you win
            }
            return res;
        }
    }
}