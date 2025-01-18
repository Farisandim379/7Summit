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
    public class BookingController
    {
        private BookingRepository _repository;

        public BookingController(DbContext context)
        {
            _repository = new BookingRepository(context);
        }

        public List<BookingEntity> GetAllBooking()
        {
            return _repository.getAllBooking();
        }
        public int AddDataBooking(BookingEntity booking)
        {
            return _repository.AddDataBooking(booking);
        }
        public int DeleteDataBookingByNIK(string Nik)
        {
            return _repository.deleteBookingByNik(Nik);
        }
    }
}
