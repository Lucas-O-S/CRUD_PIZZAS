using CRUD_PIZZA.DAO;
using CRUD_PIZZA.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_PIZZA.Controllers
{
    public class PizzaController : PadraoController<PizzaViewModel>
    {
        public PizzaController() {
            dao = new PizzaDAO();
        }

        protected override void ValidarDados(PizzaViewModel model, string operacao)
        {
            base.ValidarDados( model,  operacao);
            if (String.IsNullOrEmpty(model.descricao))
            {
                ModelState.AddModelError("Descricao", "Descrição vazia");
            }
        }

    }
}
