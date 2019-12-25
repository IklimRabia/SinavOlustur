using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Kullanici
    {

        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }        
        public DateTime OlusturmaTarih { get; set; }
       
    }
}
