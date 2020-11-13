using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VATUShop.MVC.ViewModels
{
    public class EditUserViewModel : ContactInfo
    {
        public string UserId { get; set; }
        public string RolesName { get; set; }
        public bool IsDeleted { get; set; }
        public string RolesId { get; set; }
    }
}
