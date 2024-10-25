using CRUD_PIZZA.DAO;
using CRUD_PIZZA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CRUD_PIZZA.Controllers
{
    public class PadraoController<T> : Controller where T : PadraoViewModel
    {

        protected PadraoDAO<T> dao {  get; set; }
        protected string NomeViewIndex { get; set; } = "index";
        protected string NomeViewForm { get; set; } = "form";
        

        public virtual IActionResult Index()
        {
            try
            {
                var lista = dao.Listagem();
                return View(NomeViewIndex,lista);

            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public virtual IActionResult Create()
        {
            try
            {
                ViewBag.operacao = "I";
                T model = Activator.CreateInstance(typeof(T)) as T;
                return View(NomeViewForm, model);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public virtual IActionResult Save(T model, string operacao)
        {
            try
            {
                ValidarDados(model, operacao);
                if (ModelState.IsValid == false)
                {
                    ViewBag.operacao = operacao;
                    return View(NomeViewForm,model);
                }
                else
                {
                    if (operacao == "I")
                        dao.Insert(model);

                    
                    else
                        dao.Update(model);
                    return RedirectToAction(NomeViewIndex);
                }
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        protected virtual void ValidarDados(T model, string operacao) { ModelState.Clear(); }

        public IActionResult Edit(int id)
        {
            try
            {
                ViewBag.operacao = "A";
                var model = dao.Consulta(id);
                if (model == null)
                    return RedirectToAction(NomeViewIndex);
                else
                    return View(NomeViewForm, model);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }

            
        }
        public IActionResult Delete(int id)
        {
            try
            {
                dao.Delete(id);
                return RedirectToAction(NomeViewIndex);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

   
	}
}
