using CRUD_PIZZA.Models;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_PIZZA.DAO
{
    public class PizzaDAO : PadraoDAO<PizzaViewModel>
    {
        protected override void SetTabela()
        {
            tabela = "tbPizza";
        }

        protected override SqlParameter[] CriarParametros(PizzaViewModel model)
        {
            if (model.id == 0 || model.id == null)
            {
                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("descricao", model.descricao)

                };

                return sp;


            }
            else
            {
                SqlParameter[] sp = new SqlParameter[2];
                sp[0] = new SqlParameter("id", model.id);
                sp[1] = new SqlParameter("descricao", model.descricao);
                return sp;
            }
        }

        protected override PizzaViewModel MontarModel(DataRow registro)
        {
            PizzaViewModel model = new PizzaViewModel();
            model.id = Convert.ToInt32(registro["id"]);
            model.descricao = Convert.ToString(registro["descricao"]);
            return model;

        }

    }

}

