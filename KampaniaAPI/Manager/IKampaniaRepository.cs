using KampaniaProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KampaniaAPI.Manager
{
    public interface IKampaniaRepository
    {
        List<Kampania> List();
        Kampania Get(int id);
        void Create(Kampania kampania);
        void Edit(Kampania kampania);
        void Delete(int id);
        string Koszt();
    }
}
