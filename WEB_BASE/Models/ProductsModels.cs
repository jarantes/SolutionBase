﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_BASE.Models
{
    [Table("Products")]
    public class ProductsModels
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Código do Produto")]
        public int ProductCode { get; set; }

        [Required]
        [Display(Name = "Nome do Produto")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public double UnitPrice { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }

        [StringLength(128)]
        [Display(Name = "Criado Por")]
        public string CreatedBy { get; set; }

        [Display(Name = "Data da Criação")]
        public DateTime ? CreationDate { get; set; }

        [StringLength(128)]
        [Display(Name = "Atualizado Por")]
        public string UpdatedBy { get; set; }

        [Display(Name = "Data da Atualização")]
        public DateTime ? UpdatedDate { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ProductsCategoryModels Category { get; set; }
    }
}