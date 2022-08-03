using System.ComponentModel.DataAnnotations;
namespace Bibliotheque.Models
{
    public class Livre{
        
        public int id {set;get;}
        [Required]
        public string titre{get;set;}
        [Required,StringLength(50)]
        public string Auteur {set;get;}
        [Required]
        public string genre {set;get;}
        [Required]
        public string Image{set;get;}
        [Required]
        public string edition {set;get;}
        public string? description{set;get;}


    } 
}