using CRUD_PIZZA.Models;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Emit;

namespace CRUD_PIZZA.DAO
{
    public class IngredientesPizzaDAO : PadraoDAO<IngredientesPizzaViewModel>
    {
        protected override void SetTabela()
        {
            tabela = "tbIngredientesPizza";
            NomeSpListagem = "sp_list_tbIngredientesPizza";
        }

        protected override SqlParameter[] CriarParametros(IngredientesPizzaViewModel model)
        {
            if (model.id == 0 || model.id == null)
            {
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("PizzaId", model.pizzaId),
                    new SqlParameter("descricao", model.descricao)


                };

                return sp;


            }
            else
            {
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("Id", model.id),
                    new SqlParameter("PizzaId", model.pizzaId),
                    new SqlParameter("descricao", model.descricao)
                };
                return sp;
            }
        }

        protected override IngredientesPizzaViewModel MontarModel(DataRow registro)
        {
            IngredientesPizzaViewModel model = new IngredientesPizzaViewModel();
            model.id = Convert.ToInt32(registro["id"]);
            model.pizzaId = Convert.ToInt32(registro["pizzaId"]);
            model.descricao = Convert.ToString(registro["descricao"]);
            PizzaDAO pizzaDAO = new PizzaDAO();
            PizzaViewModel pizza = pizzaDAO.Consulta(model.pizzaId);
            model.pizzaNome = pizza.descricao;
            return model;

        }

        public List<IngredientesPizzaViewModel> ListagemIngredientes(int pizzaId)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("tabela",tabela),
                new SqlParameter("Pizzaid",pizzaId)

            };
            DataTable dt = HelperDAO.ExecutaProcSelect(NomeSpListagem, p);
            List<IngredientesPizzaViewModel> list = new List<IngredientesPizzaViewModel>();
            foreach (DataRow dr in dt.Rows)
                list.Add(MontarModel(dr));
            return list;
        }
    }
}
