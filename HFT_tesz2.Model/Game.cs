using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HFT_tesz2.Model
{
    [Table("Game")]
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameId { get; set; }
        [Required]
        [MaxLength(20)]
        public string GName { get; set; }
        [Required]
        [MaxLength(15)]
        public string Type { get; set; }
        [Required]
        public int AgeLimit { get; set; }
        [Range(5000,20000)]
        public int Price { get; set; }

        [NotMapped]
        public DevelopersTeam Dev { get; set; }

        [ForeignKey(nameof(DevelopersTeam))]
        public int DevId { get; set; }
    }
}
