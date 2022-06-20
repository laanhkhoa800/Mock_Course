using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.ApiModels
{
    public class NewUserRequest
    {
        // Required field:
        // Id, EmaiConfirm(bit), PhoneNumberConfirm(bit), TwoFactorEnabled(bit),LockoutEnabled(bit), Accessfailcount(int), CreateAt(datetime2(7), RoleId(Guid))
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string RoleName { get; set; }
        //public DateTime CreateAt { get; set; }
        //public bool EmailConfirm { get; set; }
        //public bool PhoneNumberConfirm { get; set; }
        //public bool TwoFactorEnabled { get; set; }

        //public bool LockoutEnabled { get; set; }

        //public int Accessfailcount { get; set; }
    }
}
