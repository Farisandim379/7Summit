using SevenSummit.Model.Context;
using SevenSummit.Model.Entity;
using SevenSummit.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace SevenSummit.Controller
{
    public class JalurPendakianController
    {
        private JalurPendakianRepository _repository;
        public JalurPendakianController(DbContext context)
        {
            _repository = new JalurPendakianRepository(context);
        }
        public List<JalurPendakianEntity> GetJalurPendakianByIdGunung(string idGunung)
        {

            return _repository.getDataJalurPendakianByIdGunung(idGunung);
        }

        public int AddJalurPendakian(JalurPendakianEntity jalur)
        {
           return _repository.AddJalurPendakian(jalur);
        }

        public int DeleteJalurById(string IdJalur)
        {
            return _repository.deleteJalurById(IdJalur);
        }
    }
}
