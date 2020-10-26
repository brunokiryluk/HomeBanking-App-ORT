using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EFDBFHomeBanking.Models
{
    public class Client
    {
        public int clientId { get; set; }
        public String name { get; set; }
        public String surname { get; set; }
        public String nroDoc { get; set; }
        public String phone { get; set; }
        public Account[] accounts { get; set; }
        // or ArrayList accounts ?
    }
}
