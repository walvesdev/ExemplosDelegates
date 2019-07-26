using System;
using System.Collections.Generic;

namespace ExemplosDelegate
{

    class Program
    {

        /*
         *  Delegates Action tem um unico parametro e não retorna valor;
         *  Delegates Pedicate testa uma condição e retorna booleano;
         * 
         * 
         */
        static List<Cliente> clientes = new List<Cliente>()
            {
                new Cliente(){ ID = 1, Nome="Willian"},
                new Cliente(){ ID = 2, Nome="Aline"},
                new Cliente(){ ID = 3, Nome="Bruna"},
                new Cliente(){ ID = 4, Nome="Wesley"},
                new Cliente(){ ID = 5, Nome="Leny"},
                new Cliente(){ ID = 5, Nome="Mariana"},
            };

        static Action<Cliente> mostrarAction = new Action<Cliente>(Mostrar);
        static Action<Cliente> mostrarActionLambda = new Action<Cliente>(c => Console.WriteLine(string.Format("Cliente chamado {0}", c.Nome)));

        static Predicate<Cliente> containsPredicate = new Predicate<Cliente>(Contains);
        static Predicate<Cliente> containsPredicateLambda = new Predicate<Cliente>(c => c.Nome.Contains("ru"));

        static void Main(string[] args)
        {
            //DelegatesProprios();
            //DelegatesActions_ForeachBasico();
            //DelegatesActions_ForeachComDelegate_Metodo();
            //DelegatesActions_ForeachComDelegate_Lambda();
            //DelegatesActions_ForeachComDelegate_Action();

            //DelegatesPredicate_Foreach_Basico();
            //DelegatesPredicate_Foreach_Metodo();
            DelegatesPredicate_Foreach_Lambda();
        }

        /*                         Métodos Auxiliares - Início                         */

        static void PrintMain(string imp)
        {
            Console.WriteLine("Impressão atravé do metodo! Tipo de Impressora: " + imp);
        }
        static void Mostrar(Cliente cliente)
        {
            Console.WriteLine(string.Format("Cliente chamado {0}", cliente.Nome));
        }
        static bool Contains(Cliente cliente)
        {
            return cliente.Nome.Contains("ll");
        }


        /*                         Métodos Auxiliares - Fim                            */

        static void DelegatesProprios()
        {
            #region delegate chamando metodo recebendo o evento atraves de paramentro

            Impressora ImprimirMetodo = new Impressora()
            {
                TipoImpressão = "Matricial"
            };
            ImprimirMetodo.PrintMetodo(PrintMain);

            #endregion

            #region diferentes formas de declarar
            Impressora impressora = new Impressora();

            impressora.Imprimir += msg => Console.WriteLine("Impressão a " + msg);//lambda
            impressora.Print("Tinta");

            impressora.Imprimir += delegate (string msg)  //anonimo
            {
                Console.WriteLine("Impressão " + msg);
            };
            impressora.Print("Fiscal");
            #endregion

            #region delegate atribuindo através de metodo simples
            /* 
                impressora.Imprimir += PrintMain;
                impressora.Print("Laser");
            */

            Console.ReadKey();
            #endregion
        }
        static void DelegatesActions_Foreach_Basico()
        {
            foreach (var cliente in clientes)
            {
                Console.WriteLine(string.Format("Cliente chamado {0}", cliente.Nome));
            }
            Console.ReadKey();

        }
        static void DelegatesActions_Foreach_Metodo()
        {
            clientes.ForEach(Mostrar);
            Console.ReadKey();
        }
        static void DelegatesActions_Foreach_Lambda()
        {
            clientes.ForEach(c => Console.WriteLine(string.Format("Cliente chamado {0}", c.Nome)));
            Console.ReadKey();
        }
        static void DelegatesActions_Foreach_Action()
        {
            //clientes.ForEach(mostrarAction); //chama o metodo Mostrar
            clientes.ForEach(mostrarActionLambda); //executa uma Actiona com uma lambda inclusa;
            Console.ReadKey();
        }
        static void DelegatesPredicate_Foreach_Basico()
        {
            foreach (var cliente in clientes)
            {
                if (Contains(cliente))
                {
                    Console.WriteLine(cliente.Nome);
                }
            }
            Console.ReadKey();
        }
        static void DelegatesPredicate_Foreach_Metodo()
        {
            var lista = clientes.FindAll(containsPredicate);


            foreach (var item in lista)
            {
                Console.WriteLine(item.Nome);
            }
            Console.ReadKey();
        }
        static void DelegatesPredicate_Foreach_Lambda()
        {
            var lista = clientes.FindAll(containsPredicateLambda);


            foreach (var item in lista)
            {
                Console.WriteLine(item.Nome);
            }
            Console.ReadKey();
        }
    }
}


