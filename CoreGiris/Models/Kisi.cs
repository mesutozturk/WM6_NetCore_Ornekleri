using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGiris.Models
{
    public class Kisi
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}
