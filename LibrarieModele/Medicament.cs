using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Medicament
    {
        private const bool SUCCES = true;
        private const string SEPARATOR_AFISARE = " ";
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ' ';

        public int IdMedicament { get; set; }
        public string NumeMedicament { get; set; }
        public DateTime DataExp { get; set; }
        public string Prospect { get; set; }
        public string TipMedicament { get; set; }
        public int IdReteta { get; set; }

        public virtual Reteta Reteta { get; set; }

        public Medicament()
        {
            
        }

        public Medicament(string numeMedicament, DateTime dateExp, string prospect, string tipMedicament, int idReteta, int idMedicament = 0)
        {
            IdMedicament = idMedicament;
            NumeMedicament = numeMedicament;
            DataExp = dateExp;
            Prospect = prospect;
            TipMedicament = tipMedicament;
            IdReteta = idReteta;
        }

        public Medicament(DataRow linieBd)
        {
            IdMedicament = Convert.ToInt32(linieBd["idMedicament"].ToString());
            NumeMedicament = linieBd["numeMedicament"].ToString();
            DataExp = Convert.ToDateTime(linieBd["dataExp"].ToString());
            Prospect = linieBd["prospect"].ToString();
            TipMedicament = linieBd["tipMedicament"].ToString();
            IdReteta = Convert.ToInt32(linieBd["idReteta"].ToString());
        }

       

        public int ComparareDataExp(Medicament med1, Medicament med2)
        {
            int result = DateTime.Compare(med1.DataExp, med2.DataExp);
            
            return result;
            /*
             if (result < 0)
                relationship = "is earlier than";
             else if (result == 0)
                relationship = "is the same time as";
             else
                relationship = "is later than";
            */
        }

        

        

        


    }
}
