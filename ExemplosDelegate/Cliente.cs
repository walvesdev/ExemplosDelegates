using System;
using System.Collections.Generic;
using System.Text;

namespace ExemplosDelegate
{
    public class Cliente
    {
        public int ID { get; set; }
        public string  Nome { get; set; }
        public int  Idade { get; set; }

        public override string ToString()
        {
            return string.Format("Cliente de ID: {0} e Nome: {1}", ID, Nome);
        }
    }
}
