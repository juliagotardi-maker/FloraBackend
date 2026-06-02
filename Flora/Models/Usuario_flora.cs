using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flora.Models
{
    [Table("usuario_flora")]
    public class Usuario_flora
    {
        [Key]
        [Column("id_usuario")]
        public int id_usuario { get; set; }

        [Column("nome")]
        public string nome { get; set; }
        [Column("email")]           
        public string email { get; set; }

        [Column("telefone")]
        public string telefone { get; set; }

        [Column("senha")]
        public string senha { get; set; }

        [Column("confirmar_senha")]
        public string confirmar_senha { get; set; }
    }
}