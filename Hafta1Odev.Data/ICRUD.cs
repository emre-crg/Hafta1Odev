using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta1Odev.Data
{
    internal interface ICRUD<T> where T : class
    {
        List<T> List();
        T Find(int id);
        void Add(T t);
        void Update(T t);
        void Delete(int id);
    }
}
