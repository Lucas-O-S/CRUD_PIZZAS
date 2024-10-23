﻿using CRUD_PIZZA.Models;
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
        }

        protected override SqlParameter[] CriarParametros(IngredientesPizzaViewModel model)
        {
            if (model.id == 0)
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
            model.id = Convert.ToInt32(registro["pizzaId"]);
            model.descricao = Convert.ToString(registro["descricao"]);
            return model;

        }
    }
}