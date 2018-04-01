using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Model
{
    public class LoginViewModel: LoginInputModel
    {
        public bool AllowRememberLogin { get; set; }
        public bool EnableLocalLogin { get; set; }
    }
}
