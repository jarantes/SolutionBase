using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_BASE.Models
{
    [Table("ProductsCategory")]
    public class ProductCategory
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
        public DateTime? UpdatedDate { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}