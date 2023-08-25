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
    public class AdministrareMedicamente : IStocareMedicamente
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public bool AddMedicament(Medicament m)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "insert into MEDICAMENT_31A_FPC VALUES (SEQ_MEDICAMENTE_31A_FPC.nextval, :NumeMedicament, :DataExp, :Prospect, :TipMedicament, :IdReteta)", CommandType.Text,
                new OracleParameter(":NumeMedicament", OracleDbType.NVarchar2, m.NumeMedicament, ParameterDirection.Input),
                new OracleParameter(":DataExp", OracleDbType.Date, m.DataExp, ParameterDirection.Input),
                new OracleParameter(":Prospect", OracleDbType.NVarchar2, m.Prospect, ParameterDirection.Input),
                new OracleParameter(":TipMedicament", OracleDbType.NVarchar2, m.TipMedicament, ParameterDirection.Input),
                new OracleParameter(":IdReteta", OracleDbType.Int32, m.IdReteta, ParameterDirection.Input)
                
                
            );
        }

        public Medicament GetMedicament(int id)
        {
            Medicament result = null;
            var dsMedicamente = SqlDBHelper.ExecuteDataSet("select * from MEDICAMENT_31A_FPC where IdMedicament = :IdMedicament", CommandType.Text,
                new OracleParameter(":IdMedicament", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsMedicamente.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsMedicamente.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Medicament(linieBD);
                //incarca entitatile aditionale
                result.Reteta = new AdministrareRetete().GetReteta(result.IdReteta);
            }
            return result;
        }

        public Medicament GetMedicament(string name)
        {
            Medicament result = null;
            var dsMedicamente = SqlDBHelper.ExecuteDataSet("select * from MEDICAMENT_31A_FPC where NumeMedicament = :NumeMedicament", CommandType.Text,
                new OracleParameter(":NumeMedicament", OracleDbType.NVarchar2, name, ParameterDirection.Input));

            if (dsMedicamente.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsMedicamente.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Medicament(linieBD);
                //incarca entitatile aditionale
                result.Reteta = new AdministrareRetete().GetReteta(result.IdReteta);
            }
            return result;
        }

        public List<Medicament> GetMedicamente()
        {
            var result = new List<Medicament>();
            var dsMedicamente = SqlDBHelper.ExecuteDataSet("select * from MEDICAMENT_31A_FPC", CommandType.Text);

            foreach (DataRow linieBD in dsMedicamente.Tables[PRIMUL_TABEL].Rows)
            {
                var medicament = new Medicament(linieBD);
                //incarca entitatile aditionale
                medicament.Reteta = new AdministrareRetete().GetReteta(medicament.IdReteta);
                result.Add(medicament);
            }
            return result;
        }

        public bool UpdateMedicament(Medicament m)
        {
            return SqlDBHelper.ExecuteNonQuery(
               "UPDATE MEDICAMENT_31A_FPC set NumeMedicament = :NumeMedicament, DataExp = :DataExp, Prospect = :Prospect, TipMedicament = :TipMedicament, IdReteta = :IdReteta where idMedicament=:IdMedicament", CommandType.Text,
                new OracleParameter(":NumeMedicament", OracleDbType.NVarchar2, m.NumeMedicament, ParameterDirection.Input),
                new OracleParameter(":DataExp", OracleDbType.Date, m.DataExp, ParameterDirection.Input),
                new OracleParameter(":Prospect", OracleDbType.NVarchar2, m.Prospect, ParameterDirection.Input),
                new OracleParameter(":TipMedicament", OracleDbType.NVarchar2, m.TipMedicament, ParameterDirection.Input),
                new OracleParameter(":IdReteta", OracleDbType.Int32, m.IdReteta, ParameterDirection.Input),
                new OracleParameter(":IdMedicament", OracleDbType.Int32, m.IdMedicament, ParameterDirection.Input)
                );
        }
    }
}
