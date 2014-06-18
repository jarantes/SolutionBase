using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Printing;

namespace WEB_BASE.Models
{
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }

        [Required]
        [Display(Name = "Nome do Menu")]
        public string ModuleName { get; set; }

        [Display(Name = "Controller")]
        public string Controller { get; set; }

        [Display(Name = "Action")]
        public string Action { get; set; }

        [Display(Name = "Ícone")]
        public string Icon { get; set; }

        public int? ParentModuleId { get; set; }

        [ForeignKey("ParentModuleId")]
        public virtual IList<Module> SubModules { get; set; }
    }

    public class ModuleUserAccess
    {
        [Key]
        public int AccessId { get; set; }

        public string UserId { get; set; }

        public int ModuleId { get; set; }

        [ForeignKey("ModuleId")]
        public virtual IEnumerable<Module> Modules { get; set; }
    }
}