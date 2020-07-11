using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Proyecto_Cartas21
{
    class Maso
    {
        private int numero;
        private Palo figura;
        private string representacion;
        private int valor;

        //gets y sets
        public int Numero
        {
            get
            {
                return numero;
            }
            set
            {
                numero = value;
            }
        }
        public Palo Fig
        {
            get
            {
                return figura;
            }
            set
            {
                figura = value;
            }
        }
        public string Representacion
        {
            get
            {
                return representacion;
            }
            set
            {
                representacion = value;
            }
        }
        public int Valor
        {
            get
            {
                return valor;
            }
            set
            {
                valor = value;
            }
        }

        //constructor
        public Maso(int n, int figura, string represent, int valor)
        {
            numero = n;
            this.figura = (Palo)figura;
            representacion = represent;
            this.valor = valor;
        }

        public void TString(int a, int b)
        {
            char fig;
            int aux;
            aux = (int)(this.figura);

            if (aux == 1)
            {
                fig = 'D';
            }
            else if (aux == 2)
            {
                fig = 'T';
            }
            else if (aux == 3)
            {
                fig = 'C';
            }
            else
            {
                fig = 'P';
            }
            Console.SetCursorPosition(a, b - 1);
            Console.WriteLine("/========\\");
            Console.SetCursorPosition(a, b++);
            Console.WriteLine("║        ║");
            Console.SetCursorPosition(a, b++);
            Console.WriteLine("║        ║");
            Console.SetCursorPosition(a, b++);
            Console.WriteLine("║        ║");
            Console.SetCursorPosition(a, b++);
            Console.WriteLine("║        ║");
            Console.SetCursorPosition(a, b++);
            Console.WriteLine("║        ║");
            Console.SetCursorPosition(a, b++);
            Console.WriteLine("║        ║");
            Console.SetCursorPosition(a, b++);
            Console.WriteLine("║        ║");
            Console.SetCursorPosition(a, b++);
            Console.WriteLine("\\========/");
            Console.SetCursorPosition(a + 4, b - 5);
            Console.WriteLine("{0}{1}", this.representacion, fig);
        }



    }


    public enum Palo
    {
        Diamante = 1, Trebol = 2, Corazon = 3, Pique = 4,
    }



    class Program
    {
        static ArrayList LlenarMazo()
        {
            int numc = 0, f, num, v;
            string reprecentacion;
            ArrayList m = new ArrayList();
            for (v = 1, num = 1; numc < 52; num++)
            {
                if (num == 1 || num > 10)
                {
                    if (num == 1)
                        reprecentacion = "A";
                    else if (num == 11)
                        reprecentacion = "J";
                    else if (num == 12)
                        reprecentacion = "Q";
                    else
                        reprecentacion = "K";
                }
                else
                    reprecentacion = Convert.ToString(num);
                for (f = 4; f >= 1; f--, numc++)
                {
                    if (num != 1)
                    {
                        m.Add(new Maso(num, f, reprecentacion, v));
                    }
                    else
                        m.Add(new Maso(num, f, reprecentacion, 11));
                }
                if (v < 10)
                    v++;
            }
            return m;
        }


        //metodo para barajar
        static Stack Barajar(ArrayList mo)
        {
            Random rnd = new Random();
            Stack m = new Stack();
            int numcartas = 52, i;
            for (; numcartas > 0; numcartas--)
            {
                i = rnd.Next(0, numcartas);
                m.Push(mo[i]);
                mo.Remove(mo[i]);
            }
            return m;
        }


        static void Main(string[] args)
        {
            int op = 1;
            Stack mazo = new Stack();
            ArrayList mazoOrdenado = new ArrayList();
            while (op != 2)
            {
                mazoOrdenado = LlenarMazo();

                mazo = Barajar(mazoOrdenado);

                op = Menu();
                Console.Clear();
                Juego(mazo);
                op = 1;
            }
        }


        //funcion Suma
        static int Suma(Maso[] cj1)
        {
            int i, suma = 0;
            for (i = 0; i < cj1.Length; i++)
            {
                if (cj1[i] == null)
                    break;
                suma = +cj1[i].Valor;
            }
            return suma;

        }

        //funcion Juego
        static void Juego(Stack mazo)
        {
            int k, sumaj1, sumaj2;
            int a, b;
            string opc = "S", op = "S";
            bool ganador;
            while (op != "N" && mazo.Count >= 10)
            {
                opc = "S";
                ganador = false;
                k = 0;
                a = 1;
                b = 14;
                sumaj1 = 0;
                sumaj2 = 0;
                Console.Clear();
                Maso[] cj1 = new Maso[5];
                Maso[] cj2 = new Maso[5];
                cj1[k] = (Maso)mazo.Pop();
                cj1[k].TString(a, b);
                sumaj1 += Suma(cj1);
                a += 11;
                for (k = 1; opc == "S"; k++, a = a + 11, opc = "S")
                {
                    if (k >= 5)
                        break;
                    cj1[k] = (Maso)mazo.Pop();
                    cj1[k].TString(a, b);
                    sumaj1 += Suma(cj1);
                    if (sumaj1 > 21)
                    {
                        Console.SetCursorPosition(1, 1);
                        Console.Write("                                                             ");
                        Console.SetCursorPosition(1, 1);
                        Console.Write("Perdiste!!! (presiona una tecla para continuar)...");
                        Console.ReadKey();
                        ganador = true;
                        break;
                    }
                    else if (sumaj1 == 21)
                    {
                        Console.SetCursorPosition(1, 1);
                        Console.Write("                                                             ");
                        Console.SetCursorPosition(1, 1);
                        Console.Write("Ganaste!!! :) (Presiona una tecla para continuar)...");
                        Console.SetCursorPosition(1, 1);
                        Console.ReadKey();
                        ganador = true;
                        break;
                    }
                    if (ganador)
                        break;
                    Console.SetCursorPosition(1, 1);
                    Console.Write("                                                             ");
                    Console.SetCursorPosition(1, 1);
                    Console.Write("Desea otra carta?(s/n)...");

                    opc = Console.ReadLine().ToUpper();
                    while (opc != "S" && opc != "N")
                    {
                        Console.SetCursorPosition(1, 1);
                        Console.Write("                                                             ");
                        Console.SetCursorPosition(1, 1);
                        Console.Write("Desea otra carta?(s/n)...");
                        opc = Console.ReadLine().ToUpper();
                    }
                    if (opc == "N")
                        break;

                }
                if (!ganador)
                {
                    k = 0;
                    a = 1;
                    b = 4;
                    cj2[k] = (Maso)mazo.Pop();
                    cj2[k].TString(a, b);
                    sumaj2 += Suma(cj2);
                    k++;
                    a += 11;
                    cj2[k] = (Maso)mazo.Pop();
                    cj2[k].TString(a, b);
                    sumaj2 += Suma(cj2);
                    k++;
                    a += 11;
                    Thread.Sleep(500);
                    for (; sumaj2 < 16; k++, a += 11)
                    {
                        cj2[k] = (Maso)mazo.Pop();
                        cj2[k].TString(a, b);
                        sumaj2 += Suma(cj2);
                        Thread.Sleep(500);
                    }
                    if (sumaj2 > 21)
                    {
                        Console.SetCursorPosition(1, 1);
                        Console.Write("                                                             ");
                        Console.SetCursorPosition(1, 1);
                        Console.Write("Ganaste!!! :)              ");
                        Console.ReadKey();
                    }

                    else if (sumaj1 > sumaj2)
                    {
                        Console.SetCursorPosition(1, 1);
                        Console.Write("                                                             ");
                        Console.SetCursorPosition(1, 1);
                        Console.Write("Ganaste el Juego!!!!(presiona una tecla para continuar)     ");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.SetCursorPosition(1, 1);
                        Console.Write("                                                             ");
                        Console.SetCursorPosition(1, 1);
                        Console.Write("Perdistee el Juego!!!!                  ");
                        Console.ReadKey();
                    }
                }
                if (mazo.Count < 10)
                    break;
                Console.SetCursorPosition(1, 1);
                Console.Write("                                                             ");
                Console.SetCursorPosition(1, 1);
                Console.Write("Desea continuar jugando?(s/n)...    ");
                op = Console.ReadLine().ToUpper();
                while (op != "S" && op != "N")
                {
                    Console.SetCursorPosition(1, 1);
                    Console.Write("                                                             ");
                    Console.SetCursorPosition(1, 1);
                    Console.Write("Desea continuar jugando?(s/n)...    ");
                    op = Console.ReadLine().ToUpper();
                }
            }


        }


        //menu principal
        static int Menu()
        {
            int operacion = 3;
            while (operacion != 1) //&& operacion != 2)
            {
                Console.Clear();
                Console.Write("***Bienvenido al juego 21***\n\n");
                Console.WriteLine("Presione el NUMERO '1' para empezar el juego...");
                Console.WriteLine("Presione cualquier numero para salir");

                operacion = Entero();


                if (operacion != 1)
                {

                    Environment.Exit(0);

                }

            }
            return operacion;
        }

        static int Entero()
        {
            int num;
            for (; ; )
            {
                try
                {
                    num = Convert.ToInt32(Console.ReadLine());
                    return num;
                }
                catch//en caso de que no sea entero
                {
                    Console.WriteLine("Ingresó una opcion inválida");
                    Menu();
                }
            }
        }
    }
}
