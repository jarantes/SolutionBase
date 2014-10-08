using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BASE_APP.Models
{
    [Table("APP_PROFILES")]
    public partial class AppProfiles
    {
        [Key]
        public int ProfileID { get; set; }

        public string ProfileDescription { get; set; }

        public System.DateTime CreationDate { get; set; }
    }
}
