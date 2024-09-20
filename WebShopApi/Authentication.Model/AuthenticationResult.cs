using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.API.Authentication.Model
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public bool Succes => Errors == null || !Errors.Any();
        public List<string> Errors { get; set; }


        



    }
}
