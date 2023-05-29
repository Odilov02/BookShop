using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Tokens
{
    public class RefreshToken:BaseEntity
    {
        public Guid UserId { get; set; }
        public string Refresh { get; set; } = "";
        public DateTime ActiveDate;

    }
}
