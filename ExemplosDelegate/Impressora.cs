using System;
using System.Collections.Generic;
using System.Text;

namespace ExemplosDelegate
{
    public delegate void ImprimirEvent(string msg);

    public class Impressora
    {
        public string TipoImpressão { get; set; }

        public event ImprimirEvent Imprimir;

        public void Print(string msg)
        {
            this.Imprimir(msg);
        }
        public void PrintMetodo(ImprimirEvent PrintAtt)
        {
            PrintAtt(TipoImpressão);
        }
    }
}
