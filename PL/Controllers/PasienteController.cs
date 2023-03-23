using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class PasienteController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Pasiente pasiente = new ML.Pasiente();
            ML.Result result = BL.Pasiente.GetAll();
            
            

            if(result.Correct)
            {
                pasiente.Pasientes = result.Objects;
                return View(pasiente);
            }
            else
            {
                result.ErrorMessage = "No se pudo consultar los Pasiente";
                return View(pasiente);
            }
        }
    }
}
