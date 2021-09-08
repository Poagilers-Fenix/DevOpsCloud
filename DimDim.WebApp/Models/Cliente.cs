using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DimDim.WebApp.Models
{
    [Table("TB_CLIENTE")]
    public class Cliente
    {
        [Key]
        [Column("ID_CLIENTE")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId { get; set; }

        [Column("NM_CLIENTE")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("NR_CPF")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Display(Name = "E-mail")]
        [Column("DS_EMAIL")]
        public string Email { get; set; }

        [Column("NR_TELEFONE")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

    }
}