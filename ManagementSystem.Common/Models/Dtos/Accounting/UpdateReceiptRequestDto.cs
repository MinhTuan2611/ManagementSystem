﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Models.Dtos
{
    public class UpdateReceiptRequestDto
    {
        public int DocumentNumber { get; set; }
        public int CustomerId { get; set; }
        public string ForReason { get; set; }
        public int TotalMoney { get; set; }
        public int UserId { get; set; }
        public ActiveStatus Status { get; set; } = ActiveStatus.Active;
    }
}
