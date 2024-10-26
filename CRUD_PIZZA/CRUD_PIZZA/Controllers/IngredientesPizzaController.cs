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

		public IActionResult ListaIngredientes(int pizzaID, string descricaoPizza)
		{
			try
			{
				ViewBag.descricaoPizza = descricaoPizza;
				ViewBag.pizzaId = pizzaID;
				
				var lista = (dao as IngredientesPizzaDAO).ListagemIngredientes(pizzaID);

				return View(NomeViewIndex,lista);
			}
			catch (Exception erro)
			{
				return View("Error", new ErrorViewModel(erro.ToString()));
			}
		}

		public IActionResult CriarIngrediente(int pizzaID, string descricaoPizza)
		{
            try
            {
                ViewBag.Operacao = "I";
                var model = new IngredientesPizzaViewModel();
                model.pizzaId = pizzaID;
				model.pizzaNome = descricaoPizza;
                return View(NomeViewForm, model);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        protected override IActionResult RedirecionaParaIndex(IngredientesPizzaViewModel model)
        {
			return RedirectToAction("ListaIngredientes", routeValues: new { pizzaId = model.pizzaId, descricaoPizza = model.pizzaNome });
        }







    }
}
