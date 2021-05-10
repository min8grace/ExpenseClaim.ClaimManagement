using KakaoExpenseClaim.ClaimManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Domain.Entities
{
    public class Currency 
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
    }
}
