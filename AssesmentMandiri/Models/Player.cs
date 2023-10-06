using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssesmentMandiri.Models
{
    [Table("player", Schema = "dbo")]
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("player_id")]
        public int PlayerId { get; set; }

        [Column("player_name")]
        [Required]
        public string PlayerName { get; set; } = string.Empty;

        [Column("position")]
        [Required]
        public string Position { get; set; } = string.Empty;


        [Column("place_of_birth")]
        [Required]
        public string PlaceOfBirth { get; set; } = string.Empty;

        [Column("date_of_birth")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOftBirth { get; set; }

        [Column("nationality")]
        [Required]
        public string Nationality { get; set; } = string.Empty;

        [Column("created_at")]
        [Required]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; } = null;


    }

    public class PlayerViewModels
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string PlaceOfBirth { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime DateOftBirth { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;

        public List<CareerViewModels>? CareerDetails { get; set; }
    }
}
