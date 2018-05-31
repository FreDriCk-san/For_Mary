using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSecurity.Models
{
    public class Role
    {
        public long Id { get; set; }

        public string Name { get; set; }

        [Required]
        public int Priority { get; set; }

        public string AllowedDays { get; set; }

        public TimeSpan? AllowedTime { get; set; }
    }
}
