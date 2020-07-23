using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.Postsharp.AuthorizationAspects
{
    [Serializable]
    public class SecuredOperation : OnMethodBoundaryAspect
    {
        public string Roles { get; set; }
        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roles = Roles.Split(',');
            bool isAuthorized = false;

            for (int i = 0; i < roles.Length; i++)
            {
                if (Thread.CurrentPrincipal.IsInRole(roles[i]))
                {
                    isAuthorized= true;
                    break;
                }
            }
            if (!isAuthorized)
                throw new SecurityException("You are not authorized!");
            else
            {   //Bu şekilde kullanıcıya ait tüm bilgileri okuyabiliriz
                var userIdentity = ((Thread.CurrentPrincipal as GenericPrincipal).Identity as Core.CrossCuttingConcerns.Security.Identity);
            }
            base.OnEntry(args);
        }
    }
}
