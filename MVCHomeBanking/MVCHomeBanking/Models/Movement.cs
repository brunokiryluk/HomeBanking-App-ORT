using MVCHomeBanking.Models.MovementsEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Monto")]
        public float value { get; set; }
        [DisplayName("Tipo de Operacion")]
        public TYPE_MOVEMENT type { get; set; }
        [DisplayName("Resultado de Movimiento")]
        public STATUS_MOVEMENT status { get; set; }
        [DisplayName("Cuenta Origen")]
        public string originAccountId { get; set; }
        [DisplayName("Cuenta Destino")]
        public string destinationAccountId { get; set; }


    }
}
