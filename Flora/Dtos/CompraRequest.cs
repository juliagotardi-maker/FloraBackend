using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flora.DTOs
{
    public class CompraRequest
    {
        public int id_usuario { get; set; }
        public List<ItemRequest> itens { get; set; }
    }
}