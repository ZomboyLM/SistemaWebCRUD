using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace SistemaWeb.Permisos
{
    public class ValidarSessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
 
            
                // context.HttpContext.Session.SetString("Usuario", "");

                if (context.HttpContext.Session.GetString("Usuario") == null)
                {
                    context.Result = new RedirectResult("~/Login/Login");
                }
            base.OnActionExecuting(context);
        }

           
        
    }
}
