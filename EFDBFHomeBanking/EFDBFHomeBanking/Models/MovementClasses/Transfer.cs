﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EFDBFHomeBanking.Models.MovementClasses
{
    public class Transfer : Movement
    {
        public Boolean checkedExtraction { get; set; }
        public Boolean checkedDeposit { get; set; }
        public int originAccountId { get; set; }
    }
}
