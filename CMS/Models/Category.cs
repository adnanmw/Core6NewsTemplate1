using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
namespace CMS.Models
{
    public class Category
    {
        public int Id { get; set; }
        [StringLength(70, ErrorMessage = "The category length  must not exceed 70 characters.")]

        [Required]
        public string Name { get; set; }
    }
}
