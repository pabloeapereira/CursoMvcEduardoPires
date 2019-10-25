using System.Web.Mvc;

namespace EP.CursoMvc.Infra.CrossCutting.MvcFilters
{
    public class GlobalActionLogger:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                /*
                 * Manipular a EX
                 * Injetar alguma LIB de tratamento de erro
                 * -> Gravar log do erro no BD
                 * -> E-mail para o admin
                 * -> Retornar cod de erro amigável
                 *
                 * Log4net
                 * Elmah.IO
                 * Custom Logger
                 */

                filterContext.ExceptionHandled = true;
                filterContext.Result = new HttpStatusCodeResult(500);
            }
            base.OnActionExecuted(filterContext);
        }
    }
}
