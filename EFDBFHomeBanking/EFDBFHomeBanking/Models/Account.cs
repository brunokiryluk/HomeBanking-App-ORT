using System;
using System.Collections.Generic;
using System.Text;

namespace EFDBFHomeBanking.Models
{
    public class Account
    {
        public String accountId { get; set; }
        public String direccion { get; set; }
        public String telefono { get; set; }
        public float balance { get; set; }
        // TODO: add movements

    }
}
