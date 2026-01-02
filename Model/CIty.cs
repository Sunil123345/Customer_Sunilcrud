using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerReactiveForms.Model
{
    [Table("City")]
    public class CIty
    {
        [Key]
        public int cityid { get; set; }
        public string cityname { get; set; }
        public int stid { get; set; }
    }
}
