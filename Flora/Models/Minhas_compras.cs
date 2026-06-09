using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flora.Models
{
    [Table("minhas_compras")]
    public class MinhasCompras
    {
        [Key]
        [Column("id_minhas_compras")]
        public int id_minhas_compras { get; set; }

        [Column("id_usuario")]
        public int id_usuario { get; set; }

        [Column("valor")]
        public decimal valor { get; set; }

        [Column("status_compra")]
        public string status_compra { get; set; }
    }
}