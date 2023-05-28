using AcercampoVI.Controllers;
using AcercampoVI.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcercampoVI.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (UsuariosE)HttpContext.Current.Session["User"];
            if (oUser == null)
            {
                if (filterContext.Controller is AccountController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Account/login");
                }
            }
            else if(filterContext.Controller is AccountController == true)
            {
                filterContext.HttpContext.Response.Redirect("~/Home/Index");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}