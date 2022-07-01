using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProfesyonelBackend.Core.CrossCuttingConcerns.Security
{
    public class Identity : IIdentity
    {
        //Identity ismi
        public string Name { get; set; }
        //Autentication tipi (Google, facebook vb)
        public string AuthenticationType { get; set; }
        //Authentice oldu mu ?
        public bool IsAuthenticated { get; set; }

        //Kendi verdiğimiz propertyler
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}
