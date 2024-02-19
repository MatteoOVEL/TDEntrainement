using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TDEntrainement.Models.EntityFramework
{
    [Table("chanteur")]
    public partial class Chanteur
    {
        public Chanteur()
        {
            Musiques = new HashSet<Musique>();
        }

        [Key]
        [Column("idchanteur")]
        public int Idchanteur { get; set; }
        [Column("nomchanteur")]
        public string? Nomchanteur { get; set; }

        [InverseProperty("IdchanteurNavigation")]
        public virtual ICollection<Musique> Musiques { get; set; }
    }
}
