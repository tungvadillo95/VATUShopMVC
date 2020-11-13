using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VATUShop.MVC.Models
{
    [Table("ward")]
    public class Ward
    {
        [Key]
        public int id { get; set; }
        public string _prefix { get; set; }
        public string _name { get; set; }
        [ForeignKey("Province")]
        public int _province_id { get; set; }
        [ForeignKey("District")]
        public int _district_id { get; set; }
        public District District { get; set; }
        public Province Province { get; set; }
        public string WardName => $"{_prefix} {_name}";
    }
}
