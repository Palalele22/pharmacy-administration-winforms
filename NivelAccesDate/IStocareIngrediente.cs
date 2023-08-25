using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate
{
    public interface IStocareIngrediente : IStocareFactory
    {
        List<Ingredient> GetIngrediente();
        Ingredient GetIngredient(int id);
        bool AddIngredient(Ingredient i);

        bool UpdateIngredient(Ingredient i);
    }
}
