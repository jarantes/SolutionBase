using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BASE_APP.Models
{
    [Table("APP_PROFILE_CLASS")]
    public partial class AppProfileClass
    {
        [Key]
        public int ClassID { get; set; }

        public int ProfileID { get; set; }

        public int ModuleID { get; set; }
    }
}
