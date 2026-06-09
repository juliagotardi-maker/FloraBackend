using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flora.Models
{
    [Table("produto")]
    public class Produto
    {
        [Key]
        [Column("id_produto")]
        public int id_produto { get; set; }

        [Column("nome")]
        public string nome { get; set; }

        [Column("descricao")]
        public string descricao { get; set; }

        [Column("preco")]
        public decimal preco { get; set; }

        [Column("quantidade")]
        public int quantidade { get; set; }
    }
}