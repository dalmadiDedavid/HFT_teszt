using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFT_tesz2.Model
{
    [Table("Developers Team")]
    public class DevelopersTeam: Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(12)]
        public string Country { get; set; }
        [Range(20, 1000)]
        
        public int CountofMembers { get; set; }

        public DateTime Founded { get; set; }

        [NotMapped]
        public virtual ICollection<Game> Games { get; set; }
    }
}
