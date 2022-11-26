using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVP.Entidades
{
    public class SituacaoUsuario
    {
        public int Id{get;set;}
        public string CPF{get;set;}
        public bool TemProcesso { get; set; }
    }
}