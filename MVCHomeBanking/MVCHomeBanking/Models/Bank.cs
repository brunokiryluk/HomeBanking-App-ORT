using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MVCHomeBanking.Models
{
    public class Bank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bankId { get; set; }
        public String address { get; set; }
        public String phone { get; set; }
        public Client[] clients { get; set; }
        // ¿or ArrayList clients?
    }
}
