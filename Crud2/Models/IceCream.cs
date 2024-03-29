using System.ComponentModel.DataAnnotations;

namespace Crud2.Models
{
    public class IceCream
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IceCreamType { get; set; }
        [Required]
        public string Flavour { get; set; }
        [Required]
        public string Natural_synthetic {get; set;}
        [Required]
        public string Allergens {get; set;}
        [Required]
        public string VegType {get; set;}
        [Required]
        public string EatedBy {get; set;}
        [Required] 
        public string PricePerPiece {get; set;}
        [Required]
        public DateTime TimeOfPrice {get; set;}
        [Required]
        public string ExpiryDate {get; set;}
        [Required]
        public string MfgDate {get; set;}
        [Required]
        public string Brand {get; set;}
    }
}
