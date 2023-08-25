using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate
{
    public interface IStocareMedicamente : IStocareFactory
    {
        List<Medicament> GetMedicamente();
        Medicament GetMedicament(int id);
        bool AddMedicament(Medicament m);

        Medicament GetMedicament(string name);
        bool UpdateMedicament(Medicament m);
    }
}
