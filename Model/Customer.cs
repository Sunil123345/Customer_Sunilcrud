using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerReactiveForms.Model
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int custid { get; set; }
        public string custname { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int cid { get; set; }
        public int stid { get; set; }
        public int cityid { get; set; }

        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
    }
}
