using System;

namespace FA.LegalHCM.Core.Mapper.ViewModel
{
    public class UserModel
    {
        public Guid Id { set; get; }
        public string Email { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
    }
}
