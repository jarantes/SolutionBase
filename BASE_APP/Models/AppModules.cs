using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BASE_APP.Models
{
    [Table("APP_MODULES")]
    public partial class AppModules
    {
        [Key]
        public int ModuleID { get; set; }

        public string ModuleDescription { get; set; }

        public Nullable<int> ParentModuleID { get; set; }

        public string AssociateForm { get; set; }

        public string Activated { get; set; }

        public string CloseForm { get; set; }

        public string ParentModuleDescription { get; set; }

        public Nullable<int> Ordem { get; set; }

        public int ImageIndex { get; set; }
    }
}
