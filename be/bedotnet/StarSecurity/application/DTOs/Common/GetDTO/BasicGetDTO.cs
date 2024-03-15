using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs.Common.GetDTO
{
    public abstract class BasicGetDTO
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; protected set; }
        public DateTime? DeleteDate { get; protected set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
