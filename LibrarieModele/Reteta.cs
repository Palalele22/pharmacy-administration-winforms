using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LibrarieModele
{
    public class Reteta
    {
        public int IdReteta { get; set; }
        public string IdsIngrediente { get; set; }
        
        //entitate aditionala
        

        public Reteta() { }

        public Reteta(string idsIngrediente, int idReteta = 0) 
        {
            IdReteta = idReteta;
            IdsIngrediente = idsIngrediente;
        }

        public Reteta(DataRow linieBD)
        {
            IdReteta = Convert.ToInt32(linieBD["idReteta"].ToString());
            IdsIngrediente = linieBD["idsIngrediente"].ToString();
        }
    }
}
