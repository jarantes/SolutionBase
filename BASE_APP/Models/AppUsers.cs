using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BASE_APP.Models
{
    [Table("APP_USERS")]
    public partial class AppUsers
    {
        [Key]
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string UserDescription { get; set; }

        public string Password { get; set; }

        public int ProfileID { get; set; }

        public Nullable<System.DateTime> CreationDate { get; set; }

        public Nullable<int> CreatedBy { get; set; }

        [MaxLength(1)]
        public string Activated { get; set; }
    }
}
