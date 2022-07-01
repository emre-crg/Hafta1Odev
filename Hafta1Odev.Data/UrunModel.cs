using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta1Odev.Data
{
    public class UrunModel
    {
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public string Renk { get; set; }
        public decimal Fiyat { get; set; }
    }
}
