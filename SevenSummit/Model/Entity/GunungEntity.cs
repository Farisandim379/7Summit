using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenSummit.Model.Entity
{
    public class GunungEntity
    {
        public string id_Gunung { get; set; }
        public string Nama_Gunung { get; set; }
        public string Ketinggian{ get; set; }
        public string Lokasi { get; set; }
        public string Jalur_Pendakian { get; set; }
        public string Status_Gunung { get; set; }
        public int Biaya_Simaksi { get; set; }
    }
}
