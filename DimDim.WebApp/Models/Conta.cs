using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DimDim.WebApp.Models
{
    [Table("TB_CONTA")]
    public class Conta
    {
        [Key]
        [Column("ID_CONTA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ID_CLIENTE")]
        [Column("ID_CLIENTE")]
        public int ClienteId { get; set; }

        [Column("NR_CONTA")]
        public string Numero { get; set; }

        [Column("NR_SALDO")]
        public decimal Saldo { get; set; }

        [Column("ST_CONTA")]
        public char Status { get; set; }

        [Column("DS_TIPO")]
        public string TipoConta { get; set; }
    }
}
