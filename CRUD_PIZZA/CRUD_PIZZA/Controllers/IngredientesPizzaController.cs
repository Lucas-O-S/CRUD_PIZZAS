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
		public override IActionResult Save(IngredientesPizzaViewModel model, string operacao)
		{
			try
			{
				ValidarDados(model, operacao);
				if (ModelState.IsValid == false)
				{
					ViewBag.operacao = operacao;
					return View("Create", new { pizzaId = model.pizzaId, descricao = model.pizzaNome });
				}
				else
				{
					if (operacao == "I")
						dao.Insert(model);


					else
						dao.Update(model);



					return RedirectToAction(NomeViewIndex, new { pizzaId = model.pizzaId, descricao = model.pizzaNome });
				}
			}
			catch (Exception erro)
			{
				return View("Error", new ErrorViewModel(erro.ToString()));
			}
		}



	}
    }
