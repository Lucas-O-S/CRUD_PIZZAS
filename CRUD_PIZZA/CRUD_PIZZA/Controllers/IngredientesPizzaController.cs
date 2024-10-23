using CRUD_PIZZA.DAO;
using CRUD_PIZZA.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_PIZZA.Controllers
{
    public class IngredientesPizzaController : PadraoController<IngredientesPizzaViewModel>
    {
        public IngredientesPizzaController()
        {
            dao = new IngredientesPizzaDAO();
        }
    }
}
