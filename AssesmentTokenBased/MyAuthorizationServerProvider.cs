using AssesmentTokenBased.DataModel;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace AssesmentTokenBased
{
    public class MyAuthorizationServerProvider:OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            EmployeesEntities obj = new EmployeesEntities();
            var userdata = obj.EF_UserLogin(context.UserName, context.Password).FirstOrDefault();


            if (context.UserName=="admin" && context.Password=="admin")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Akshay Jadhav"));
                context.Validated(identity);
            }
            else if(userdata!=null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, userdata.Role));
                identity.AddClaim(new Claim(ClaimTypes.Name, userdata.UserName));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided UserName and Password is incorrect");
                context.Rejected();
                return;
            }
        }

    }
}