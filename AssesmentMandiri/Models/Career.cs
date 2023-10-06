using Microsoft.Data.SqlClient.Server;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssesmentMandiri.Models
{
    [Table("career", Schema = "dbo")]
    public class Career
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("career_id")]
        public int CareerId { get; set; }

        [Column("player_id")]
        public int PlayerId { get; set; }

        [Column("team_id")]
        public int TeamId { get; set; }

        [Column("join_date")]
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        [Column("end_date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Column("appearances")]
        public int Appearances { get; set; }

        [Column("goals")]
        public int Goals { get; set; }

        [Column("assists")]
        public int Assists { get; set; }

        [Column("cleansheets")]
        public int cleansheets { get; set; }

        [Column("yellow_cards")]
        public int YellowCards { get; set; }

        [Column("red_cards")]
        public int RedCards { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }

    public class CareerViewModels
    {
        public int CareerId { get; set; }
        public int PlayerId { get; set; }
        public int TeamId { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public int Appearances { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int Cleansheets { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public PlayerViewModels? PlayerDetail { get; set; }
        public TeamViewModels? TeamDetail { get; set; }
    }
}
