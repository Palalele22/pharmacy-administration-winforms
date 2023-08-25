using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;
using Oracle.DataAccess.Client;

namespace NivelAccesDate
{
    public class AdministrareRetete : IStocareRetete
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        

        public List<Reteta> GetRetete()
        {
            var result = new List<Reteta>();
            var dsRetete = SqlDBHelper.ExecuteDataSet("select * from RETETA_31A_FPC", CommandType.Text);

            foreach (DataRow linieBD in dsRetete.Tables[PRIMUL_TABEL].Rows)
            {
                var reteta = new Reteta(linieBD);
                //incarca entitatile aditionale
                
                result.Add(reteta);
            }
            
            return result;
        }

        public Reteta GetReteta(int id)
        {
            Reteta result = null;
            var dsRetete = SqlDBHelper.ExecuteDataSet("select * from RETETA_31A_FPC where IdReteta = :IdReteta", CommandType.Text,
                new OracleParameter(":IdReteta", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsRetete.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsRetete.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Reteta(linieBD);
                //incarca entitatile aditionale
            }
            return result;
        }

        public bool AddReteta(Reteta r)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "insert into RETETA_31A_FPC VALUES (SEQ_RETETE_31A_FPC.nextval, :IdsIngrediente)", CommandType.Text,
                new OracleParameter(":IdsIngrediente", OracleDbType.NVarchar2, r.IdsIngrediente, ParameterDirection.Input)
            );
        }


        public bool UpdateReteta(Reteta r)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE RETETA_31A_FPC set IdsIngrediente = :IdsIngrediente WHERE IdReteta = :IdReteta", CommandType.Text,
                new OracleParameter(":IdsIngrediente", OracleDbType.NVarchar2, r.IdsIngrediente, ParameterDirection.Input),
                new OracleParameter(":IdReteta", OracleDbType.Int32, r.IdReteta, ParameterDirection.Input)
            );
        }
    }
}
