using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSecurity.Models
{
    public class Subject
    {
        public long Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public int AuthCount { get; set; }

        [Required, ForeignKey("Roles")]
        public long RoleId { get; set; }
        public virtual Role Roles { get; set; }

        [Required, ForeignKey("Levels")]
        public long LevelId { get; set; }
        public virtual Level Levels { get; set; }

        [ForeignKey("Bans")]
        public long? BanId { get; set; }
        public virtual Ban Bans { get; set; }

    }
}
