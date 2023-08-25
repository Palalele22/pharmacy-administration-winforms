using LibrarieModele;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelAccesDate
{
    public class AdministrareIngrediente : IStocareIngrediente
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;
        public bool AddIngredient(Ingredient i)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "insert into INGREDIENT_31A_FPC VALUES (SEQ_INGREDIENTE_31A_FPC.nextval, :NumeIngredient, :DataExp, :Stoc)", CommandType.Text,
                new OracleParameter(":NumeIngredient", OracleDbType.NVarchar2, i.NumeIngredient, ParameterDirection.Input),
                new OracleParameter(":DataFabricatie", OracleDbType.Date, i.DataExp, ParameterDirection.Input),
                new OracleParameter(":Stoc", OracleDbType.Int32, i.Stoc, ParameterDirection.Input)
            );
        }

        public Ingredient GetIngredient(int id)
        {
            Ingredient result = null;
            var dsIngrediente = SqlDBHelper.ExecuteDataSet("select * from INGREDIENT_31A_FPC where IdIngredient = :IdIngredient", CommandType.Text,
                new OracleParameter(":IdIngredient", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsIngrediente.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsIngrediente.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Ingredient(linieBD);
                //incarca entitatile aditionale
            }
            return result;
        }

        public List<Ingredient> GetIngrediente()
        {
            var result = new List<Ingredient>();
            var dsIngrediente = SqlDBHelper.ExecuteDataSet("select * from INGREDIENT_31A_FPC", CommandType.Text);

            foreach (DataRow linieBD in dsIngrediente.Tables[PRIMUL_TABEL].Rows)
            {
                var ingredient = new Ingredient(linieBD);
                //incarca entitatile aditionale

                result.Add(ingredient);
            }

            return result;
        }

        public bool UpdateIngredient(Ingredient i)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE INGREDIENT_31A_FPC set NumeIngredient = :NumeIngredient, DataExp = :DataExp, Stoc = :Stoc WHERE IdIngredient = :IdIngredient", CommandType.Text,
                new OracleParameter(":NumeIngredient", OracleDbType.NVarchar2, i.NumeIngredient, ParameterDirection.Input),
                new OracleParameter(":DataFabricatie", OracleDbType.Date, i.DataExp, ParameterDirection.Input),
                new OracleParameter(":Stoc", OracleDbType.Int32, i.Stoc, ParameterDirection.Input),
                new OracleParameter(":IdIngredient", OracleDbType.Int32, i.IdIngredient, ParameterDirection.Input)
            );
        }
    }
}
