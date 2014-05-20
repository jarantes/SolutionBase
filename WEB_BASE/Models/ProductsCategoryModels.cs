using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc.Html;

namespace WEB_BASE.Models
{
    [Table("ProductsCategory")]
    public class ProductsCategoryModels
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public string CategoryName { get; set; }

        [StringLength(128)]
        [Display(Name = "Criado Por")]
        public string CreatedBy { get; set; }

        [Display(Name = "Data da Criação")]
        public DateTime CreationDate { get; set; }

        [StringLength(128)]
        [Display(Name = "Atualizado Por")]
        public string UpdatedBy { get; set; }

        [Display(Name = "Data da Atualização")]
        public DateTime UpdatedDate { get; set; }

        public IEnumerable<ProductsModels> Products { get; set; }
    }
}