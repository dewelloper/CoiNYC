using CoiNYC.Domain.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CoiNYC.Infrastructure
{
    public class SeoModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "SeoUrl", ResourceType = typeof(R))]
        [StringLength(200)]
        public string Url { get; set; }
        [Required]
        [Display(Name = "SeoTitle", ResourceType = typeof(R))]
        [StringLength(150)]
        public string Title { get; set; }
        [Display(Name = "SeoKeywords", ResourceType = typeof(R))]
        [StringLength(500)]
        public string Keywords { get; set; }
        [Display(Name = "SeoDescription", ResourceType = typeof(R))]
        [StringLength(500)]
        public string Description { get; set; }
    }
}