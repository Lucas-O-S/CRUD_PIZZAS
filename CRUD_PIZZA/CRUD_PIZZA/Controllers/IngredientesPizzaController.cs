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

        protected override void ValidarDados(IngredientesPizzaViewModel model, string operacao)
        {
            base.ValidarDados(model, operacao);
            if (String.IsNullOrEmpty(model.descricao))
            {
                ModelState.AddModelError("Descricao", "Descrição vazia");
            }
  
        }
    }
}
