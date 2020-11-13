using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VATUShop.MVC.Models
{
    [Table("district")]
    public class District
    {
        [Key]
        public int id { get; set; }
        public string _prefix { get; set; }
        public string _name { get; set; }
        [ForeignKey("Province")]
        public int _province_id { get; set; }
        public Province Province { get; set; }
        public ICollection<Ward> Wards { get; set; }
        public string DistrictName => $"{_prefix} {_name}";
    }
}
