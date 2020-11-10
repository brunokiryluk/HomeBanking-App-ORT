using MVCHomeBanking.Models.MovementsEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MVCHomeBanking.Models
{
    public class Movement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int movementId { get; set; }
        public float value { get; set; }

        public TYPE_MOVEMENT type { get; set; }

        public STATUS_MOVEMENT status { get; set; }
        public string originAccountId { get; set; }
        public string destinationAccountId { get; set; }


    }
}
