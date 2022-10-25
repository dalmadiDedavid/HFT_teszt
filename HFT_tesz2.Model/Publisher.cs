using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFT_tesz2.Model
{
    [Table("Publisher")]
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PubId { get; set; }
        [Required]
        [MaxLength(12)]
        public string Name { get; set; }

        public DateTime LaunchDate { get; set; }

        public string Platform { get; set; }

        [NotMapped]
        public virtual Game Game { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }



    }
}
