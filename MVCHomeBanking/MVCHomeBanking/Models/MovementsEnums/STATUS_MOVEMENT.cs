using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHomeBanking.Models.MovementsEnums
{
    public enum STATUS_MOVEMENT
    {
        EXTRACT_OK,
        EXTRACT_FAILED,

        DEPOSIT_OK,
        DEPOSIT_FAILED,

        TRANSFER_OK,
        TRANSFER_FAILED

    }
}
