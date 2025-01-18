using Microsoft.SqlServer.Server;
using MySqlX.XDevAPI.Common;
using SevenSummit.Model.Context;
using SevenSummit.Model.Entity;
using SevenSummit.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenSummit.Controller
{
    public class GunungController
    {
        private GunungRepository _repository;
        public GunungController(DbContext context)
        {
            _repository = new GunungRepository(context);
        }

        public List<GunungEntity> GetAllGunung()
        {
          return _repository.getAllGunung();
        }
        
        public List<GunungEntity> GetGunungByName(string namaGunung)
        {
         
          return _repository.getGunungByName(namaGunung);
        }
        public GunungEntity GetGunungById(string idGunung)
        {

            return _repository.getDataGunungById(idGunung);
        }

        public int DeleteDataGunungById(string idGunung)
        {
            return _repository.deleteDataGunungByName(idGunung);
        }

        public int AddDataGunung(GunungEntity gunung)
        {
            
            return _repository.AddDataGunung(gunung);
        }

        public int UpdateDataGunung(GunungEntity gunung, string idGunung)
        {
            
            return _repository.UpdateDataGunung(gunung, idGunung);
        }
        
    }
}
