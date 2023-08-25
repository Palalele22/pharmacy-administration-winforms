using NivelAccesDate;
using System.Configuration;
using LibrarieModele;
using System;

namespace FarmacieNoua
{
    public class StocareFactory
    {
        public IStocareFactory GetTipStocare(Type tipEntitate)
        {
            var formatSalvare = ConfigurationManager.AppSettings["FormatSalvare"];
            if (formatSalvare != null)
            {
                switch (formatSalvare)
                {
                    default:
                    case "BazaDateOracle":

                        if (tipEntitate == typeof(Ingredient))
                        {
                            return new AdministrareIngrediente();
                        }
                        if (tipEntitate == typeof(Reteta))
                        {
                            return new AdministrareRetete();
                        }
                        if (tipEntitate == typeof(Medicament))
                        {
                            return new AdministrareMedicamente();
                        }
                        break;

                    case "BIN":
                        //instantiere clase care realizeaza salvarea in fisier binar
                        break;
                }
            }
            return null;
        }
    }
}
