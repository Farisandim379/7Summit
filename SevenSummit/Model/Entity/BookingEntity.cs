using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenSummit.Model.Entity
{
    public class BookingEntity
    {
        public string Nik { get; set; }
        public string idGunung { get; set; }
        public string TanggalPelaksanaan { get; set; }
        public string NomorHp { get; set; }
        public string Email { get; set; }
        public string JumlahPendaki { get; set; }
        public string Catatan { get; set; }
        public string JalurPendakian { get; set; }
    }
}
