using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerReactiveForms.Model
{
    [Table("Country")]
    public class Country
    {
        [Key]
        public int cid { get; set; }
        public string cname { get; set; }
    }
}
