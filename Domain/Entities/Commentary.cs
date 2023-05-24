using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Commentary : BaseAuditableEntity
{

    public string Description { get; set; } = "";
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public Guid BookId { get; set; }
    public Book? Book { get; set; }
}
