using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ConsoleApp1
{
    public interface IBookingRepository

    {
        IQueryable<Booking> GetActiveBookings(int? excludedBookingId = null);
    }
}
