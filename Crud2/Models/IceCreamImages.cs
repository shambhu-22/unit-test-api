using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud2.Models
{
    public class IceCreamImages
    {
        [Key]
        public int ImageId { get; set; }
        [ForeignKey("Id")]
        public int IceCreamId { get; set; }
        public virtual IceCream IceCream { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageContent { get; set; }
        public string ContentType { get; set; }
    }
}
