using System;
using System.Collections.Generic;

namespace FA.LegalHCM.Core.Mapper.ViewModel
{
    public class AccountModel
    {
        public Guid Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public IList<string> Roles { set; get; }

    }
}
