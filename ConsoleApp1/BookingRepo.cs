using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ConsoleApp1
{
    class BookingRepo : IBookingRepository
    {
        public IQueryable<Booking> GetActiveBookings(int? excludedBookingId = null)
        {
            var unitOfWork = new UnitOfWork();
            var bookings =
             unitOfWork.Query<Booking>()
                 .Where(
                     b => b.Id != excludedBookingId && b.Status != "Cancelled");
            return bookings;
        }
    }
}
