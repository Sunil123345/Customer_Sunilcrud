using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerReactiveForms.Model
{
    [Table("State")]
    public class State
    {
        [Key]
        public int stid { get; set; }
        public string stname { get; set; }
        public int cid { get; set; }
    }
}
