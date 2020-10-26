using System;
using System.Collections.Generic;
using System.Text;

namespace EFDBFHomeBanking.Models
{
    public abstract class Movement
    {
        public int movementId { get; set; }
        public float value { get; set; }

    }
}
