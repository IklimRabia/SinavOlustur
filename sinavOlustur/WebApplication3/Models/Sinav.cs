using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Sinav
    {
        
        public int Id { get; set; }        
        public string description { get; set; }
        public string soru { get; set; }
        public string secenek { get; set; }
        public string cevap { get; set; }
        public DateTime olusturmaTarih { get; set; }
        public DateTime guncellemeTarih { get; set; }
    }
}
