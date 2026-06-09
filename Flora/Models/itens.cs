using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flora.Models
{
    [Table("itens")]
    public class Itens
    {
        [Key]
        [Column("id_itens")]
        public int IdItens { get; set; }

        [Column("id_minhas_compras")]
        public int IdMinhasCompras { get; set; }

        [Column("produto_id")]
        public int ProdutoId { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }
    }
}