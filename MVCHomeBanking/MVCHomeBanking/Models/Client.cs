using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MVCHomeBanking.Models
{
    public class Client
    {
        [Key]
        public String nroDoc { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public String name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public String surname { get; set; }
        public String phone { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        // Credentials of the Client
        [Required]
        public String username { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public String password { get; set; }

        public List<Account> accounts { get; set; }
        // or ArrayList accounts ?
    }
}
