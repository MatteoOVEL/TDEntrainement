using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TDEntrainement.Models.EntityFramework
{
    [Table("musique")]
    public partial class Musique
    {
        [Key]
        [Column("idmusique")]
        public int Idmusique { get; set; }
        [Column("titre")]
        [StringLength(100)]
        public string Titre { get; set; } = null!;
        [Column("genre")]
        public string? Genre { get; set; }
        [Column("idchanteur")]
        public int? Idchanteur { get; set; }

        [ForeignKey("Idchanteur")]
        [InverseProperty("Musiques")]
        public virtual Chanteur? IdchanteurNavigation { get; set; }
    }
}
