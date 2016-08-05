
using Membership.Business.Model;
using Membership.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Membership.Business.Manager
{
    public abstract class BaseManager
    {

        private WebUser currentUser;

        public BaseManager()
        {

        }

        public WebUser CurrentUser
        {
            get
            {
                if (currentUser == null)
                    throw new System.Exception("Tanımlı bir CurrentUser yok");

                return currentUser;
            }
            set
            {
                currentUser = value;
            }
        }
    }
}