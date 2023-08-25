using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;
namespace NivelAccesDate
{
    public interface IStocareRetete : IStocareFactory
    {
        List<Reteta> GetRetete();
        Reteta GetReteta(int id);
        bool AddReteta(Reteta r);

        bool UpdateReteta(Reteta r);
    }
}
