using Membership.Core.Domain.Web;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Data.Repository
{
    public class WebUserRepository : GenericRepository<WebUser>
    {
        public WebUserRepository()
            : base(new DomainEfModel())
        {

        }

        //public Membership.Core.Domain.Application.Application LoggedUser(string nameStartsWith)
        //{
        //    return this.GetObjectsByParameters(p => p.Id == 1).FirstOrDefault();
        //}
    }
}


//    using Membership.Core.Domain.Web;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Membership.Data.Repository
//    {
//        public class WebUserRepository : GenericRepository<Membership.Core.Domain.Application.Application>
//        {
//            public WebUserRepository()
//                : base(new DbContext("name=MembershipDefault"))
//            {

//            }

//            public Membership.Core.Domain.Application.Application LoggedUser(string nameStartsWith)
//            {
//                return this.GetObjectsByParameters(p => p.Id == 1).FirstOrDefault();
//            }
//        }
//    }

