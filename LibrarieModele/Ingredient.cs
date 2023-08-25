using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LibrarieModele
{
    public class Ingredient
    {
        public int IdIngredient { get; set; }
        public string NumeIngredient { get; set; }
        public DateTime DataExp { get; set; }
        public int Stoc { get; set; }

        public Ingredient()
        { }

        public Ingredient(string numeIngredient, DateTime dataExp, int stoc, int idIngredient = 0)
        {
            IdIngredient = idIngredient;
            NumeIngredient = numeIngredient;
            DataExp = dataExp;
            Stoc = stoc;
        }

        public Ingredient(DataRow linieBD)
        {
            IdIngredient = Convert.ToInt32(linieBD["idIngredient"].ToString());
            NumeIngredient = linieBD["numeIngredient"].ToString();
            DataExp = Convert.ToDateTime(linieBD["dataExp"].ToString());
            Stoc = Convert.ToInt32(linieBD["stoc"].ToString());
        }

    }
}
