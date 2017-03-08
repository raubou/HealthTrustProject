using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthTrustProject.Controllers
{
    public abstract class BaseController : AsyncController
    {
        HealthTrustContext ctx;
        public BaseController()
        {
            ctx = new HealthTrustContext();
        }
    }
}