using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Membership.Site.Services
{
    public class RetrieveRequest : ServiceRequest
    {
        public Int32? EntityId;
    }
}