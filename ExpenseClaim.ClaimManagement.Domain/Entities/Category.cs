﻿using KakaoExpenseClaim.ClaimManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Domain.Entities
{
    public class Category 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

    }
}
