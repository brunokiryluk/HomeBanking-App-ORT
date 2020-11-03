using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace MVCHomeBanking.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String accountId { get; set; }
        public String direccion { get; set; }
        public String telefono { get; set; }
        public float balance { get; set; }
        // TODO: add movements
        public List<Movement> movements { get; set; }

    }
}
