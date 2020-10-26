using System;
using System.Collections.Generic;
using System.Text;

namespace EFDBFHomeBanking.Models
{
    public class Bank
    {
        public int bankId { get; set; }
        public String address { get; set; }
        public String phone { get; set; }
        public Client[] clients { get; set; }
        // ¿or ArrayList clients?
    }
}
